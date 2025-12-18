using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class RecipeCategory
    {
        public RecipeCategory()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }
        public RecipeCategory(string recipeId, string categoryId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            RecipeId = Guid.Parse(recipeId);
            CategoryId = Guid.Parse(categoryId);
        }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; } 
    }
}
