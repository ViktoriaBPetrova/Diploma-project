namespace HealthyRecipes.Services.Recommendations.NewFolder
{
    public class RecipeRecommendationDto
    {
        public Guid RecipeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int PrepTime { get; set; }
        public int Servings { get; set; }

        // Macros
        public decimal Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fats { get; set; }

        // Recommendation metadata
        public double Score { get; set; }
        public string RecommendationReason { get; set; } = string.Empty;
        public List<string> Categories { get; set; } = new();

        // User context
        public bool IsSaved { get; set; }
        public bool HasUserRated { get; set; }
        public double? AverageRating { get; set; }
    }
}
