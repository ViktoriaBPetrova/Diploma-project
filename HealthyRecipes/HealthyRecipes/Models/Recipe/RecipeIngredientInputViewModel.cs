using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.Models.Recipe
{
    public class RecipeIngredientInputViewModel
    {
        public Guid IngredientId { get; set; }

        [Range(0.1f, 10000f)]
        public float QuantityInGrams { get; set; }
    }
}
