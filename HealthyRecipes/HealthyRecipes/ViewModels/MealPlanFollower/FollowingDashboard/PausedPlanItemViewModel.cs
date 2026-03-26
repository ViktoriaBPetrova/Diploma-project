namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class PausedPlanItemViewModel
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = null!;
        public string? MealPlanDescription { get; set; }
        public int DaysCount { get; set; }
        public DateTime PausedAt { get; set; }
        public string? PauseReason { get; set; }
        public string CreatorName { get; set; } = null!;

        // Nutrition
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
    }
}
