using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.RecipeMeals
{
    public class RecipeMealService : IRecipeMeal
    {
        private readonly HealthyRecipesDbContext _context;

        public RecipeMealService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task AddRecipeToMealAsync(Guid recipeId, Guid mealId)
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
                return; // Already assigned and active
            }

            _context.RecipeMeals.Add(new RecipeMeal
            {
                RecipeId = recipeId,
                MealId = mealId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<bool> RemoveRecipeFromMealAsync(Guid recipeId, Guid mealId)
        {
            var existing = await _context.RecipeMeals
                .FirstOrDefaultAsync(rm => rm.RecipeId == recipeId && rm.MealId == mealId && !rm.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<RecipeMeal>> GetRecipesByMealAsync(Guid mealId)
        {
            return await _context.RecipeMeals
                .Include(rm => rm.Recipe)
                    .ThenInclude(r => r.RecipeIngredients)
                        .ThenInclude(ri => ri.Ingredient)
                .Where(rm => rm.MealId == mealId && !rm.Deleted)
                .ToListAsync();
        }
    }
}
