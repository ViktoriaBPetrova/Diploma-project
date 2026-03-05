using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Meals
{
    public class MealService : IMeal
    {
        private readonly HealthyRecipesDbContext _context;

        public MealService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateMealAsync(Meal meal)
        {
            _context.Meals.Add(meal);
            await _context.SaveChangesAsync();
            return meal.Id;
        }

        public async Task<Meal?> GetMealByIdAsync(Guid id)
        {
            return await _context.Meals
                .Include(m => m.RecipeMeals)
                    .ThenInclude(rm => rm.Recipe)
                .Include(m => m.MealPlanDay)
                .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
        }

        public async Task<IEnumerable<Meal>> GetMealsByDayAsync(Guid mealPlanDayId)
        {
            return await _context.Meals
                .Include(m => m.RecipeMeals)
                    .ThenInclude(rm => rm.Recipe)
                .Where(m => m.MealPlanDayId == mealPlanDayId && !m.Deleted)
                .OrderBy(m => m.Type)
                .ToListAsync();
        }

        public async Task<bool> UpdateMealAsync(Meal meal)
        {
            var existing = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == meal.Id && !m.Deleted);

            if (existing == null)
                return false;

            existing.Type = meal.Type;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Meals.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteMealAsync(Guid id)
        {
            var existing = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Meals.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreMealAsync(Guid id)
        {
            var existing = await _context.Meals
                .FirstOrDefaultAsync(m => m.Id == id && m.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.Meals.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Recalculates and saves cached nutrition totals by summing values from the meal's recipes.
        /// </summary>
        public async Task<bool> RecalculateNutritionAsync(Guid mealId)
        {
            var meal = await _context.Meals
                .Include(m => m.RecipeMeals)
                    .ThenInclude(rm => rm.Recipe)
                .FirstOrDefaultAsync(m => m.Id == mealId && !m.Deleted);

            if (meal == null)
                return false;

            var activeRecipes = meal.RecipeMeals
                .Where(rm => !rm.Deleted && rm.Recipe != null)
                .Select(rm => rm.Recipe)
                .ToList();

            meal.Calories = activeRecipes.Sum(r => r.Calories);
            meal.Protein  = activeRecipes.Sum(r => r.Protein);
            meal.Carbs    = activeRecipes.Sum(r => r.Carbs);
            meal.Fat      = activeRecipes.Sum(r => r.Fat);
            meal.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
