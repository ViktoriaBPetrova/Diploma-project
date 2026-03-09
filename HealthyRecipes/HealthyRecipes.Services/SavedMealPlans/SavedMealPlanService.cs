using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.SavedMealPlans
{
    public class SavedMealPlanService : ISavedMealPlan
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<SavedMealPlanService> _logger;

        public SavedMealPlanService(HealthyRecipesDbContext context, ILogger<SavedMealPlanService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SaveMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                var existing = await _context.SavedMealPlans
                    .FirstOrDefaultAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId);

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

                _context.SavedMealPlans.Add(new SavedMealPlan { UserId = userId, MealPlanId = mealPlanId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlan {MealPlanId} saved by user {UserId}", mealPlanId, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving meal plan");
                throw;
            }
        }

        public async Task<bool> UnsaveMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                var existing = await _context.SavedMealPlans
                    .FirstOrDefaultAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId && !smp.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("MealPlan {MealPlanId} unsaved by user {UserId}", mealPlanId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unsaving meal plan");
                throw;
            }
        }

        public async Task<IEnumerable<SavedMealPlan>> GetSavedMealPlansByUserAsync(Guid userId)
        {
            try
            {
                return await _context.SavedMealPlans
                    .Include(smp => smp.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                    .Where(smp => smp.UserId == userId && !smp.Deleted)
                    .OrderByDescending(smp => smp.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving saved meal plans for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> IsMealPlanSavedAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                return await _context.SavedMealPlans
                    .AnyAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId && !smp.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if meal plan is saved");
                throw;
            }
        }
    }
}
