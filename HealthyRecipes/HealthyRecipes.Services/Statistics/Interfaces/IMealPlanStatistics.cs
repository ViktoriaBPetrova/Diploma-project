using HealthyRecipes.Services.Statistics.Models;

namespace HealthyRecipes.Services.Statistics.Interfaces
{
    public interface IMealPlanStatistics
    {
        /// Gets comprehensive statistics for a specific meal plan
        Task<MealPlanStatisticsDto?> GetMealPlanStatisticsAsync(Guid mealPlanId);     

        /// Gets the number of users who saved a meal plan
        Task<int> GetSaveCountAsync(Guid mealPlanId);       

        /// Gets the number of users currently following/using this meal plan
        /// Note: Requires MealPlanTracking system to be implemented
        Task<int> GetActiveFollowerCountAsync(Guid mealPlanId);
        
        /// Gets the completion rate for a meal plan
        /// Note: Requires MealPlanTracking system to be implemented
        Task<double> GetCompletionRateAsync(Guid mealPlanId);

        /// Gets a list of user IDs who saved a specific meal plan
        Task<IEnumerable<Guid>> GetUsersWhoSavedAsync(Guid mealPlanId);
    }
}
