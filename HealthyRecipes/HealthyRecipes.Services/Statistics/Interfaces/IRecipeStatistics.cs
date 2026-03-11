using HealthyRecipes.Services.Statistics.Models;

namespace HealthyRecipes.Services.Statistics.Interfaces
{
    public interface IRecipeStatistics
    {
        /// Gets comprehensive statistics for a specific recipe
        Task<RecipeStatisticsDto?> GetRecipeStatisticsAsync(Guid recipeId);
        

        /// Gets the number of users who saved a recipe
        Task<int> GetSaveCountAsync(Guid recipeId);
        

        /// Gets the average rating for a recipe
        Task<double> GetAverageRatingAsync(Guid recipeId);
        

        /// Gets the total number of comments/ratings for a recipe
        Task<int> GetCommentCountAsync(Guid recipeId);
        

        /// Gets the number of meal plans that use this recipe
        Task<int> GetMealPlanUsageCountAsync(Guid recipeId);
        

        /// Gets a list of user IDs who saved a specific recipe
        Task<IEnumerable<Guid>> GetUsersWhoSavedAsync(Guid recipeId);
    }
}
