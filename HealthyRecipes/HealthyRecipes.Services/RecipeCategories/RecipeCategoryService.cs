using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.RecipeCategories
{
    public class RecipeCategoryService : IRecipeCategory
    {
        private readonly HealthyRecipesDbContext _context;

        public RecipeCategoryService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task AddCategoryToRecipeAsync(Guid recipeId, Guid categoryId)
        {
            var existing = await _context.RecipeCategories
                .FirstOrDefaultAsync(rc => rc.RecipeId == recipeId && rc.CategoryId == categoryId);

            if (existing != null)
            {
                if (existing.Deleted)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.UpdatedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return; // Already assigned and active
            }

            _context.RecipeCategories.Add(new RecipeCategory
            {
                RecipeId = recipeId,
                CategoryId = categoryId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveCategoryFromRecipeAsync(Guid recipeId, Guid categoryId)
        {
            var existing = await _context.RecipeCategories
                .FirstOrDefaultAsync(rc => rc.RecipeId == recipeId && rc.CategoryId == categoryId && !rc.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RecipeCategory>> GetCategoriesByRecipeAsync(Guid recipeId)
        {
            return await _context.RecipeCategories
                .Include(rc => rc.Category)
                .Where(rc => rc.RecipeId == recipeId && !rc.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipesByCategoryAsync(Guid categoryId)
        {
            return await _context.RecipeCategories
                .Include(rc => rc.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                .Where(rc => rc.CategoryId == categoryId && !rc.Deleted)
                .ToListAsync();
        }
    }
}
