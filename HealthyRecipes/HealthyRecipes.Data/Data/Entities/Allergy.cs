using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class Allergy
    {
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
