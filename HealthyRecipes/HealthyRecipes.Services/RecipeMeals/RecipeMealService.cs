using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.RecipeMeals
{
    public class RecipeMealService : IRecipeMeal
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeMealService> _logger;

        public RecipeMealService(HealthyRecipesDbContext context, ILogger<RecipeMealService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddRecipeToMealAsync(Guid recipeId, Guid mealId)
        {
            try
            {
                var existing = await _context.RecipeMeals
                    .FirstOrDefaultAsync(rm => rm.RecipeId == recipeId && rm.MealId == mealId);

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

                _context.RecipeMeals.Add(new RecipeMeal { RecipeId = recipeId, MealId = mealId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("Recipe {RecipeId} added to meal {MealId}", recipeId, mealId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding recipe to meal");
                throw;
            }
        }

        public async Task<bool> RemoveRecipeFromMealAsync(Guid recipeId, Guid mealId)
        {
            try
            {
                var existing = await _context.RecipeMeals
                    .FirstOrDefaultAsync(rm => rm.RecipeId == recipeId && rm.MealId == mealId && !rm.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Recipe {RecipeId} removed from meal {MealId}", recipeId, mealId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing recipe from meal");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeMeal>> GetRecipesByMealAsync(Guid mealId)
        {
            try
            {
                return await _context.RecipeMeals
                    .Include(rm => rm.Recipe)
                        .ThenInclude(r => r!.RecipeIngredients)
                            .ThenInclude(ri => ri.Ingredient)
                    .Where(rm => rm.MealId == mealId && !rm.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving recipes for meal: {MealId}", mealId);
                throw;
            }
        }
    }
}
