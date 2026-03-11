using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.MealPlans.Models;

namespace HealthyRecipes.Services.MealPlans
{
    public interface IMealPlan
    {
        Task<MealPlan?> GetByIdAsync(Guid id);
        Task<IEnumerable<MealPlan>> GetMealPlansByUserAsync(Guid userId);
        Task<Guid> CreateMealPlanAsync(MealPlan mealPlan);
        Task<bool> UpdateMealPlanAsync(MealPlan mealPlan);
        Task<bool> SoftDeleteAsync(Guid id);
        Task<bool> RestoreMealPlanAsync(Guid id);
        Task RecalculateNutritionalTotalsAsync(Guid mealPlanId);
        Task<(List<MealPlan> MealPlans, int TotalCount)> GetFilteredMealPlansAsync(MealPlanFilterDto filter);
    }
}
