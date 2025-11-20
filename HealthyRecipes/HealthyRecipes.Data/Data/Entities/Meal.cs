using HealthyRecipes.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class Meal
    {
        // ---------- Primary Key ----------
        public Guid Id { get; init; } = Guid.NewGuid();


        // ---------- Relationships ----------
        public Guid MealPlanDayId { get; set; }
        public MealPlanDay MealPlanDay { get; set; } = null!;


        // ---------- Properties ----------
        // Meal type (breakfast, lunch, dinner, snack)
        public MealType Type { get; private set; } = MealType.Breakfast;

        // macronutrients
        public float Calories { get; private set; }
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }

        // Navigation to mapping table (meal → recipes)
        public IEnumerable<RecipeMeal> RecipeMeals { get; set; } = new List<RecipeMeal>();


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // ---------- Methods ----------

        /// <summary>
        /// Recalculates the cached nutrition using MealRecipes → Recipes.
        /// </summary>
        public void RecalculateNutrition()
        {
            float calories = 0f;
            float protein = 0f;
            float carbs = 0f;
            float fat = 0f;

            foreach (RecipeMeal mealRecipe in RecipeMeals)
            {
                if (mealRecipe?.Recipe != null)
                {
                    calories += mealRecipe.Recipe.Calories;
                    protein += mealRecipe.Recipe.Protein;
                    carbs += mealRecipe.Recipe.Carbs;
                    fat += mealRecipe.Recipe.Fat;
                }
            }

            Calories = calories;
            Protein = protein;
            Carbs = carbs;
            Fat = fat;

            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Changes the type of the meal (Breakfast, Lunch, Dinner, Snack).
        /// </summary>
        public void ChangeType(MealType newType)
        {
            if (!Enum.IsDefined(typeof(MealType), newType))
                throw new ArgumentException("Invalid meal type.");

            Type = newType;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Soft deletes the meal.
        /// </summary>
        public void SoftDelete()
        {
            //if (Deleted) return;

            Deleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Restores the meal from soft delete.
        /// </summary>
        public void Restore()
        {
            //if (!Deleted) return;

            Deleted = false;
            DeletedAt = null;
        }

    }
}
