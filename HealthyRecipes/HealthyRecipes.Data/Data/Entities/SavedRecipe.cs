using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class SavedRecipe
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
    }
}
