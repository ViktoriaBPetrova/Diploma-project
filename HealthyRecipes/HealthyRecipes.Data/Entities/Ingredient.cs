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
        public string? BulgarianName { get; set; }

        // ---------- Nutritional Values ----------
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }

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

    }
}
