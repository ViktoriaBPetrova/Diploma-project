using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.Recipe
{
    public class RecipeIngredientInputViewModel
    {
        [Required]
        public Guid IngredientId { get; set; }

        [Required]
        [Range(0.1f, 10000f, ErrorMessage = "Quantity must be between 0.1 and 10000 grams")]
        public float QuantityInGrams { get; set; }

        // Store which unit was originally entered by the user
        public string? OriginalUnit { get; set; }

        // Optional measurement values - only the one the user entered will have a value
        public float? QuantityInTeaspoons { get; set; }
        public float? QuantityInTablespoons { get; set; }
        public float? QuantityInCups { get; set; }
        public float? QuantityInCoffeeCups { get; set; }
        public float? QuantityInMillilitres { get; set; }
    }
}