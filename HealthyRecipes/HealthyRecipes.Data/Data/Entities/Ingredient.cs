using HealthyRecipes.Data.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class Ingredient
    {
        // ---------- Primary Key ----------
        public Guid Id { get; init; } = Guid.NewGuid();

        // ---------- Core Data ----------
        public string Name { get; private set; } = null!;  // required
        public string? Brand { get; private set; }         // optional - if not store-bought

        // ---------- Nutritional Values ----------
        public float CaloriesPer100g { get; private set; }
        public float ProteinPer100g { get; private set; }
        public float CarbsPer100g { get; private set; }
        public float FatPer100g { get; private set; }

        // ---------- Source & Ownership ----------
        public Source Source { get; init; } = Source.Global;

        // Nullable if not created by a user - from api, created by admin
        public string? CreatedByUserId { get; set; }
        public ApplicationUser? User { get; set; }

        // ---------- Navigation Collections ----------
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();
        public IEnumerable<Allergy> Allergies { get; set; } = new List<Allergy>();


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;


        // ---------- Methods ----------

        /// <summary>
        /// Private set for changing nutri-values for ingredients.
        /// </summary>
        public void UpdateNutrition(
            float? calories = null,
            float? protein = null,
            float? carbs = null,
            float? fat = null)
        {

            if (calories != null)
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

            if (protein != null)
            {
                if (protein.Value >= 0)
                {
                    ProteinPer100g = protein.Value;
                }
                else
                {
                    throw new ArgumentException("Protein cannot be negative.");
                }
            }

            if (carbs != null)
            {
                if (carbs.Value >= 0)
                {
                    CarbsPer100g = carbs.Value;
                }
                else
                {
                    throw new ArgumentException("Carbs cannot be negative.");
                }
            }

            if (fat != null)
            {
                if (fat.Value >= 0)
                {
                    FatPer100g = fat.Value;
                }
                else
                {
                    throw new ArgumentException("Fat cannot be negative.");
                }
            }

            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the name of the ingredient.
        /// </summary>
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.");

            Name = newName.Trim();
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Updates the brand of the ingredient.
        /// </summary>
        public void UpdateBrand(string? newBrand)
        {
            // Brand can be null or empty for generic ingredients
            
            if (string.IsNullOrWhiteSpace(newBrand))
            {
                Brand = null;
            }
            else
            {
                Brand = newBrand.Trim();
            }
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
