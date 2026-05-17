using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class IngredientMeal
    {
        public IngredientMeal()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }
        public IngredientMeal(string ingredientId, string mealId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            IngredientId = Guid.Parse(ingredientId);
            MealId = Guid.Parse(mealId);
        }
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;

        public float QuantityInGrams { get; set; }

        // Alternative measurements (nullable - only set if explicitly specified)
        public float? QuantityInTeaspoons { get; set; }
        public float? QuantityInTablespoons { get; set; }
        public float? QuantityInCups { get; set; }
        public float? QuantityInCoffeeCups { get; set; }
        public float? QuantityInMillilitres { get; set; }

        // Store which unit was originally entered
        public string? OriginalUnit { get; set; }

        public Guid MealId { get; set; }
        public Meal Meal { get; set; } = null!;

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
