using HealthyRecipes.Data.Entities.MappingEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class MealPlanDay
    {
        public MealPlanDay()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Meals = new List<Meal>();

        }
        public MealPlanDay(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public MealPlanDay(DateTime createdAt, Guid id, float cal, float fat, float carbs, float protein) : this(createdAt, id)
        {
            Calories = cal;
            Fat = fat;
            Carbs = carbs;
            Protein = protein;
        }

        // ---------- Primary Key ----------
        public Guid Id { get; init; } 

        // ---------- Properties ----------
        // Reference to the meal plan this day belongs to
        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; } = null!;

        // Day of week (enum)
        public DayOfWeek DayOfWeek { get; /*private*/ set; } = DayOfWeek.Monday; // change back later

        // nutrition totals (private set)
        public float Calories { get; private set; }
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }

        // List of meals for this day
        public IEnumerable<Meal> Meals { get; set; }

        // Day number in the meal plan
        public int DayNumber { get; /*private*/ set; } // chnge back later

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } 
        public DateTime UpdatedAt { get; set; }

        // ---------- Methods ----------

        /*
        /// <summary>
        /// Recalculates the total macronutrients based on the meals.
        /// Updates Calories, Protein, Carbs, and Fat.
        /// </summary>
        public void RecalculateNutrition()
        {
            float totalCalories = 0;
            float totalProtein = 0;
            float totalCarbs = 0;
            float totalFat = 0;

            foreach (Meal meal in Meals)
            {
                
                totalCalories += meal.Calories;
                totalProtein += meal.Protein;
                totalCarbs += meal.Carbs;
                totalFat += meal.Fat;         
            }

            Calories = totalCalories;
            Protein = totalProtein;
            Carbs = totalCarbs;
            Fat = totalFat;

            UpdatedAt = DateTime.UtcNow;
        }
        */

        /// <summary>
        /// Soft deletes the day from the meal plan.
        /// </summary>
        public void SoftDelete()
        {
            Deleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Restores a previously soft deleted day.
        /// </summary>
        public void Restore()
        {
            Deleted = false;
            DeletedAt = null;
        }
    }
}
