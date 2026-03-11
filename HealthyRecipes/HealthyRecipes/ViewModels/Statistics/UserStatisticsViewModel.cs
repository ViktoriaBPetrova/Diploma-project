namespace HealthyRecipes.Web.ViewModels.Statistics
{
    public class UserStatisticsViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        
        // Content creation statistics
        public int RecipesCreatedCount { get; set; }
        public int MealPlansCreatedCount { get; set; }
        public int IngredientsCreatedCount { get; set; }
        public int CategoriesCreatedCount { get; set; }
        
        // Engagement received
        public int TotalRecipeSaves { get; set; }
        public int TotalMealPlanSaves { get; set; }
        public int TotalCommentsReceived { get; set; }
        public double AverageRecipeRating { get; set; }
        
        // Most popular content
        public Guid? MostPopularRecipeId { get; set; }
        public string? MostPopularRecipeTitle { get; set; }
        public int MostPopularRecipeSaveCount { get; set; }
        
        public Guid? MostPopularMealPlanId { get; set; }
        public string? MostPopularMealPlanName { get; set; }
        public int MostPopularMealPlanSaveCount { get; set; }
        
        // Display helpers
        public int TotalContentCreated => RecipesCreatedCount + MealPlansCreatedCount;
        public int TotalEngagement => TotalRecipeSaves + TotalMealPlanSaves + TotalCommentsReceived;
        
        public string AverageRatingDisplay => AverageRecipeRating > 0 
            ? AverageRecipeRating.ToString("F1") 
            : "No ratings yet";
        
        public bool HasMostPopularRecipe => MostPopularRecipeId.HasValue;
        public bool HasMostPopularMealPlan => MostPopularMealPlanId.HasValue;
    }
}
