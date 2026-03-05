using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.MealPlanDays
{
    public class MealPlanDayService : IMealPlanDay
    {
        private readonly HealthyRecipesDbContext _context;

        public MealPlanDayService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateMealPlanDayAsync(MealPlanDay mealPlanDay)
        {
            _context.MealPlanDays.Add(mealPlanDay);
            await _context.SaveChangesAsync();
            return mealPlanDay.Id;
        }

        public async Task<MealPlanDay?> GetMealPlanDayByIdAsync(Guid id)
        {
            return await _context.MealPlanDays
                .Include(d => d.Meals)
                    .ThenInclude(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                .Include(d => d.MealPlan)
                .FirstOrDefaultAsync(d => d.Id == id && !d.Deleted);
        }

        public async Task<IEnumerable<MealPlanDay>> GetDaysByMealPlanAsync(Guid mealPlanId)
        {
            return await _context.MealPlanDays
                .Include(d => d.Meals)
                .Where(d => d.MealPlanId == mealPlanId && !d.Deleted)
                .OrderBy(d => d.DayNumber)
                .ToListAsync();
        }

        public async Task<bool> UpdateMealPlanDayAsync(MealPlanDay mealPlanDay)
        {
            var existing = await _context.MealPlanDays
                .FirstOrDefaultAsync(d => d.Id == mealPlanDay.Id && !d.Deleted);

            if (existing == null)
                return false;

            existing.DayOfWeek = mealPlanDay.DayOfWeek;
            existing.DayNumber = mealPlanDay.DayNumber;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.MealPlanDays.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteMealPlanDayAsync(Guid id)
        {
            var existing = await _context.MealPlanDays
                .FirstOrDefaultAsync(d => d.Id == id && !d.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.MealPlanDays.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreMealPlanDayAsync(Guid id)
        {
            var existing = await _context.MealPlanDays
                .FirstOrDefaultAsync(d => d.Id == id && d.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            _context.MealPlanDays.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        /// <summary>
        /// Recalculates cached nutrition totals by summing all non-deleted meals for the day.
        /// </summary>
        public async Task<bool> RecalculateNutritionAsync(Guid mealPlanDayId)
        {
            var day = await _context.MealPlanDays
                .Include(d => d.Meals)
                .FirstOrDefaultAsync(d => d.Id == mealPlanDayId && !d.Deleted);

            if (day == null)
                return false;

            var activeMeals = day.Meals.Where(m => !m.Deleted).ToList();

            day.Calories = activeMeals.Sum(m => m.Calories);
            day.Protein  = activeMeals.Sum(m => m.Protein);
            day.Carbs    = activeMeals.Sum(m => m.Carbs);
            day.Fat      = activeMeals.Sum(m => m.Fat);
            day.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
