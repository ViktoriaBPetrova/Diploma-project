using HealthyRecipes.Services.Recommendations.Models;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecommendedRecipesViewModel
    {
        public List<RecipeRecommendationDto> PersonalizedRecipes { get; set; } = new();
        public List<RecipeRecommendationDto> ForYourGoals { get; set; } = new();
        public List<RecipeRecommendationDto> Trending { get; set; } = new();
        public List<RecipeRecommendationDto> Collaborative { get; set; } = new();
        public bool HasGoals { get; set; }
        public string? UserName { get; set; }
    }
}
