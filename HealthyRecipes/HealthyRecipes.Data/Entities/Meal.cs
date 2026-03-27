using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class Meal
    {
        public Meal()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RecipeMeals = new List<RecipeMeal>();
            MealEntries = new List<MealEntry>();

        }
        public Meal(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public Meal(DateTime createdAt, Guid id, float cal, float fat, float carbs, float protein) : this(createdAt, id)
        {
            Calories = cal;
            Fat = fat;
            Carbs = carbs;
            Protein = protein;
        }
        // ---------- Primary Key ----------
        public Guid Id { get; init; }


        // ---------- Relationships ----------
        public Guid MealPlanDayId { get; set; }
        public MealPlanDay MealPlanDay { get; set; } = null!;


        // ---------- Properties ----------
        // Meal type (breakfast, lunch, dinner, snack)
        public MealType Type { get; set; } = MealType.Breakfast;

        // macronutrients
        public float Calories { get; set; }
        public float Protein { get; set; }
        public float Carbs { get; set; }
        public float Fat { get; set; }

        // Navigation to mapping tables 
        public IEnumerable<RecipeMeal> RecipeMeals { get; set; }
        public IEnumerable<MealEntry> MealEntries { get; set; }


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }

    }
}
