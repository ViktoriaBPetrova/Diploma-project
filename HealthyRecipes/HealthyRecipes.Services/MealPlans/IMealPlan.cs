using HealthyRecipes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.MealPlans
{
    public interface IMealPlan
    {
        // Basic CRUD
        Task<MealPlan?> GetByIdAsync(Guid id);
        Task<IEnumerable<MealPlan>> GetAllMealPlansAsync(Guid userId);
        Task<Guid> CreateMealPlanAsync(MealPlan mealPlan);
        Task<bool> UpdateMealPlanAsync(MealPlan mealPlan);
        Task<bool> SoftDeleteAsync(Guid id);

        // Business Logic
        Task RecalculateNutritionalTotalsAsync(Guid mealPlanId);
    }
}
