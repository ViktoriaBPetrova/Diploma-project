using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class SavedMealPlan
    {
        public SavedMealPlan()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;

        }
        public SavedMealPlan(string userId, string mealPlanId, DateTime createdAt)
        {
            CreatedAt = UpdatedAt = createdAt;
            MealPlanId = Guid.Parse(mealPlanId);
            UserId = Guid.Parse(userId);
        }
        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
