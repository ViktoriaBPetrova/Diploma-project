namespace HealthyRecipes.Services.Recommendations.Models
{
    public class MealPlanRecommendationDto
    {
        public Guid MealPlanId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DurationDays { get; set; }

        // Aggregated macros (daily average)
        public decimal AvgDailyCalories { get; set; }
        public decimal AvgDailyProtein { get; set; }
        public decimal AvgDailyCarbs { get; set; }
        public decimal AvgDailyFats { get; set; }

        // Popularity metrics
        public int FollowerCount { get; set; }
        public int CompletionCount { get; set; }
        public double CompletionRate { get; set; }

        // Recommendation metadata
        public double Score { get; set; }
        public string RecommendationReason { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();

        // User context
        public bool IsFollowing { get; set; }
        public bool HasCompleted { get; set; }
    }
}
