namespace HealthyRecipes.Web.ViewModels.MealPlanFollower.FollowingDashboard
{
    public class MealRecipeItemViewModel
    {
        public Guid RecipeId { get; set; }
        public string Name { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public int? PrepTime { get; set; }

        
        // Nutrition
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
    }
}
