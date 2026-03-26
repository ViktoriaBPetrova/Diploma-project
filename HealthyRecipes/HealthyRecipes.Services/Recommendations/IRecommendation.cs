using HealthyRecipes.Services.Recommendations.NewFolder;

namespace HealthyRecipes.Services.Recommendations
{
    public interface IRecommendation
    {
        // Recipe recommendations
        Task<IEnumerable<RecipeRecommendationDto>> GetPersonalizedRecipesAsync(
            Guid userId,
            int count = 10);

        Task<IEnumerable<RecipeRecommendationDto>> GetSimilarRecipesAsync(
            Guid recipeId,
            int count = 6);

        Task<IEnumerable<RecipeRecommendationDto>> GetRecommendedForGoalsAsync(
            Guid userId,
            int count = 10);

        Task<IEnumerable<RecipeRecommendationDto>> GetCollaborativeRecommendationsAsync(
            Guid userId,
            int count = 10);

        Task<IEnumerable<RecipeRecommendationDto>> GetTrendingInCategoryAsync(
            Guid categoryId,
            Guid userId,
            int count = 10);

        // Meal plan recommendations
        Task<IEnumerable<MealPlanRecommendationDto>> GetPersonalizedMealPlansAsync(
            Guid userId,
            int count = 10);

        Task<IEnumerable<MealPlanRecommendationDto>> GetMealPlansForGoalsAsync(
            Guid userId,
            int count = 10);

        Task<IEnumerable<MealPlanRecommendationDto>> GetSimilarMealPlansAsync(
            Guid mealPlanId,
            int count = 6);
    }
}
