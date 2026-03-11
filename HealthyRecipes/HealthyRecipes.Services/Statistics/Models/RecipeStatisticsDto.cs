namespace HealthyRecipes.Services.Statistics.Models
{
    public class RecipeStatisticsDto
    {
        public Guid RecipeId { get; set; }
        public string RecipeTitle { get; set; } = string.Empty;
        
        // Core statistics
        public int SaveCount { get; set; }
        public int CommentCount { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public int MealPlanUsageCount { get; set; }
        
        // Optional - requires tracking implementation
        public int? ViewCount { get; set; }
    }
}
