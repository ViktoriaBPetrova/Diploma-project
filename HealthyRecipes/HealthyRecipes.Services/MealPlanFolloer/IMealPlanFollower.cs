using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Services.MealPlanFollowers
{
    public interface IMealPlanFollower
    {
        /// Start following a meal plan
        Task<bool> StartFollowingAsync(Guid userId, Guid mealPlanId);

        /// Mark a meal plan as completed
        Task<bool> CompleteMealPlanAsync(Guid userId, Guid mealPlanId);

        /// Drop out from a meal plan with a reason
        Task<bool> DropMealPlanAsync(Guid userId, Guid mealPlanId, string? reason = null);

        /// Pause a meal plan
        Task<bool> PauseMealPlanAsync(Guid userId, Guid mealPlanId, string? reason = null);

        /// Resume a paused meal plan
        Task<bool> ResumeMealPlanAsync(Guid userId, Guid mealPlanId);

        /// Get all meal plans a user is following (any status)
        Task<IEnumerable<MealPlanFollower>> GetAllFollowingPlansAsync(Guid userId);

        /// Get all followers of a specific meal plan
        Task<IEnumerable<MealPlanFollower>> GetPlanFollowersAsync(Guid mealPlanId);

        /// Check if a user is following a meal plan
        Task<bool> IsFollowingAsync(Guid userId, Guid mealPlanId);

        /// Get follower details
        Task<MealPlanFollower?> GetFollowerDetailsAsync(Guid userId, Guid mealPlanId);

        /// Get follower count for a meal plan
        Task<int> GetFollowerCountAsync(Guid mealPlanId);

        /// Get user's current active plan (if any)
        Task<MealPlanFollower?> GetActivePlanAsync(Guid userId);

        /// Get active following plans (only Active status)
        Task<IEnumerable<MealPlanFollower>> GetActiveFollowingPlansAsync(Guid userId);

        /// Get paused following plans (only Paused status)
        Task<IEnumerable<MealPlanFollower>> GetPausedFollowingPlansAsync(Guid userId);

        /// Mark completion prompt as seen
        Task<bool> MarkCompletionPromptSeenAsync(Guid userId, Guid mealPlanId);
    }
}
