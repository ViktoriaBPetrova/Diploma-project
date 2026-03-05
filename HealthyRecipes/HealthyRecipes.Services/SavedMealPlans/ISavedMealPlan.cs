using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.SavedMealPlans
{
    public interface ISavedMealPlan
    {
        Task SaveMealPlanAsync(Guid userId, Guid mealPlanId);
        Task<bool> UnsaveMealPlanAsync(Guid userId, Guid mealPlanId);
        Task<IEnumerable<SavedMealPlan>> GetSavedMealPlansByUserAsync(Guid userId);
        Task<bool> IsMealPlanSavedAsync(Guid userId, Guid mealPlanId);
    }
}
