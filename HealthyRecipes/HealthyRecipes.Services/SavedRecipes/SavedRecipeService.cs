using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.SavedRecipes
{
    public class SavedRecipeService : ISavedRecipe
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<SavedRecipeService> _logger;

        public SavedRecipeService(HealthyRecipesDbContext context, ILogger<SavedRecipeService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SaveRecipeAsync(Guid userId, Guid recipeId)
        {
            try
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
                    return;
                }

                _context.SavedRecipes.Add(new SavedRecipe { UserId = userId, RecipeId = recipeId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("Recipe {RecipeId} saved by user {UserId}", recipeId, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving recipe");
                throw;
            }
        }

        public async Task<bool> UnsaveRecipeAsync(Guid userId, Guid recipeId)
        {
            try
            {
                var existing = await _context.SavedRecipes
                    .FirstOrDefaultAsync(sr => sr.UserId == userId && sr.RecipeId == recipeId && !sr.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Recipe {RecipeId} unsaved by user {UserId}", recipeId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unsaving recipe");
                throw;
            }
        }

        public async Task<IEnumerable<SavedRecipe>> GetSavedRecipesByUserAsync(Guid userId)
        {
            try
            {
                return await _context.SavedRecipes
                    .Include(sr => sr.Recipe)
                        .ThenInclude(r => r.RecipeCategories)
                            .ThenInclude(rc => rc.Category)
                    .Where(sr => sr.UserId == userId && !sr.Deleted)
                    .OrderByDescending(sr => sr.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving saved recipes for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> IsRecipeSavedAsync(Guid userId, Guid recipeId)
        {
            try
            {
                return await _context.SavedRecipes
                    .AnyAsync(sr => sr.UserId == userId && sr.RecipeId == recipeId && !sr.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if recipe is saved");
                throw;
            }
        }
    }
}
