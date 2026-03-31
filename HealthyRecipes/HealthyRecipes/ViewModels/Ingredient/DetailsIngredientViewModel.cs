namespace HealthyRecipes.Web.Models.Ingredient
{
    public class DetailsIngredientViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Brand { get; set; }
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }
        public string Source { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string? CreatedByUserName { get; set; }
        public bool IsCurrentUserCreator { get; set; }
        public bool IsAllergen { get; set; }
        public bool IsSaved { get; set; }
        public bool IsDeleted { get; set; }
        
        // Related data
        public int RecipeCount { get; set; }
        public IEnumerable<string> RecipeNames { get; set; } = new List<string>();
    }
}
