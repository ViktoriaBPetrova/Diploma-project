namespace HealthyRecipes.Web.ViewModels.Ingredient
{
    public class IngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Brand { get; set; }
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }
        public bool IsAllergen { get; set; }
    }
}
