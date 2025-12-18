using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RecipeIngredients = new List<RecipeIngredient>();
            Allergies = new List<Allergy>();
        }
        public Ingredient(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
        }

        public Ingredient(DateTime createdAt, Guid id, float cal, float fat, float carbs, float protein) : this(createdAt, id)
        {
            CaloriesPer100g = cal;
            FatPer100g = fat;
            CarbsPer100g = carbs;
            ProteinPer100g = protein;
        }

        // ---------- Primary Key ----------
        public Guid Id { get; init; }

        // ---------- Core Data ----------
        public string Name { get; set; } = null!;  // required // private ste?
        public string? Brand { get; set; }         // optional - if not store-bought // private set?

        // ---------- Nutritional Values ----------
        public float CaloriesPer100g { get; private set; }
        public float ProteinPer100g { get; private set; }
        public float CarbsPer100g { get; private set; }
        public float FatPer100g { get; private set; }

        // ---------- Source & Ownership ----------
        public Source Source { get; init; } = Source.Global;

        // Nullable if not created by a user - from api, created by admin
        public Guid? CreatedByUserId { get; set; }
        public ApplicationUser? User { get; set; }

        // ---------- Navigation Collections ----------
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; } 
        public IEnumerable<Allergy> Allergies { get; set; } 


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }


        // ---------- Methods ----------
        /*
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
