namespace HealthyRecipes.Web.Models.Recipe
{
    public class RecipeIngredientViewModel
    {
        public string IngredientName { get; set; } = null!;
        public float QuantityInGrams { get; set; }
        public float Calories => IngredientCaloriesPer100g * QuantityInGrams / 100f;
        public float IngredientCaloriesPer100g { get; set; }
        public bool IsAllergen { get; set; }
    }
}
