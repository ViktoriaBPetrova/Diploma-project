using HealthyRecipes.Services.GroceryLists.Models;

namespace HealthyRecipes.Services.GroceryLists
{
    public interface IGroceryList
    {
        Task<GroceryListDto> GenerateGroceryListForMealPlanAsync(Guid mealPlanId);
    }
}
