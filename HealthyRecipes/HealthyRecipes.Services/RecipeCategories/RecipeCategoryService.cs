using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.RecipeCategories
{
    public class RecipeCategoryService : IRecipeCategory
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeCategoryService> _logger;

        public RecipeCategoryService(HealthyRecipesDbContext context, ILogger<RecipeCategoryService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddCategoryToRecipeAsync(Guid recipeId, Guid categoryId)
        {
            try
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
                    return;
                }

                _context.RecipeCategories.Add(new RecipeCategory { RecipeId = recipeId, CategoryId = categoryId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("Category {CategoryId} added to recipe {RecipeId}", categoryId, recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding category to recipe");
                throw;
            }
        }

        public async Task<bool> RemoveCategoryFromRecipeAsync(Guid recipeId, Guid categoryId)
        {
            try
            {
                var existing = await _context.RecipeCategories
                    .FirstOrDefaultAsync(rc => rc.RecipeId == recipeId && rc.CategoryId == categoryId && !rc.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Category {CategoryId} removed from recipe {RecipeId}", categoryId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing category from recipe");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeCategory>> GetCategoriesByRecipeAsync(Guid recipeId)
        {
            try
            {
                return await _context.RecipeCategories
                    .Include(rc => rc.Category)
                    .Where(rc => rc.RecipeId == recipeId && !rc.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving categories for recipe: {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<IEnumerable<RecipeCategory>> GetRecipesByCategoryAsync(Guid categoryId)
        {
            try
            {
                return await _context.RecipeCategories
                    .Include(rc => rc.Recipe)
                        .ThenInclude(r => r!.RecipeIngredients)
                            .ThenInclude(ri => ri.Ingredient)
                    .Where(rc => rc.CategoryId == categoryId && !rc.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recipes for category: {CategoryId}", categoryId);
                throw;
            }
        }
    }
}
