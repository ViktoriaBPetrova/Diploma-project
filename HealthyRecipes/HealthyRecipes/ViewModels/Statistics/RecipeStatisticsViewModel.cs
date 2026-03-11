namespace HealthyRecipes.Web.ViewModels.Statistics
{
    public class RecipeStatisticsViewModel
    {
        public Guid RecipeId { get; set; }
        public string RecipeTitle { get; set; } = string.Empty;
        
        // Core statistics
        public int SaveCount { get; set; }
        public int CommentCount { get; set; }
        public double AverageRating { get; set; }
        public int RatingCount { get; set; }
        public int MealPlanUsageCount { get; set; }
        
        // Display helpers
        public string AverageRatingDisplay => AverageRating > 0 
            ? AverageRating.ToString("F1") 
            : "No ratings yet";
        
        public string RatingStars
        {
            get
            {
                if (AverageRating == 0) return "☆☆☆☆☆";
                
                var fullStars = (int)Math.Floor(AverageRating);
                var hasHalfStar = (AverageRating - fullStars) >= 0.5;
                var emptyStars = 5 - fullStars - (hasHalfStar ? 1 : 0);
                
                return new string('★', fullStars) + 
                       (hasHalfStar ? "½" : "") + 
                       new string('☆', emptyStars);
            }
        }
    }
}
