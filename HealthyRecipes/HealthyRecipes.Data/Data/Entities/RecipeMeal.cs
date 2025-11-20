using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class RecipeMeal
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid MealId { get; set; }
        public Meal Meal { get; set; } = null!;
    }
}
