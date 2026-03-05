using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.SavedRecipes
{
    public class SavedRecipeService : ISavedRecipe
    {
        private readonly HealthyRecipesDbContext _context;

        public SavedRecipeService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task SaveRecipeAsync(Guid userId, Guid recipeId)
        {
            var existing = await _context.SavedRecipes
                .FirstOrDefaultAsync(sr => sr.UserId == userId && sr.RecipeId == recipeId);

            if (existing != null)
            {
                if (existing.Deleted)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.UpdatedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return; // Already saved and active
            }

            _context.SavedRecipes.Add(new SavedRecipe
            {
                UserId = userId,
                RecipeId = recipeId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UnsaveRecipeAsync(Guid userId, Guid recipeId)
        {
            var existing = await _context.SavedRecipes
                .FirstOrDefaultAsync(sr => sr.UserId == userId && sr.RecipeId == recipeId && !sr.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SavedRecipe>> GetSavedRecipesByUserAsync(Guid userId)
        {
            return await _context.SavedRecipes
                .Include(sr => sr.Recipe)
                    .ThenInclude(r => r.RecipeCategories)
                        .ThenInclude(rc => rc.Category)
                .Where(sr => sr.UserId == userId && !sr.Deleted)
                .OrderByDescending(sr => sr.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> IsRecipeSavedAsync(Guid userId, Guid recipeId)
        {
            return await _context.SavedRecipes
                .AnyAsync(sr => sr.UserId == userId && sr.RecipeId == recipeId && !sr.Deleted);
        }
    }
}
