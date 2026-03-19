using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Recommendations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Recommendations
{
    public class RecommendationService : IRecommendation
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecommendationService> _logger;

        public RecommendationService(
            HealthyRecipesDbContext context,
            ILogger<RecommendationService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        // ============================================================
        // RECIPE RECOMMENDATIONS
        // ============================================================

        /// <summary>
        /// Personalized Recommendations (Hybrid Approach)
        /// Combines multiple signals with weighted scoring
        /// </summary>
        public async Task<IEnumerable<RecipeRecommendationDto>> GetPersonalizedRecipesAsync(Guid userId, int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.SavedRecipes)
                .Include(u => u.Allergies)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null) return Enumerable.Empty<RecipeRecommendationDto>();

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            var savedRecipeIds = user.SavedRecipes
                .Where(sr => !sr.Deleted)
                .Select(sr => sr.RecipeId)
                .ToHashSet();

            // ✅ Load ALL candidates with all needed navigation properties
            var candidates = await _context.Recipes
                .Where(r => !r.Deleted && !savedRecipeIds.Contains(r.Id))
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .Include(r => r.SavedRecipes)
                .ToListAsync();

            var safeRecipes = candidates
                .Where(r => !r.RecipeIngredients.Any(ri =>
                    allergyIngredientIds.Contains(ri.IngredientId)))
                .ToList();

            // ✅ Pre-load collaborative data ONCE
            var allSavedRecipes = await _context.SavedRecipes
                .Where(sr => !sr.Deleted)
                .Select(sr => new { sr.UserId, sr.RecipeId })
                .ToListAsync();

            var similarUserIds = allSavedRecipes
                .Where(sr => savedRecipeIds.Contains(sr.RecipeId))
                .Select(sr => sr.UserId)
                .Distinct()
                .ToHashSet();

            var collaborativeScores = allSavedRecipes
                .Where(sr => similarUserIds.Contains(sr.UserId))
                .GroupBy(sr => sr.RecipeId)
                .ToDictionary(
                    g => g.Key,
                    g => similarUserIds.Count > 0
                        ? (double)g.Count() / similarUserIds.Count * 100
                        : 0.0
                );

            // ✅ Score in-memory (no DB access)
            var scoredRecipes = safeRecipes.Select(recipe => new
            {
                Recipe = recipe,
                Score = CalculatePersonalizedScoreInMemory(recipe, user, collaborativeScores)
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToRecommendationDto(x.Recipe, x.Score, "Personalized for you", userId))
            .ToList();

            return scoredRecipes;
        }

        /// <summary>
        /// Content-Based (Similar Recipes)
        /// Based on ingredient overlap + category overlap
        /// </summary>
        public async Task<IEnumerable<RecipeRecommendationDto>> GetSimilarRecipesAsync(
            Guid recipeId,
            int count = 6)
        {
            var sourceRecipe = await _context.Recipes
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .FirstOrDefaultAsync(r => r.Id == recipeId && !r.Deleted);

            if (sourceRecipe == null) return Enumerable.Empty<RecipeRecommendationDto>();

            var sourceIngredientIds = sourceRecipe.RecipeIngredients
                .Select(ri => ri.IngredientId)
                .ToHashSet();

            var sourceCategoryIds = sourceRecipe.RecipeCategories
                .Select(rc => rc.CategoryId)
                .ToHashSet();

            var candidates = await _context.Recipes
                .Where(r => !r.Deleted && r.Id != recipeId)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .ToListAsync();

            var scored = candidates.Select(recipe =>
            {
                var ingredientIds = recipe.RecipeIngredients
                    .Select(ri => ri.IngredientId)
                    .ToHashSet();
                var categoryIds = recipe.RecipeCategories
                    .Select(rc => rc.CategoryId)
                    .ToHashSet();

                // Jaccard similarity for ingredients
                var ingredientOverlap = sourceIngredientIds.Intersect(ingredientIds).Count();
                var ingredientUnion = sourceIngredientIds.Union(ingredientIds).Count();
                var ingredientSimilarity = ingredientUnion > 0
                    ? (double)ingredientOverlap / ingredientUnion
                    : 0;

                // Jaccard similarity for categories
                var categoryOverlap = sourceCategoryIds.Intersect(categoryIds).Count();
                var categoryUnion = sourceCategoryIds.Union(categoryIds).Count();
                var categorySimilarity = categoryUnion > 0
                    ? (double)categoryOverlap / categoryUnion
                    : 0;

                // Combined score (70% ingredients, 30% categories)
                var score = (ingredientSimilarity * 0.7 + categorySimilarity * 0.3) * 100;

                return new { Recipe = recipe, Score = score };
            })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToRecommendationDto(
                x.Recipe,
                x.Score,
                "Similar ingredients and categories",
                null))
            .ToList();

            return scored;
        }

        /// <summary>
        /// Goal-Based Recommendations
        /// Match user's macro targets
        /// </summary>
        public async Task<IEnumerable<RecipeRecommendationDto>> GetRecommendedForGoalsAsync(
            Guid userId,
            int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.Allergies)
                .Include(u => u.SavedRecipes)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null ||
                !user.Calories.HasValue ||
                !user.ProteinGoal.HasValue)
            {
                return Enumerable.Empty<RecipeRecommendationDto>();
            }

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            var savedRecipeIds = user.SavedRecipes
                .Where(sr => !sr.Deleted)
                .Select(sr => sr.RecipeId)
                .ToHashSet();

            // Get meal budget (assume 3 meals/day)
            var mealCalorieBudget = user.Calories.Value / 3;
            var mealProteinGoal = user.ProteinGoal.Value / 3;
            var mealCarbsGoal = user.CarbsGoal ?? mealCalorieBudget * 0.45f / 4; // 45% carbs
            var mealFatsGoal = user.FatGoal ?? mealCalorieBudget * 0.30f / 9; // 30% fats

            var candidates = await _context.Recipes
                .Where(r => !r.Deleted &&
                            !savedRecipeIds.Contains(r.Id))
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .ToListAsync();

            var safeRecipes = candidates
                .Where(r => !r.RecipeIngredients.Any(ri =>
                    allergyIngredientIds.Contains(ri.IngredientId)))
                .ToList();

            var scored = safeRecipes.Select(recipe =>
            {
                var perServing = CalculatePerServingMacros(recipe);

                // Calculate deviation from goals (lower is better)
                var calorieDeviation = Math.Abs(perServing.Calories - mealCalorieBudget) / mealCalorieBudget;
                var proteinDeviation = Math.Abs(perServing.Protein - mealProteinGoal) / mealProteinGoal;
                var carbsDeviation = Math.Abs(perServing.Carbs - mealCarbsGoal) / mealCarbsGoal;
                var fatsDeviation = Math.Abs(perServing.Fats - mealFatsGoal) / mealFatsGoal;

                // Weighted score (protein most important for fitness goals)
                var avgDeviation = calorieDeviation * 0.3f +
                                   proteinDeviation * 0.4f +
                                   carbsDeviation * 0.2f +
                                   fatsDeviation * 0.1f;

                // Convert to 0-100 score (inverse of deviation)
                var score = Math.Max(0, (1 - avgDeviation) * 100);

                return new { Recipe = recipe, Score = (double)score, Macros = perServing };
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToRecommendationDto(
                x.Recipe,
                x.Score,
                $"Fits your goals: {x.Macros.Calories:F0} cal, {x.Macros.Protein:F0}g protein",
                userId))
            .ToList();

            return scored;
        }

        /// <summary>
        /// Collaborative Filtering Only
        /// Based on users with similar saved recipes
        /// </summary>
        public async Task<IEnumerable<RecipeRecommendationDto>> GetCollaborativeRecommendationsAsync(
            Guid userId,
            int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.SavedRecipes)
                .Include(u => u.Allergies)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null) return Enumerable.Empty<RecipeRecommendationDto>();

            var savedRecipeIds = user.SavedRecipes
                .Where(sr => !sr.Deleted)
                .Select(sr => sr.RecipeId)
                .ToHashSet();

            if (!savedRecipeIds.Any()) return Enumerable.Empty<RecipeRecommendationDto>();

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            // Find similar users
            var similarUsers = await _context.SavedRecipes
                .Where(sr => !sr.Deleted && savedRecipeIds.Contains(sr.RecipeId))
                .Select(sr => sr.UserId)
                .Distinct()
                .ToListAsync();

            if (!similarUsers.Any()) return Enumerable.Empty<RecipeRecommendationDto>();

            // Find recipes saved by similar users that current user hasn't saved
            var candidates = await _context.Recipes
                .Where(r => !r.Deleted &&
                            !savedRecipeIds.Contains(r.Id) &&
                            r.SavedRecipes.Any(sr => !sr.Deleted && similarUsers.Contains(sr.UserId)))
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .Include(r => r.SavedRecipes)
                .ToListAsync();

            // Filter allergens
            var safeRecipes = candidates
                .Where(r => !r.RecipeIngredients.Any(ri =>
                    allergyIngredientIds.Contains(ri.IngredientId)))
                .ToList();

            // Score by co-occurrence
            var scored = safeRecipes.Select(recipe =>
            {
                var coOccurrenceCount = recipe.SavedRecipes
                    .Count(sr => !sr.Deleted && similarUsers.Contains(sr.UserId));

                var score = (double)coOccurrenceCount / similarUsers.Count * 100;

                return new { Recipe = recipe, Score = score };
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToRecommendationDto(
                x.Recipe,
                x.Score,
                "Popular with users like you",
                userId))
            .ToList();

            return scored;
        }

        /// <summary>
        /// Trending recipes in a specific category
        /// </summary>
        public async Task<IEnumerable<RecipeRecommendationDto>> GetTrendingInCategoryAsync(
            Guid categoryId,
            Guid userId,
            int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.SavedRecipes)
                .Include(u => u.Allergies)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null) return Enumerable.Empty<RecipeRecommendationDto>();

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            var savedRecipeIds = user.SavedRecipes
                .Where(sr => !sr.Deleted)
                .Select(sr => sr.RecipeId)
                .ToHashSet();

            // Get recipes in category from last 3 months
            var threeMonthsAgo = DateTime.UtcNow.AddMonths(-3);

            var candidates = await _context.Recipes
                .Where(r => !r.Deleted &&
                            !savedRecipeIds.Contains(r.Id) &&
                            r.RecipeCategories.Any(rc => rc.CategoryId == categoryId) &&
                            r.CreatedAt >= threeMonthsAgo)
                .Include(r => r.RecipeIngredients)
                    .ThenInclude(ri => ri.Ingredient)
                .Include(r => r.RecipeCategories)
                    .ThenInclude(rc => rc.Category)
                .Include(r => r.CommentRatings)
                .Include(r => r.SavedRecipes)
                .ToListAsync();

            var safeRecipes = candidates
                .Where(r => !r.RecipeIngredients.Any(ri =>
                    allergyIngredientIds.Contains(ri.IngredientId)))
                .ToList();

            var scored = safeRecipes.Select(recipe =>
            {
                var popularityScore = CalculatePopularityScoreInMemory(recipe);
                var recencyScore = CalculateRecencyScore(recipe);

                // 70% popularity, 30% recency
                var score = popularityScore * 0.7 + recencyScore * 0.3;

                return new { Recipe = recipe, Score = score };
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToRecommendationDto(
                x.Recipe,
                x.Score,
                "Trending now",
                userId))
            .ToList();

            return scored;
        }

        // ============================================================
        // MEAL PLAN RECOMMENDATIONS
        // ============================================================

        /// <summary>
        /// Personalized meal plan recommendations
        /// </summary>
        public async Task<IEnumerable<MealPlanRecommendationDto>> GetPersonalizedMealPlansAsync(
            Guid userId,
            int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.Allergies)
                .Include(u => u.MealPlansFollowed)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null) return Enumerable.Empty<MealPlanRecommendationDto>();

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            var followingIds = user.MealPlansFollowed
                .Where(mpf => !mpf.Deleted)
                .Select(mpf => mpf.MealPlanId)
                .ToHashSet();

            var candidates = await _context.MealPlans
                .Where(mp => !mp.Deleted &&
                             !followingIds.Contains(mp.Id))
                .Include(mp => mp.MealPlanDays)
                    .ThenInclude(mpd => mpd.Meals)
                        .ThenInclude(m => m.RecipeMeals)
                            .ThenInclude(rm => rm.Recipe)
                                .ThenInclude(r => r.RecipeIngredients)
                .Include(mp => mp.MealPlanCategories)
                    .ThenInclude(mpc => mpc.Category)
                .ToListAsync();

            // Filter allergens
            var safePlans = candidates.Where(mp =>
                !mp.MealPlanDays.Any(mpd =>
                    mpd.Meals.Any(m =>
                        m.RecipeMeals.Any(rm =>
                            rm.Recipe.RecipeIngredients.Any(ri =>
                                allergyIngredientIds.Contains(ri.IngredientId))))))
                .ToList();

            var scored = safePlans.Select(plan =>
            {
                var popularityScore = CalculateMealPlanPopularityScore(plan);
                var recencyScore = CalculateMealPlanRecencyScore(plan);
                var followerCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.IsActive);
                var completedCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.Status == Data.Enums.MealPlanFollowerStatus.Completed);
                var completionScore = followerCount > 0
                    ? (double)completedCount / followerCount * 100
                    : 0;

                // Weighted score
                var score = popularityScore * 0.4 + recencyScore * 0.3 + completionScore * 0.3;

                return new { Plan = plan, Score = score };
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToMealPlanRecommendationDto(
                x.Plan,
                x.Score,
                "Personalized for you",
                userId))
            .ToList();

            return scored;
        }

        /// <summary>
        /// Meal plans aligned with user's macro goals
        /// </summary>
        public async Task<IEnumerable<MealPlanRecommendationDto>> GetMealPlansForGoalsAsync(
            Guid userId,
            int count = 10)
        {
            var user = await _context.Users
                .Include(u => u.Allergies)
                .Include(u => u.MealPlansFollowed)
                .FirstOrDefaultAsync(u => u.Id == userId && !u.Deleted);

            if (user == null || !user.Calories.HasValue)
            {
                return Enumerable.Empty<MealPlanRecommendationDto>();
            }

            var allergyIngredientIds = user.Allergies
                .Where(a => !a.Deleted)
                .Select(a => a.IngredientId)
                .ToHashSet();

            var followingIds = user.MealPlansFollowed
                .Where(mpf => !mpf.Deleted)
                .Select(mpf => mpf.MealPlanId)
                .ToHashSet();

            var candidates = await _context.MealPlans
                .Where(mp => !mp.Deleted &&
                             !followingIds.Contains(mp.Id))
                .Include(mp => mp.MealPlanDays)
                    .ThenInclude(mpd => mpd.Meals)
                        .ThenInclude(m => m.RecipeMeals)
                            .ThenInclude(rm => rm.Recipe)
                                .ThenInclude(r => r.RecipeIngredients)
                                    .ThenInclude(ri => ri.Ingredient)
                .Include(mp => mp.MealPlanCategories)
                    .ThenInclude(mpc => mpc.Category)
                .Include(mp => mp.MealPlanFollowers)
                .ToListAsync();

            // Filter allergens
            var safePlans = candidates.Where(mp =>
                !mp.MealPlanDays.Any(mpd =>
                    mpd.Meals.Any(m =>
                        m.RecipeMeals.Any(rm =>
                            rm.Recipe.RecipeIngredients.Any(ri =>
                                allergyIngredientIds.Contains(ri.IngredientId))))))
                .ToList();

            var scored = safePlans.Select(plan =>
            {
                var avgMacros = CalculateAverageDailyMacros(plan);

                // Score based on macro alignment
                var calorieDeviation = Math.Abs(avgMacros.Calories - user.Calories.Value) / user.Calories.Value;
                var proteinDeviation = user.ProteinGoal.HasValue
                    ? Math.Abs(avgMacros.Protein - user.ProteinGoal.Value) / user.ProteinGoal.Value
                    : 0f;

                var avgDeviation = (calorieDeviation * 0.5f + proteinDeviation * 0.5f);
                var macroScore = Math.Max(0, (1 - avgDeviation) * 100);

                // Boost score for completed plans (social proof)
                var completedCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.Status == Data.Enums.MealPlanFollowerStatus.Completed);
                var completionBonus = completedCount * 2;

                var finalScore = (double)macroScore + completionBonus;

                return new { Plan = plan, Score = finalScore, Macros = avgMacros };
            })
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToMealPlanRecommendationDto(
                x.Plan,
                x.Score,
                $"Matches your {x.Macros.Calories:F0} cal/day goal",
                userId))
            .ToList();

            return scored;
        }

        /// <summary>
        /// Similar meal plans based on content
        /// </summary>
        public async Task<IEnumerable<MealPlanRecommendationDto>> GetSimilarMealPlansAsync(
            Guid mealPlanId,
            int count = 6)
        {
            var sourcePlan = await _context.MealPlans
                .Include(mp => mp.MealPlanDays)
                    .ThenInclude(mpd => mpd.Meals)
                        .ThenInclude(m => m.RecipeMeals)
                .Include(mp => mp.MealPlanCategories)
                .FirstOrDefaultAsync(mp => mp.Id == mealPlanId && !mp.Deleted);

            if (sourcePlan == null) return Enumerable.Empty<MealPlanRecommendationDto>();

            // Get all recipe IDs in source plan
            var sourceRecipeIds = sourcePlan.MealPlanDays
                .SelectMany(mpd => mpd.Meals)
                .SelectMany(m => m.RecipeMeals)
                .Select(rm => rm.RecipeId)
                .Distinct()
                .ToHashSet();

            var sourceCategoryIds = sourcePlan.MealPlanCategories
                .Select(mpc => mpc.CategoryId)
                .ToHashSet();

            // Get duration days count
            var sourceDurationDays = sourcePlan.MealPlanDays.Count();

            var candidates = await _context.MealPlans
                .Where(mp => !mp.Deleted && mp.Id != mealPlanId)
                .Include(mp => mp.MealPlanDays)
                    .ThenInclude(mpd => mpd.Meals)
                        .ThenInclude(m => m.RecipeMeals)
                .Include(mp => mp.MealPlanCategories)
                    .ThenInclude(mpc => mpc.Category)
                .ToListAsync();

            var scored = candidates.Select(plan =>
            {
                var recipeIds = plan.MealPlanDays
                    .SelectMany(mpd => mpd.Meals)
                    .SelectMany(m => m.RecipeMeals)
                    .Select(rm => rm.RecipeId)
                    .Distinct()
                    .ToHashSet();

                var categoryIds = plan.MealPlanCategories
                    .Select(mpc => mpc.CategoryId)
                    .ToHashSet();

                var planDurationDays = plan.MealPlanDays.Count();

                // Recipe overlap
                var recipeOverlap = sourceRecipeIds.Intersect(recipeIds).Count();
                var recipeUnion = sourceRecipeIds.Union(recipeIds).Count();
                var recipeSimilarity = recipeUnion > 0
                    ? (double)recipeOverlap / recipeUnion
                    : 0;

                // Category overlap
                var categoryOverlap = sourceCategoryIds.Intersect(categoryIds).Count();
                var categoryUnion = sourceCategoryIds.Union(categoryIds).Count();
                var categorySimilarity = categoryUnion > 0
                    ? (double)categoryOverlap / categoryUnion
                    : 0;

                // Duration similarity
                var durationSimilarity = 1 - Math.Abs(sourceDurationDays - planDurationDays) /
                    (double)Math.Max(sourceDurationDays, planDurationDays);

                // Combined score
                var score = (recipeSimilarity * 0.5 + categorySimilarity * 0.3 + durationSimilarity * 0.2) * 100;

                return new { Plan = plan, Score = score };
            })
            .Where(x => x.Score > 0)
            .OrderByDescending(x => x.Score)
            .Take(count)
            .Select(x => MapToMealPlanRecommendationDto(
                x.Plan,
                x.Score,
                "Similar recipes and structure",
                null))
            .ToList();

            return scored;
        }

        // ============================================================
        // HELPER METHODS - SCORING
        // ============================================================

        private double CalculatePersonalizedScoreInMemory(Recipe recipe, ApplicationUser user, Dictionary<Guid, double> collaborativeScores)
        {
            double score = 0;

            // 1. Collaborative (40%)
            score += collaborativeScores.GetValueOrDefault(recipe.Id, 0.0) * 0.4;

            // 2. Macro match (30%)
            score += CalculateMacroScoreInMemory(recipe, user) * 0.3;

            // 3. Popularity (20%)
            score += CalculatePopularityScoreInMemory(recipe) * 0.2;

            // 4. Recency (10%)
            score += CalculateRecencyScore(recipe) * 0.1;

            return score;
        }

        private double CalculateMacroScoreInMemory(Recipe recipe, ApplicationUser user)
        {
            if (!user.Calories.HasValue) return 50;

            var perServing = CalculatePerServingMacros(recipe);
            var mealCalorieBudget = user.Calories.Value / 3;
            var deviation = Math.Abs(perServing.Calories - mealCalorieBudget) / mealCalorieBudget;

            return Math.Max(0, (1 - deviation) * 100);
        }

        private double CalculatePopularityScoreInMemory(Recipe recipe)
        {
            var ratings = recipe.CommentRatings.Where(cr => !cr.Deleted).ToList();
            var saveCount = recipe.SavedRecipes?.Count(sr => !sr.Deleted) ?? 0;

            if (!ratings.Any() && saveCount == 0) return 0;

            var avgRating = ratings.Any() ? ratings.Average(cr => (decimal)cr.Rating) : 0;
            var ratingScore = avgRating * 20;
            var saveScore = Math.Log(saveCount + 1) * 10;

            return ((double)ratingScore * 0.7 + saveScore * 0.3);
        }

        private double CalculateRecencyScore(Recipe recipe)
        {
            var daysSinceCreated = (DateTime.UtcNow - recipe.CreatedAt).Days;

            // Decay function: newer = higher score
            // 100 for today, ~50 for 30 days old, ~25 for 90 days old
            return Math.Max(0, 100 * Math.Exp(-daysSinceCreated / 50.0));
        }

        private double CalculateMealPlanPopularityScore(MealPlan plan)
        {
            var followerCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.IsActive);
            var followerScore = Math.Log(followerCount + 1) * 15;

            var completedCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.Status == Data.Enums.MealPlanFollowerStatus.Completed);
            var completionScore = completedCount * 5;

            return followerScore + completionScore;
        }

        private double CalculateMealPlanRecencyScore(MealPlan plan)
        {
            var daysSinceCreated = (DateTime.UtcNow - plan.CreatedAt).Days;
            return Math.Max(0, 100 * Math.Exp(-daysSinceCreated / 60.0));
        }

        // ============================================================
        // HELPER METHODS - CALCULATIONS
        // ============================================================

        private (float Calories, float Protein, float Carbs, float Fats) CalculatePerServingMacros(Recipe recipe)
        {
            var total = recipe.RecipeIngredients.Aggregate((Calories: 0f, Protein: 0f, Carbs: 0f, Fats: 0f),
                (acc, ri) =>
                {
                    if (ri.Ingredient == null)
                    {
                        _logger.LogWarning("RecipeIngredient {IngredientId} in Recipe {RecipeId} has null Ingredient",
                        ri.IngredientId, recipe.Id);
                        return acc;  
                    }

                    return (
                    acc.Calories + ri.Ingredient.CaloriesPer100g * ri.QuantityInGrams / 100,
                    acc.Protein + ri.Ingredient.ProteinPer100g * ri.QuantityInGrams / 100,
                    acc.Carbs + ri.Ingredient.CarbsPer100g * ri.QuantityInGrams / 100,
                    acc.Fats + ri.Ingredient.FatPer100g * ri.QuantityInGrams / 100
                    );
                }
            );

                var servings = recipe.Servings ?? 1;

                return (
                total.Calories / servings,
                total.Protein / servings,
                total.Carbs / servings,
                total.Fats / servings
                );
        }

        private (float Calories, float Protein, float Carbs, float Fats) CalculateAverageDailyMacros(MealPlan plan)
        {
            if (!plan.MealPlanDays.Any()) return (0, 0, 0, 0);

            var dailyTotals = plan.MealPlanDays.Select(day =>
            {
                var dayTotal = (Calories: 0f, Protein: 0f, Carbs: 0f, Fats: 0f);

                foreach (var meal in day.Meals)
                {
                    foreach (var recipeMeal in meal.RecipeMeals)
                    {
                        var macros = CalculatePerServingMacros(recipeMeal.Recipe);
                        // RecipeMeal.Servings is nullable, default to 1 if null
                        var servings = recipeMeal.Recipe.Servings ?? 1;
                        dayTotal.Calories += macros.Calories * servings;
                        dayTotal.Protein += macros.Protein * servings;
                        dayTotal.Carbs += macros.Carbs * servings;
                        dayTotal.Fats += macros.Fats * servings;
                    }
                }

                return dayTotal;
            }).ToList();

            var avgCalories = dailyTotals.Average(dt => dt.Calories);
            var avgProtein = dailyTotals.Average(dt => dt.Protein);
            var avgCarbs = dailyTotals.Average(dt => dt.Carbs);
            var avgFats = dailyTotals.Average(dt => dt.Fats);

            return (avgCalories, avgProtein, avgCarbs, avgFats);
        }

        // ============================================================
        // HELPER METHODS - MAPPING
        // ============================================================

        private RecipeRecommendationDto MapToRecommendationDto(
            Recipe recipe,
            double score,
            string reason,
            Guid? userId)
        {
            var macros = CalculatePerServingMacros(recipe);
            var ratings = recipe.CommentRatings.Where(cr => !cr.Deleted).ToList();

            return new RecipeRecommendationDto
            {
                RecipeId = recipe.Id,
                Title = recipe.Title ?? "Untitled Recipe",
                ImageUrl = recipe.ImageUrl ?? string.Empty,
                PrepTime = recipe.PrepTime ?? 0,
                Servings = recipe.Servings ?? 1,
                Calories = (decimal)macros.Calories,
                Protein = (decimal)macros.Protein,
                Carbs = (decimal)macros.Carbs,
                Fats = (decimal)macros.Fats,
                Score = score,
                RecommendationReason = reason,
                Categories = recipe.RecipeCategories
                    .Select(rc => rc.Category.Name)
                    .ToList(),
                IsSaved = userId.HasValue &&
                          recipe.SavedRecipes.Any(sr => !sr.Deleted && sr.UserId == userId.Value),
                HasUserRated = userId.HasValue &&
                               ratings.Any(cr => cr.UserId == userId.Value),
                AverageRating = ratings.Any() ? ratings.Average(cr => (double)cr.Rating) : null
            };
        }

        private MealPlanRecommendationDto MapToMealPlanRecommendationDto(
            MealPlan plan,
            double score,
            string reason,
            Guid? userId)
        {
            var avgMacros = CalculateAverageDailyMacros(plan);
            var followerCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.IsActive);
            var completedCount = plan.MealPlanFollowers.Count(mpf => !mpf.Deleted && mpf.Status == Data.Enums.MealPlanFollowerStatus.Completed);
            var completionRate = followerCount > 0
                ? (double)completedCount / followerCount
                : 0;

            return new MealPlanRecommendationDto
            {
                MealPlanId = plan.Id,
                Title = plan.Name,
                Description = plan.Description ?? string.Empty,
                DurationDays = plan.MealPlanDays.Count(),
                AvgDailyCalories = (decimal)avgMacros.Calories,
                AvgDailyProtein = (decimal)avgMacros.Protein,
                AvgDailyCarbs = (decimal)avgMacros.Carbs,
                AvgDailyFats = (decimal)avgMacros.Fats,
                FollowerCount = followerCount,
                CompletionCount = completedCount,
                CompletionRate = completionRate,
                Score = score,
                RecommendationReason = reason,
                Categories = plan.MealPlanCategories
                    .Select(mpc => mpc.Category.Name)
                    .ToList(),
                IsFollowing = userId.HasValue &&
                              plan.MealPlanFollowers.Any(mpf => !mpf.Deleted && mpf.UserId == userId.Value && mpf.IsActive),
                HasCompleted = userId.HasValue &&
                               plan.MealPlanFollowers.Any(mpf => !mpf.Deleted &&
                                                                 mpf.UserId == userId.Value &&
                                                                 mpf.Status == Data.Enums.MealPlanFollowerStatus.Completed)
            };
        }
    }
}
