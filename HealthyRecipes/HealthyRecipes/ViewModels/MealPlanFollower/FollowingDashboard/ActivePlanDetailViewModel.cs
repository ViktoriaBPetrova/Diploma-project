namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class ActivePlanDetailViewModel
    {
        public Guid MealPlanId { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }

        // Duration & Progress
        public int TotalDays { get; set; }
        public int DaysFollowing { get; set; }
        public int DaysRemaining { get; set; }
        public float ProgressPercentage { get; set; }

        // Dates
        public DateTime StartedAt { get; set; }
        public DateTime ExpectedCompletionDate { get; set; }
        public bool IsOverdue { get; set; }

        // Nutrition totals
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        // Creator info
        public string CreatorName { get; set; } = null!;
    }
}
