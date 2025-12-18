using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class RecipeIngredient
    {
        public RecipeIngredient()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }
        public RecipeIngredient(string recipeId, string ingredientId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            RecipeId = Guid.Parse(recipeId);
            IngredientId = Guid.Parse(ingredientId);
        }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public float QuantityInGrams { get; set; }

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; } 
        public DateTime UpdatedAt { get; set; } 
    }
}
