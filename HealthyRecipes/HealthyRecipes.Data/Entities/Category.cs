using HealthyRecipes.Data.Entities.MappingEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Entities
{
    public class Category
    {
        public Category()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            RecipeCategories = new List<RecipeCategory>();
            MealPlanCategories = new List<MealPlanCategory>();
        }
        public Category(DateTime createdAt, Guid id) : this()
        {
            Id = id;
            CreatedAt = createdAt;
            UpdatedAt = createdAt;
            
        }

        public Category(DateTime createdAt, Guid id, string name) : this(createdAt, id)
        {
            Name = name;
        }

        // Primary key
        public Guid Id { get; init; }

        // Name of the category with validation
        public string Name { get; set; } = null!;


        // id of user or admin - if by api or created as seed - null
        public Guid? CreatedBy { get; set; }
        public ApplicationUser? User { get; set; }


        // ---------- Navigation Collections ----------
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; }
        public IEnumerable<MealPlanCategory> MealPlanCategories { get; set; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
