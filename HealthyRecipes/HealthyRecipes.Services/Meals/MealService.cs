using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Meals
{
    public class MealService : IMeal
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealService> _logger;

        public MealService(HealthyRecipesDbContext context, ILogger<MealService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateMealAsync(Meal meal)
        {
            if (meal == null) throw new ArgumentNullException(nameof(meal));
            try
            {
                _context.Meals.Add(meal);
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal created with ID: {Id}", meal.Id);
                return meal.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating meal");
                throw;
            }
        }

        public async Task<Meal?> GetMealByIdAsync(Guid id)
        {
            try
            {
                return await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .Include(m => m.MealPlanDay)
                    .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meal with ID: {Id}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Meal>> GetMealsByDayAsync(Guid mealPlanDayId)
        {
            try
            {
                return await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .Where(m => m.MealPlanDayId == mealPlanDayId && !m.Deleted)
                    .OrderBy(m => m.Type)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meals for day: {DayId}", mealPlanDayId);
                throw;
            }
        }

        public async Task<bool> UpdateMealAsync(Meal meal)
        {
            if (meal == null) throw new ArgumentNullException(nameof(meal));
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == meal.Id && !m.Deleted);
                if (existing == null) return false;

                existing.Type = meal.Type;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} updated", meal.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating meal: {Id}", meal.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteMealAsync(Guid id)
        {
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} soft deleted", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting meal: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RestoreMealAsync(Guid id)
        {
            try
            {
                var existing = await _context.Meals.FirstOrDefaultAsync(m => m.Id == id && m.Deleted);
                if (existing == null) return false;

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} restored", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring meal: {Id}", id);
                throw;
            }
        }

        public async Task<bool> RecalculateNutritionAsync(Guid mealId)
        {
            try
            {
                var meal = await _context.Meals
                    .Include(m => m.RecipeMeals)
                        .ThenInclude(rm => rm.Recipe)
                    .FirstOrDefaultAsync(m => m.Id == mealId && !m.Deleted);

                if (meal == null) return false;

                var activeRecipes = meal.RecipeMeals.Where(rm => !rm.Deleted && rm.Recipe != null).ToList();
                meal.Calories = activeRecipes.Sum(rm => rm.Recipe!.Calories);
                meal.Protein = activeRecipes.Sum(rm => rm.Recipe!.Protein);
                meal.Carbs = activeRecipes.Sum(rm => rm.Recipe!.Carbs);
                meal.Fat = activeRecipes.Sum(rm => rm.Recipe!.Fat);
                meal.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Meal {Id} nutrition recalculated", mealId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recalculating nutrition for meal: {Id}", mealId);
                throw;
            }
        }
    }
}
