using HealthyRecipes.Data.Entities.MappingEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class MealPlan
    {
        public MealPlan()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            MealPlanDays = new List<MealPlanDay>();
            SavedMealPlans = new List<SavedMealPlan>();
            MealPlanCategories = new List<MealPlanCategory>();
        }
        public MealPlan(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public MealPlan(DateTime createdAt, Guid id, float cal, float fat, float carbs, float protein) : this(createdAt, id)
        {
            Calories = cal;
            Fat = fat;
            Carbs = carbs;
            Protein = protein;
        }
        // ---------- Primary Key ----------
        public Guid Id { get; init; }


        // ---------- Properties ----------
        // User who created the meal plan
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;


        // Info for mealplan
        public string Name { get; set; } = null!;      
        public string? Description { get; set; }

        // Cached nutrition totals (private set)
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }


        // ---------- Navigation Collections ----------
        public IEnumerable<MealPlanDay> MealPlanDays { get; set; }

        //(Many-to-Many)
        public IEnumerable<SavedMealPlan> SavedMealPlans { get; set; }

        public IEnumerable<MealPlanCategory> MealPlanCategories { get; set; }


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }


        
    }
}
