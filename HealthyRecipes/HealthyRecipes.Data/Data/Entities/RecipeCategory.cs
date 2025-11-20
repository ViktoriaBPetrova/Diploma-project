using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class RecipeCategory
    {
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;
    }
}
