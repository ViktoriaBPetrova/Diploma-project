using HealthyRecipes.Web.ViewModels.MealPlan;

namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class MealPlanIndexViewModel
    {
        public IEnumerable<MealPlanCardViewModel> MyMealPlans { get; set; } = new List<MealPlanCardViewModel>();
        public IEnumerable<MealPlanCardViewModel> SavedMealPlans { get; set; } = new List<MealPlanCardViewModel>();
    }
}
