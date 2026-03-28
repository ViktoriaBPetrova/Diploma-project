namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class MealPlanDetailsViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
        public bool IsSaved { get; set; }
        public bool IsOwner { get; set; }
        public bool IsFollowing { get; set; }
        public IEnumerable<MealPlanDayViewModel> Days { get; set; } = new List<MealPlanDayViewModel>();

        // Follower Statistics
        public int ActiveFollowerCount { get; set; }
        public int CompletedFollowerCount { get; set; }
        public IEnumerable<CompletedUserViewModel> CompletedShowcase { get; set; } = new List<CompletedUserViewModel>();
    }

    /// <summary>
    /// Represents a user who completed the plan and consented to public display.
    /// </summary>
    public class CompletedUserViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = null!;
        public DateTime CompletedAt { get; set; }
        public bool HasPublicJournal { get; set; } // ShareJournalPublicly = true
    }
}
