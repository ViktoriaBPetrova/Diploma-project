using HealthyRecipes.Data;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Services.Statistics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Statistics
{
    public class UserStatisticsService : IUserStatistics
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<UserStatisticsService> _logger;

        public UserStatisticsService(
            HealthyRecipesDbContext context,
            ILogger<UserStatisticsService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<UserStatisticsDto?> GetUserStatisticsAsync(Guid userId)
        {
            try
            {
                var user = await _context.ApplicationUsers
                    .Where(u => u.Id == userId && !u.Deleted)
                    .Select(u => new
                    {
                        u.Id,
                        u.UserName
                    })
                    .FirstOrDefaultAsync();

                if (user == null)
                {
                    _logger.LogWarning("User {UserId} not found", userId);
                    return null;
                }

                var recipesCreatedCount = await GetRecipesCreatedCountAsync(userId);
                var mealPlansCreatedCount = await GetMealPlansCreatedCountAsync(userId);
                var totalRecipeSaves = await GetTotalRecipeSavesReceivedAsync(userId);
                var totalMealPlanSaves = await GetTotalMealPlanSavesReceivedAsync(userId);
                var averageRecipeRating = await GetAverageRecipeRatingAsync(userId);
                
                var ingredientsCreatedCount = await _context.Ingredients
                    .CountAsync(i => i.CreatedByUserId == userId && !i.Deleted);
                
                var categoriesCreatedCount = await _context.Categories
                    .CountAsync(c => c.CreatedBy == userId && !c.Deleted);
                
                var totalCommentsReceived = await _context.CommentRatings
                    .Where(cr => !cr.Deleted && !string.IsNullOrWhiteSpace(cr.Comment))
                    .Join(_context.Recipes,
                        cr => cr.RecipeId,
                        r => r.Id,
                        (cr, r) => new { cr, r })
                    .Where(x => x.r.UserId == userId && !x.r.Deleted)
                    .CountAsync();

                var mostPopularRecipe = await GetMostPopularRecipeAsync(userId);
                var mostPopularMealPlan = await GetMostPopularMealPlanAsync(userId);

                return new UserStatisticsDto
                {
                    UserId = user.Id,
                    UserName = user.UserName ?? "Unknown User",
                    RecipesCreatedCount = recipesCreatedCount,
                    MealPlansCreatedCount = mealPlansCreatedCount,
                    IngredientsCreatedCount = ingredientsCreatedCount,
                    CategoriesCreatedCount = categoriesCreatedCount,
                    TotalRecipeSaves = totalRecipeSaves,
                    TotalMealPlanSaves = totalMealPlanSaves,
                    TotalCommentsReceived = totalCommentsReceived,
                    AverageRecipeRating = averageRecipeRating,
                    MostPopularRecipeId = mostPopularRecipe.recipeId,
                    MostPopularRecipeTitle = mostPopularRecipe.title,
                    MostPopularRecipeSaveCount = mostPopularRecipe.saveCount,
                    MostPopularMealPlanId = mostPopularMealPlan.mealPlanId,
                    MostPopularMealPlanName = mostPopularMealPlan.name,
                    MostPopularMealPlanSaveCount = mostPopularMealPlan.saveCount
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting statistics for user {UserId}", userId);
                throw;
            }
        }

        public async Task<int> GetRecipesCreatedCountAsync(Guid userId)
        {
            try
            {
                return await _context.Recipes
                    .CountAsync(r => r.UserId == userId && !r.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting recipes created count for user {UserId}", userId);
                throw;
            }
        }

        public async Task<int> GetMealPlansCreatedCountAsync(Guid userId)
        {
            try
            {
                return await _context.MealPlans
                    .CountAsync(mp => mp.UserId == userId && !mp.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting meal plans created count for user {UserId}", userId);
                throw;
            }
        }

        public async Task<int> GetTotalRecipeSavesReceivedAsync(Guid userId)
        {
            try
            {
                return await _context.SavedRecipes
                    .Where(sr => !sr.Deleted)
                    .Join(_context.Recipes,
                        sr => sr.RecipeId,
                        r => r.Id,
                        (sr, r) => new { sr, r })
                    .Where(x => x.r.UserId == userId && !x.r.Deleted)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total recipe saves for user {UserId}", userId);
                throw;
            }
        }

        public async Task<int> GetTotalMealPlanSavesReceivedAsync(Guid userId)
        {
            try
            {
                return await _context.SavedMealPlans
                    .Where(smp => !smp.Deleted)
                    .Join(_context.MealPlans,
                        smp => smp.MealPlanId,
                        mp => mp.Id,
                        (smp, mp) => new { smp, mp })
                    .Where(x => x.mp.UserId == userId && !x.mp.Deleted)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting total meal plan saves for user {UserId}", userId);
                throw;
            }
        }

        public async Task<double> GetAverageRecipeRatingAsync(Guid userId)
        {
            try
            {
                var userRecipeIds = await _context.Recipes
                    .Where(r => r.UserId == userId && !r.Deleted)
                    .Select(r => r.Id)
                    .ToListAsync();

                if (!userRecipeIds.Any())
                    return 0;

                var ratings = await _context.CommentRatings
                    .Where(cr => userRecipeIds.Contains(cr.RecipeId) && !cr.Deleted)
                    .Select(cr => (int)cr.Rating)
                    .ToListAsync();

                if (!ratings.Any())
                    return 0;

                return ratings.Average();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting average recipe rating for user {UserId}", userId);
                throw;
            }
        }

        public async Task<(Guid? recipeId, string? title, int saveCount)> GetMostPopularRecipeAsync(Guid userId)
        {
            try
            {
                var popularRecipe = await _context.Recipes
                    .Where(r => r.UserId == userId && !r.Deleted)
                    .Select(r => new
                    {
                        r.Id,
                        r.Title,
                        SaveCount = r.SavedRecipes.Count(sr => !sr.Deleted)
                    })
                    .OrderByDescending(x => x.SaveCount)
                    .FirstOrDefaultAsync();

                if (popularRecipe == null)
                    return (null, null, 0);

                return (popularRecipe.Id, popularRecipe.Title, popularRecipe.SaveCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting most popular recipe for user {UserId}", userId);
                throw;
            }
        }

        public async Task<(Guid? mealPlanId, string? name, int saveCount)> GetMostPopularMealPlanAsync(Guid userId)
        {
            try
            {
                var popularMealPlan = await _context.MealPlans
                    .Where(mp => mp.UserId == userId && !mp.Deleted)
                    .Select(mp => new
                    {
                        mp.Id,
                        mp.Name,
                        SaveCount = mp.SavedMealPlans.Count(smp => !smp.Deleted)
                    })
                    .OrderByDescending(x => x.SaveCount)
                    .FirstOrDefaultAsync();

                if (popularMealPlan == null)
                    return (null, null, 0);

                return (popularMealPlan.Id, popularMealPlan.Name, popularMealPlan.SaveCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting most popular meal plan for user {UserId}", userId);
                throw;
            }
        }
    }
}
