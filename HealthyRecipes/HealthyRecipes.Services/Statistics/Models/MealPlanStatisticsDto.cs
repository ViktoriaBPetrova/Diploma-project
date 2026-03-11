namespace HealthyRecipes.Services.Statistics.Models
{
    public class MealPlanStatisticsDto
    {
        public Guid MealPlanId { get; set; }
        public string MealPlanName { get; set; } = string.Empty;
        
        // Core statistics
        public int SaveCount { get; set; }
        public int ActiveFollowerCount { get; set; }
        public double CompletionRate { get; set; }
        
        // Optional - requires additional tracking
        public int? ViewCount { get; set; }
    }
}
