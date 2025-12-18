using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class SavedRecipe
    {
        public SavedRecipe()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }
        public SavedRecipe(string recipeId, string userId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            RecipeId = Guid.Parse(recipeId);
            UserId = Guid.Parse(userId);
        }
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
