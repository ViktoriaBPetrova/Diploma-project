using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.RecipeIngredients
{
    public class RecipeIngredientService : IRecipeIngredient
    {
        private readonly HealthyRecipesDbContext _context;

        public RecipeIngredientService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task AddIngredientToRecipeAsync(Guid recipeId, Guid ingredientId, float quantityInGrams)
        {
            var existing = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);

            if (existing != null)
            {
                // Restore and update quantity if previously removed
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
        }

        public async Task<bool> UpdateQuantityAsync(Guid recipeId, Guid ingredientId, float newQuantityInGrams)
        {
            var existing = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

            if (existing == null)
                return false;

            existing.QuantityInGrams = newQuantityInGrams;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveIngredientFromRecipeAsync(Guid recipeId, Guid ingredientId)
        {
            var existing = await _context.RecipeIngredients
                .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipeAsync(Guid recipeId)
        {
            return await _context.RecipeIngredients
                .Include(ri => ri.Ingredient)
                .Where(ri => ri.RecipeId == recipeId && !ri.Deleted)
                .ToListAsync();
        }
    }
}
