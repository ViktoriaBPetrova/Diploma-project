namespace HealthyRecipes.Web.ViewModels.Statistics
{
    public class MealPlanStatisticsViewModel
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = string.Empty;
        
        // Core statistics
        public int SaveCount { get; set; }
        public int ActiveFollowerCount { get; set; }
        public double CompletionRate { get; set; }
        
        // Display helpers
        public string CompletionRateDisplay => CompletionRate > 0 
            ? $"{CompletionRate:F1}%" 
            : "N/A";
        
        public string PopularityLevel
        {
            get
            {
                if (SaveCount == 0) return "New";
                if (SaveCount < 5) return "Growing";
                if (SaveCount < 20) return "Popular";
                return "Very Popular";
            }
        }
    }
}
