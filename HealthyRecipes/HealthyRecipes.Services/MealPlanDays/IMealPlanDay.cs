using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.MealPlanDays
{
    public interface IMealPlanDay
    {
        Task<Guid> CreateMealPlanDayAsync(MealPlanDay mealPlanDay);
        Task<MealPlanDay?> GetMealPlanDayByIdAsync(Guid id);
        Task<IEnumerable<MealPlanDay>> GetDaysByMealPlanAsync(Guid mealPlanId);
        Task<bool> UpdateMealPlanDayAsync(MealPlanDay mealPlanDay);
        Task<bool> SoftDeleteMealPlanDayAsync(Guid id);
        Task<bool> RestoreMealPlanDayAsync(Guid id);
        Task<bool> RecalculateNutritionAsync(Guid mealPlanDayId);
    }
}
