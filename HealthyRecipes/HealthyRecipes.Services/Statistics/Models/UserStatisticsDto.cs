namespace HealthyRecipes.Services.Statistics.Models
{
    public class UserStatisticsDto
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
    }
}
