using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {

        // ---------- Basic Info ----------
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Bio { get; private set; } 
        public float? Height { get; private set; }  // cm
        public float? Weight { get; private set; }  // kg

        // ---------- Goals ----------
        public float? ProteinGoal { get; private set; }
        public float? CarbsGoal { get; private set; }
        public float? FatGoal { get; private set; }

        public float? Calories { get; private set; }

        // ---------- Navigation Collections ----------

        // (Many-toMany)
        public IEnumerable<Allergy> Allergies { get; set; } = new List<Allergy>();
        public IEnumerable<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();
        public IEnumerable<SavedMealPlan> SavedMealPlans { get; set; } = new List<SavedMealPlan>();
        public IEnumerable<CommentRating> CommentRatings { get; set; } = new List<CommentRating>();


        // (One-to-Many)
        public IEnumerable<Category> CreatedCategories { get; set; } = new List<Category>();
        public IEnumerable<Recipe> CreatedRecipes { get; set; } = new List<Recipe>();
        public IEnumerable<Ingredient> CreatedIngredients { get; set; } = new List<Ingredient>();
        public IEnumerable<MealPlan> CreatedMealPlans { get; set; } = new List<MealPlan>();

        // ---------- Metadata ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null;
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ---------- Methods ----------

        ///NOT READY
        /// <summary>
        /// Updates the name of the meal plan safely.
        /// Ignores empty or whitespace input.
        /// Updates the UpdatedAt timestamp automatically.
        /*public void UpdateName(string? newFirstName = null, string? newLastName = null)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.");

            FirstName = newFirstName.Trim();
            FirstName = newFirstName.Trim();

            if (newFirstName != null)
            {
                if (calories.Value >= 0)
                {
                    CaloriesPer100g = calories.Value;
                }
                else
                {
                    throw new ArgumentException("Calories cannot be negative.");
                }
            }

            UpdatedAt = DateTime.UtcNow;

        }*/

        /// <summary>
        /// Updates the description of the meal plan safely.
        /// can set null.
        /// Updates the UpdatedAt timestamp automatically.
        public void UpdateBio(string? newBio)
        {

            if (string.IsNullOrWhiteSpace(newBio))
            {
                Bio = null;
            }
            else
            {
                Bio = Bio;
            }
            
            UpdatedAt = DateTime.UtcNow;
        }

        ///NOT READY
        /// methods for changing wheight, haight, goals

        /// <summary>
        /// Soft-deletes the ingredient.
        /// </summary>
        public void SoftDelete()
        {
            Deleted = true;
            DeletedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Restores a previously soft-deleted ingredient.
        /// </summary>
        public void Restore()
        {
            Deleted = false;
            DeletedAt = null;
        }
    }
}
