using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class TodaysMealItemViewModel
    {
        public Guid MealId { get; set; }
        public MealType Type { get; set; }

        // Meal nutrition
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        // Recipes in this meal
        public IEnumerable<MealRecipeItemViewModel> Recipes { get; set; } = new List<MealRecipeItemViewModel>();

        // Journal status 
        public bool HasEntry { get; set; } = false;
        public string? FeelingComment { get; set; }
        public string? PhotoUrl { get; set; }
        public DateTime? ConsumedAt { get; set; }
    }
}
