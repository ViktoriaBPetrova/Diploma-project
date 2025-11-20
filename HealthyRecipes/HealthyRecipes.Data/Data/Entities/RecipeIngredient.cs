using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class RecipeIngredient
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;
        public float QuantityInGrams { get; set; } 
    }
}
