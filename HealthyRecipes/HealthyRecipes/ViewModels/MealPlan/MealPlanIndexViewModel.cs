using HealthyRecipes.Web.ViewModels.MealPlan;

namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class MealPlanIndexViewModel
    {
        public IEnumerable<MealPlanCardViewModel> MyMealPlans { get; set; } = new List<MealPlanCardViewModel>();
        public IEnumerable<MealPlanCardViewModel> SavedMealPlans { get; set; } = new List<MealPlanCardViewModel>();
        public IEnumerable<MealPlanCardViewModel> BrowseAllMealPlans { get; set; } = new List<MealPlanCardViewModel>();

        // Filter & Pagination
        public List<MealPlanCategoryViewModel> Categories { get; set; } = new();
        public MealPlanFilterViewModel Filter { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
        public int TotalPages { get; set; }
    }
}
