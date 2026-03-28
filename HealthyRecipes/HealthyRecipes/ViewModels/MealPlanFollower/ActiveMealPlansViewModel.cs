using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower
{
    public class ActiveMealPlansViewModel
    {
        public IEnumerable<MealPlanFollowerItemViewModel> ActivePlans { get; set; } = new List<MealPlanFollowerItemViewModel>();
        public IEnumerable<MealPlanFollowerItemViewModel> CompletedPlans { get; set; } = new List<MealPlanFollowerItemViewModel>();
        public IEnumerable<MealPlanFollowerItemViewModel> PausedPlans { get; set; } = new List<MealPlanFollowerItemViewModel>();
        public IEnumerable<MealPlanFollowerItemViewModel> DroppedPlans { get; set; } = new List<MealPlanFollowerItemViewModel>();
    }

    public class MealPlanFollowerItemViewModel
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = null!;
        public string? MealPlanDescription { get; set; }
        public int DaysCount { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? DroppedAt { get; set; }
        public DateTime? PausedAt { get; set; }

        public MealPlanFollowerStatus Status { get; set; }
        public string? DropoutReason { get; set; }
        public string? PauseReason { get; set; }

        public bool IsActive { get; set; }
        public int DaysFollowing { get; set; }
        public string CreatorName { get; set; } = null!;
    }
}
