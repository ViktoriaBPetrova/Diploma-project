using Microsoft.AspNetCore.Http.HttpResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class Allergy
    {
        public Allergy()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            
        }
        public Allergy(string ingredientId, string userId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            IngredientId = Guid.Parse(ingredientId);
            UserId = Guid.Parse(userId);
        }
        
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
