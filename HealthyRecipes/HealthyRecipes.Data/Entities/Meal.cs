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
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }

        // Navigation to mapping table (meal → recipes)
        public IEnumerable<RecipeMeal> RecipeMeals { get; set; }


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }


        // ---------- Methods ----------

        /*
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
        */

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
