namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class MealRecipeViewModel
    {
        public Guid RecipeId { get; set; }
        public string Info { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }
    }
}
