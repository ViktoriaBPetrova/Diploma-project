using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class Recipe
    {
        public Recipe()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RecipeCategories  = new List<RecipeCategory>();
            CommentRatings  = new List<CommentRating>();
            RecipeIngredients  = new List<RecipeIngredient>();
            RecipeMeals = new List<RecipeMeal>();
            SavedRecipes = new List<SavedRecipe>();
        }
        public Recipe(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }
        public Recipe(DateTime createdAt, Guid id, float cal, float fat, float carbs, float protein) : this(createdAt, id)
        {
            Calories = cal;
            Fat = fat;
            Carbs = carbs;
            Protein = protein;
        }

        // ---------- Primary Key ----------
        public Guid Id { get; init; } 

        // ---------- Foreign Key & Navigation ----------
        public Guid UserId { get; set; }
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
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; }
        public IEnumerable<CommentRating> CommentRatings { get; set; } 
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } 
        public IEnumerable<RecipeMeal> RecipeMeals { get; set; } 
        public IEnumerable<SavedRecipe> SavedRecipes { get; set; } 


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } 
        public DateTime UpdatedAt { get; set; } 


        // ---------- Methods ----------
        /*
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

        */

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
