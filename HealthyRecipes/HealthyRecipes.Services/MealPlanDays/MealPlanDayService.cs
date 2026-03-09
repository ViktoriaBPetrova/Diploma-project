using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.MealPlanDays
{
    public class MealPlanDayService : IMealPlanDay
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealPlanDayService> _logger;

        public MealPlanDayService(HealthyRecipesDbContext context, ILogger<MealPlanDayService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateMealPlanDayAsync(MealPlanDay mealPlanDay)
        {
            if (mealPlanDay == null) throw new ArgumentNullException(nameof(mealPlanDay));
            try
            {
                _context.MealPlanDays.Add(mealPlanDay);
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlanDay created with ID: {Id}", mealPlanDay.Id);
                return mealPlanDay.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating meal plan day");
                throw;
            }
        }

        public async Task<MealPlanDay?> GetMealPlanDayByIdAsync(Guid id)
        {
            try
            {
                return await _context.MealPlanDays
                    .Include(d => d.Meals)
                        .ThenInclude(m => m.RecipeMeals)
                            .ThenInclude(rm => rm.Recipe)
                    .Include(d => d.MealPlan)
                    .FirstOrDefaultAsync(d => d.Id == id && !d.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meal plan day with ID: {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanDay>> GetDaysByMealPlanAsync(Guid mealPlanId)
        {
            try
            {
                return await _context.MealPlanDays
                    .Include(d => d.Meals)
                    .Where(d => d.MealPlanId == mealPlanId && !d.Deleted)
                    .OrderBy(d => d.DayNumber)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving days for meal plan: {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<bool> UpdateMealPlanDayAsync(MealPlanDay mealPlanDay)
        {
            if (mealPlanDay == null) throw new ArgumentNullException(nameof(mealPlanDay));
            try
            {
                var existing = await _context.MealPlanDays.FirstOrDefaultAsync(d => d.Id == mealPlanDay.Id && !d.Deleted);
                if (existing == null)
                {
                    _logger.LogWarning("MealPlanDay with ID {Id} not found", mealPlanDay.Id);
                    return false;
                }

                existing.DayOfWeek = mealPlanDay.DayOfWeek;
                existing.DayNumber = mealPlanDay.DayNumber;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlanDay {Id} updated", mealPlanDay.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating meal plan day: {Id}", mealPlanDay.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteMealPlanDayAsync(Guid id)
        {
            try
            {
                var existing = await _context.MealPlanDays.FirstOrDefaultAsync(d => d.Id == id && !d.Deleted);
                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlanDay {Id} soft deleted", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting meal plan day: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RestoreMealPlanDayAsync(Guid id)
        {
            try
            {
                var existing = await _context.MealPlanDays.FirstOrDefaultAsync(d => d.Id == id && d.Deleted);
                if (existing == null) return false;

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlanDay {Id} restored", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring meal plan day: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RecalculateNutritionAsync(Guid mealPlanDayId)
        {
            try
            {
                var day = await _context.MealPlanDays
                    .Include(d => d.Meals)
                    .FirstOrDefaultAsync(d => d.Id == mealPlanDayId && !d.Deleted);

                if (day == null) return false;

                var activeMeals = day.Meals.Where(m => !m.Deleted).ToList();
                day.Calories = activeMeals.Sum(m => m.Calories);
                day.Protein = activeMeals.Sum(m => m.Protein);
                day.Carbs = activeMeals.Sum(m => m.Carbs);
                day.Fat = activeMeals.Sum(m => m.Fat);
                day.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlanDay {Id} nutrition recalculated", mealPlanDayId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recalculating nutrition for meal plan day: {Id}", mealPlanDayId);
                throw;
            }
        }
    }
}
