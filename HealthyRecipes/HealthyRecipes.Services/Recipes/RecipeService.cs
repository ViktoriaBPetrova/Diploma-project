using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Recipes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Recipes
{

    public class RecipeService : IRecipe
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeService> _logger;

        public RecipeService(
            HealthyRecipesDbContext context,
            ILogger<RecipeService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateRecipeAsync(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            try
            {
                _context.Recipes.Add(recipe);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Recipe created successfully with ID: {RecipeId}", recipe.Id);
                return recipe.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating recipe");
                throw;
            }
        }
        public async Task<Recipe?> GetRecipeByIdAsync(Guid id)
        {
            try
            {
                return await _context.Recipes
                    .Include(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                    .Include(r => r.CommentRatings)
                        .ThenInclude(cr => cr.User)
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.RecipeMeals)
                    .Include(r => r.SavedRecipes)
                    .Include(r => r.User)
                    .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recipe with ID: {RecipeId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeDeleted = false)
        {
            try
            {
                return await _context.Recipes
                    .Include(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                    .Include(r => r.CommentRatings)
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.RecipeMeals)
                    .Include(r => r.SavedRecipes)
                    .Include(r => r.User)
                    .Where(r => includeDeleted || !r.Deleted)
                    .OrderByDescending(r => r.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all recipes");
                throw;
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            try
            {
                var recipes = await _context.Recipes
                    .Include(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                    .Include(r => r.CommentRatings)
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.User)
                    .Where(r => !r.Deleted)
                    .ToListAsync();

                return recipes.Where(predicate).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recipes with predicate");
                throw;
            }
        }

        public async Task<bool> UpdateRecipeAsync(Recipe recipe)
        {
            if (recipe == null)
                throw new ArgumentNullException(nameof(recipe));

            try
            {
                var existing = await _context.Recipes
                    .FirstOrDefaultAsync(r => r.Id == recipe.Id && !r.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Recipe with ID {RecipeId} not found for update", recipe.Id);
                    return false;
                }

                existing.Info = recipe.Info;
                existing.Calories = recipe.Calories;
                existing.Protein = recipe.Protein;
                existing.Carbs = recipe.Carbs;
                existing.Fat = recipe.Fat;
                existing.PrepTime = recipe.PrepTime;
                existing.Servings = recipe.Servings;
                existing.Difficulty = recipe.Difficulty;
                existing.ImageUrl = recipe.ImageUrl;
                existing.VideoUrl = recipe.VideoUrl;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Recipe {RecipeId} updated successfully", recipe.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating recipe with ID: {RecipeId}", recipe.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteRecipeAsync(Guid id)
        {
            try
            {
                var existing = await _context.Recipes
                    .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Recipe with ID {RecipeId} not found for deletion", id);
                    return false;
                }

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Recipe {RecipeId} soft deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting recipe with ID: {RecipeId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreRecipeAsync(Guid id)
        {
            try
            {
                var existing = await _context.Recipes
                    .FirstOrDefaultAsync(r => r.Id == id && r.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Deleted recipe with ID {RecipeId} not found for restoration", id);
                    return false;
                }

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Recipe {RecipeId} restored successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring recipe with ID: {RecipeId}", id);
                throw;
            }
        }

        public async Task<bool> RecalculateRecipeNutritionAsync(Guid id)
        {
            try
            {
                var recipe = await _context.Recipes
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);

                if (recipe == null)
                {
                    _logger.LogWarning("Recipe with ID {RecipeId} not found for nutrition recalculation", id);
                    return false;
                }

                var activeIngredients = recipe.RecipeIngredients
                    .Where(ri => !ri.Deleted && ri.Ingredient != null)
                    .ToList();

                recipe.Calories = activeIngredients.Sum(ri => 
                    ri.Ingredient!.CaloriesPer100g * ri.QuantityInGrams / 100f);
                recipe.Protein = activeIngredients.Sum(ri => 
                    ri.Ingredient!.ProteinPer100g * ri.QuantityInGrams / 100f);
                recipe.Carbs = activeIngredients.Sum(ri => 
                    ri.Ingredient!.CarbsPer100g * ri.QuantityInGrams / 100f);
                recipe.Fat = activeIngredients.Sum(ri => 
                    ri.Ingredient!.FatPer100g * ri.QuantityInGrams / 100f);
                recipe.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("Recipe {RecipeId} nutrition recalculated successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recalculating nutrition for recipe with ID: {RecipeId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Recipe>> GetRecipesByUserAsync(Guid userId)
        {
            try
            {
                return await _context.Recipes
                    .Include(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                    .Include(r => r.CommentRatings)
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.RecipeMeals)
                    .Include(r => r.SavedRecipes)
                    .Include(r => r.User)
                    .Where(m => m.UserId == userId && !m.Deleted)
                    .OrderByDescending(m => m.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recipes for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<(List<Recipe> Recipes, int TotalCount)> GetFilteredRecipesAsync(RecipeFilterDto filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            try
            {
                var query = _context.Recipes
                    .Include(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                    .Include(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                    .Include(r => r.CommentRatings)
                    .Include(r => r.User)
                    .Where(r => !r.Deleted)
                    .AsQueryable();

                // Search term
                if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                {
                    var searchLower = filter.SearchTerm.ToLower();
                    query = query.Where(r => r.Info.ToLower().Contains(searchLower));
                }

                // Macronutrient filters
                if (filter.MinCalories.HasValue)
                    query = query.Where(r => r.Calories >= filter.MinCalories.Value);
                if (filter.MaxCalories.HasValue)
                    query = query.Where(r => r.Calories <= filter.MaxCalories.Value);

                if (filter.MinProtein.HasValue)
                    query = query.Where(r => r.Protein >= filter.MinProtein.Value);
                if (filter.MaxProtein.HasValue)
                    query = query.Where(r => r.Protein <= filter.MaxProtein.Value);

                if (filter.MinCarbs.HasValue)
                    query = query.Where(r => r.Carbs >= filter.MinCarbs.Value);
                if (filter.MaxCarbs.HasValue)
                    query = query.Where(r => r.Carbs <= filter.MaxCarbs.Value);

                if (filter.MinFat.HasValue)
                    query = query.Where(r => r.Fat >= filter.MinFat.Value);
                if (filter.MaxFat.HasValue)
                    query = query.Where(r => r.Fat <= filter.MaxFat.Value);

                // Preparation time
                if (filter.MaxPreparationTime.HasValue)
                    query = query.Where(r => r.PrepTime.HasValue && r.PrepTime.Value <= filter.MaxPreparationTime.Value);

                // Difficulty level
                if (!string.IsNullOrWhiteSpace(filter.DifficultyLevel))
                {
                    if (Enum.TryParse<Data.Enums.Difficulty>(filter.DifficultyLevel, true, out var difficulty))
                    {
                        query = query.Where(r => r.Difficulty == difficulty);
                    }
                }

                // Include ingredients - recipe must contain ALL
                if (filter.IncludeIngredients?.Any() == true)
                {
                    foreach (var ingredientName in filter.IncludeIngredients)
                    {
                        var ingredient = ingredientName.ToLower();
                        query = query.Where(r => r.RecipeIngredients
                            .Any(ri => ri.Ingredient.Name.ToLower().Contains(ingredient)));
                    }
                }

                // Exclude ingredients - recipe must NOT contain ANY
                if (filter.ExcludeIngredients?.Any() == true)
                {
                    foreach (var ingredientName in filter.ExcludeIngredients)
                    {
                        var ingredient = ingredientName.ToLower();
                        query = query.Where(r => !r.RecipeIngredients
                            .Any(ri => ri.Ingredient.Name.ToLower().Contains(ingredient)));
                    }
                }

                // Categories
                if (filter.CategoryIds?.Any() == true)
                {
                    query = query.Where(r => r.RecipeCategories
                        .Any(rc => filter.CategoryIds.Contains(rc.CategoryId) && !rc.Deleted));
                }

                // Total count before pagination
                var totalCount = await query.CountAsync();

                // Sorting
                query = filter.SortBy?.ToLower() switch
                {
                    "calories" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.Calories)
                        : query.OrderByDescending(r => r.Calories),
                    "protein" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.Protein)
                        : query.OrderByDescending(r => r.Protein),
                    "carbs" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.Carbs)
                        : query.OrderByDescending(r => r.Carbs),
                    "fat" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.Fat)
                        : query.OrderByDescending(r => r.Fat),
                    "preptime" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.PrepTime)
                        : query.OrderByDescending(r => r.PrepTime),
                    _ => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(r => r.CreatedAt)
                        : query.OrderByDescending(r => r.CreatedAt)
                };

                // Pagination
                var recipes = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} recipes out of {Total} with filters", recipes.Count, totalCount);

                return (recipes, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting filtered recipes");
                throw;
            }
        }



    }
}
