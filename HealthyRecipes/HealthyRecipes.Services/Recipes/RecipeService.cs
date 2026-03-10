using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
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
    }
}
