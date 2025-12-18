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
        public float Calories { get; private set; }
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }


        // ---------- Navigation Collections ----------
        public IEnumerable<MealPlanDay> MealPlanDays { get; set; }

        //(Many-to-Many)
        public IEnumerable<SavedMealPlan> SavedMealPlans { get; set; }



        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }


        // ---------- Methods ----------
        /*
        /// <summary>
        /// Updates the name of the meal plan safely.
        /// Ignores empty or whitespace input.
        /// Updates the UpdatedAt timestamp automatically.
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.");

            Name = newName.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the description of the meal plan safely.
        /// Trims whitespace; can set null.
        /// Updates the UpdatedAt timestamp automatically.
        public void UpdateDescription(string? newDescription)
        {

            if (string.IsNullOrWhiteSpace(newDescription))
            {
                Description = null;
            }
            else
            {
                Description = Description.Trim();
            }
            UpdatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Recalculates the total macronutrients based on the mealPlanDays.
        /// Updates Calories, Protein, Carbs, and Fat.
        /// </summary>
        public void RecalculateNutrition()
        {
            float calories = 0f;
            float protein = 0f;
            float carbs = 0f;
            float fat = 0f;

            foreach (MealPlanDay mealPlanDay in MealPlanDays)
            {
                if (mealPlanDay != null)
                {
                    calories += mealPlanDay.Calories;
                    protein += mealPlanDay.Protein;
                    carbs += mealPlanDay.Carbs;
                    fat += mealPlanDay.Fat;
                }
            }

            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;

            UpdatedAt = DateTime.UtcNow;
        }*/

        /// <summary>
        /// Soft deletes the the meal plan.
        /// </summary>
        public void SoftDelete()
        {
            Deleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Restores a previously soft deleted meal plan.
        /// </summary>
        public void Restore()
        {
            Deleted = false;
            DeletedAt = null;
        }
    }
}
