using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.RecipeIngredients
{
    public class RecipeIngredientService : IRecipeIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeIngredientService> _logger;

        public RecipeIngredientService(HealthyRecipesDbContext context, ILogger<RecipeIngredientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddIngredientToRecipeAsync(Guid recipeId, Guid ingredientId, float quantityInGrams)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);

                if (existing != null)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.QuantityInGrams = quantityInGrams;
                    existing.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    _context.RecipeIngredients.Add(new RecipeIngredient
                    {
                        RecipeId = recipeId,
                        IngredientId = ingredientId,
                        QuantityInGrams = quantityInGrams
                    });
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} added to recipe {RecipeId}", ingredientId, recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding ingredient to recipe");
                throw;
            }
        }

        public async Task<bool> UpdateQuantityAsync(Guid recipeId, Guid ingredientId, float newQuantityInGrams)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

                if (existing == null) return false;

                existing.QuantityInGrams = newQuantityInGrams;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Quantity updated for ingredient {IngredientId} in recipe {RecipeId}", ingredientId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient quantity");
                throw;
            }
        }

        public async Task<bool> RemoveIngredientFromRecipeAsync(Guid recipeId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} removed from recipe {RecipeId}", ingredientId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing ingredient from recipe");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipeAsync(Guid recipeId)
        {
            try
            {
                return await _context.RecipeIngredients
                    .Include(ri => ri.Ingredient)
                    .Where(ri => ri.RecipeId == recipeId && !ri.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients for recipe: {RecipeId}", recipeId);
                throw;
            }
        }
    }
}
