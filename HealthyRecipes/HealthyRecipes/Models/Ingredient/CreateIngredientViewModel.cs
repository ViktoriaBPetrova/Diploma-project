using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.Ingredient
{
    public class CreateIngredientViewModel
    {
        [Required, MaxLength(200)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string? Brand { get; set; }

        [Required, Range(0, 900)]
        public float CaloriesPer100g { get; set; }

        [Required, Range(0, 100)]
        public float ProteinPer100g { get; set; }

        [Required, Range(0, 100)]
        public float CarbsPer100g { get; set; }

        [Required, Range(0, 100)]
        public float FatPer100g { get; set; }
    }
}
