using HealthyRecipes.Data;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Services.Statistics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Statistics.Services
{
    public class MealPlanStatisticsService : IMealPlanStatistics
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealPlanStatisticsService> _logger;

        public MealPlanStatisticsService(
            HealthyRecipesDbContext context,
            ILogger<MealPlanStatisticsService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<MealPlanStatisticsDto?> GetMealPlanStatisticsAsync(Guid mealPlanId)
        {
            try
            {
                var mealPlan = await _context.MealPlans
                    .Where(mp => mp.Id == mealPlanId && !mp.Deleted)
                    .Select(mp => new
                    {
                        mp.Id,
                        mp.Name
                    })
                    .FirstOrDefaultAsync();

                if (mealPlan == null)
                {
                    _logger.LogWarning("Meal plan {MealPlanId} not found", mealPlanId);
                    return null;
                }

                var saveCount = await GetSaveCountAsync(mealPlanId);
                var activeFollowerCount = await GetActiveFollowerCountAsync(mealPlanId);
                var completionRate = await GetCompletionRateAsync(mealPlanId);

                return new MealPlanStatisticsDto
                {
                    MealPlanId = mealPlan.Id,
                    MealPlanName = mealPlan.Name ?? "Untitled Meal Plan",
                    SaveCount = saveCount,
                    ActiveFollowerCount = activeFollowerCount,
                    CompletionRate = completionRate
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting statistics for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<int> GetSaveCountAsync(Guid mealPlanId)
        {
            try
            {
                return await _context.SavedMealPlans
                    .CountAsync(smp => smp.MealPlanId == mealPlanId && !smp.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting save count for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<int> GetActiveFollowerCountAsync(Guid mealPlanId)
        {
            try
            {
                // TODO: This requires a MealPlanTracking entity to be implemented
                // For now, we'll return the save count as a placeholder
                // Once tracking is implemented, this should query active tracking records
                _logger.LogWarning("GetActiveFollowerCountAsync is using SaveCount as placeholder - MealPlanTracking not yet implemented");
                return await GetSaveCountAsync(mealPlanId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active follower count for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<double> GetCompletionRateAsync(Guid mealPlanId)
        {
            try
            {
                // TODO: This requires a MealPlanTracking entity with completion tracking
                // For now, return 0 as a placeholder
                // Once tracking is implemented, calculate: (completed / total followers) * 100
                _logger.LogWarning("GetCompletionRateAsync returning 0 - MealPlanTracking not yet implemented");
                return 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting completion rate for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<IEnumerable<Guid>> GetUsersWhoSavedAsync(Guid mealPlanId)
        {
            try
            {
                return await _context.SavedMealPlans
                    .Where(smp => smp.MealPlanId == mealPlanId && !smp.Deleted)
                    .Select(smp => smp.UserId)
                    .Distinct()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users who saved meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }
    }
}
