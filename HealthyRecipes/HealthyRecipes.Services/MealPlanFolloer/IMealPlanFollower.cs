using HealthyRecipes.Data.Entities.MappingEntities.MealPlanTracking;
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

        // COMPLETION CONSENT METHODS 

        /// <summary>
        /// Save user's completion consents (profile visibility + journal sharing).
        /// Called during completion flow.
        /// </summary>
        Task<bool> SaveCompletionConsentsAsync(Guid userId, Guid mealPlanId, bool showOnProfile, bool shareJournal);

        /// <summary>
        /// Get completion count for a meal plan (users who completed it).
        /// </summary>
        Task<int> GetCompletionCountAsync(Guid mealPlanId);

        /// <summary>
        /// Get active follower count for a meal plan (currently following).
        /// </summary>
        Task<int> GetActiveFollowerCountAsync(Guid mealPlanId);

        /// <summary>
        /// Get users who completed the plan AND consented to profile display.
        /// Returns showcase for meal plan details page.
        /// </summary>
        Task<IEnumerable<MealPlanFollower>> GetCompletedShowcaseAsync(Guid mealPlanId);

        /// <summary>
        /// Updates an existing MealPlanFollower record.
        /// Used for status changes, completion, consent updates, etc.
        /// </summary>
        Task<bool> UpdateFollowerAsync(MealPlanFollower follower);
    }
}
