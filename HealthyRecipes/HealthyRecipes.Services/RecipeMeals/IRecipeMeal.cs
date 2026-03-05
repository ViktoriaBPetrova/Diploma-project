using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.RecipeMeals
{
    public interface IRecipeMeal
    {
        Task AddRecipeToMealAsync(Guid recipeId, Guid mealId);
        Task<bool> RemoveRecipeFromMealAsync(Guid recipeId, Guid mealId);
        Task<IEnumerable<RecipeMeal>> GetRecipesByMealAsync(Guid mealId);
    }
}
