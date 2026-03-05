using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Meals
{
    public interface IMeal
    {
        Task<Guid> CreateMealAsync(Meal meal);
        Task<Meal?> GetMealByIdAsync(Guid id);
        Task<IEnumerable<Meal>> GetMealsByDayAsync(Guid mealPlanDayId);
        Task<bool> UpdateMealAsync(Meal meal);
        Task<bool> SoftDeleteMealAsync(Guid id);
        Task<bool> RestoreMealAsync(Guid id);
        Task<bool> RecalculateNutritionAsync(Guid mealId);
    }
}
