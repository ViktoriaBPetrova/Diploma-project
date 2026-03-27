using HealthyRecipes.Web.ViewModels.MealPlanFollower;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class TodaysMealsViewModel
    {
        public int CurrentDayNumber { get; set; }
        public Data.Enums.DayOfWeek DayOfWeek { get; set; }
        public Guid MealPlanDayId { get; set; }

        // Daily nutrition
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        public IEnumerable<TodaysMealItemViewModel> Meals { get; set; } = new List<TodaysMealItemViewModel>();

        public bool HasDayEntry { get; set; } = false;
        public string? DayOverallFeeling { get; set; }
        public DateTime? DayCompletedAt { get; set; }
    }
}
