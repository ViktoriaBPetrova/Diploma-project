using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class MealPlanDay
    {
        // ---------- Primary Key ----------
        public Guid Id { get; init; } = Guid.NewGuid();

        // ---------- Properties ----------
        // Reference to the meal plan this day belongs to
        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; } = null!;

        // Day of week (enum)
        public DayOfWeek DayOfWeek { get; private set; } = DayOfWeek.Monday;

        // nutrition totals (private set)
        public float Calories { get; private set; }
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }

        // List of meals for this day
        public IEnumerable<Meal> Meals { get; set; } = new List<Meal>();

        // Day number in the meal plan
        public int DayNumber { get; private set; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ---------- Methods ----------

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
