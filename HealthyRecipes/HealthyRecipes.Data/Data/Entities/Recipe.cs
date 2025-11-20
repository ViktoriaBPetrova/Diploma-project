using HealthyRecipes.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class Recipe
    {
        // ---------- Primary Key ----------
        public Guid Id { get; init; } = Guid.NewGuid();

        // ---------- Foreign Key & Navigation ----------
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!; // required nav property

        // ---------- Core Data ----------
        public string Info { get; set; } = null!; // description, max length attribute can be added
        public float Calories { get; private set; }
        public float Protein { get; private set; }
        public float Carbs { get; private set; }
        public float Fat { get; private set; }

        public int? PrepTime { get; set; }      // nullable
        public Difficulty? Difficulty { get; set; } // nullable

        // ---------- Navigation Collections ----------
        //(Many-to-many)
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();
        public IEnumerable<CommentRating> CommentRatings { get; set; } = new List<CommentRating>();
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public IEnumerable<RecipeMeal> RecipeMeals { get; set; } = new List<RecipeMeal>();
        public IEnumerable<SavedRecipe> SavedRecipes { get; set; } = new List<SavedRecipe>();


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // ---------- Methods ----------
        /// <summary>
        /// Recalculates the nutritional values based on IngredientsRecipes.
        /// Call this before saving the Recipe whenever ingredients change.
        /// </summary>
        public void RecalculateNutrition()
        {
            Calories = RecipeIngredients.Sum(ir => ir.Ingredient.CaloriesPer100g * ir.QuantityInGrams);
            Protein = RecipeIngredients.Sum(ir => ir.Ingredient.ProteinPer100g * ir.QuantityInGrams);
            Carbs = RecipeIngredients.Sum(ir => ir.Ingredient.CarbsPer100g * ir.QuantityInGrams);
            Fat = RecipeIngredients.Sum(ir => ir.Ingredient.FatPer100g * ir.QuantityInGrams);
        }

        /// <summary>
        /// Updates the info of the recipe safely.
        /// Does not ignore empty or whitespaces
        /// Updates the UpdatedAt timestamp automatically.
        public void UpdateInfo(string newInfo)
        {
            if (string.IsNullOrWhiteSpace(newInfo))
                throw new ArgumentException("Info cannot be empty.");

            Info = newInfo;
            UpdatedAt = DateTime.UtcNow;
        }

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
