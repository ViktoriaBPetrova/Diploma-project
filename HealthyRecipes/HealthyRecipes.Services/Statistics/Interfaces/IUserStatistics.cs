using HealthyRecipes.Services.Statistics.Models;

namespace HealthyRecipes.Services.Statistics.Interfaces
{
    public interface IUserStatistics
    {
        /// Gets comprehensive statistics for a specific user
        Task<UserStatisticsDto?> GetUserStatisticsAsync(Guid userId);
        
        /// Gets the number of recipes created by a user
        Task<int> GetRecipesCreatedCountAsync(Guid userId);
        
        /// Gets the number of meal plans created by a user
        Task<int> GetMealPlansCreatedCountAsync(Guid userId);
        
        /// Gets the total number of saves received across all of a user's recipes
        Task<int> GetTotalRecipeSavesReceivedAsync(Guid userId);
        
        /// Gets the total number of saves received across all of a user's meal plans
        Task<int> GetTotalMealPlanSavesReceivedAsync(Guid userId);
        
        /// Gets the average rating across all of a user's recipes
        Task<double> GetAverageRecipeRatingAsync(Guid userId);
        
        /// Gets the user's most popular recipe (by save count)
        Task<(Guid? recipeId, string? title, int saveCount)> GetMostPopularRecipeAsync(Guid userId);
        
        /// Gets the user's most popular meal plan (by save count)
        Task<(Guid? mealPlanId, string? name, int saveCount)> GetMostPopularMealPlanAsync(Guid userId);
    }
}
