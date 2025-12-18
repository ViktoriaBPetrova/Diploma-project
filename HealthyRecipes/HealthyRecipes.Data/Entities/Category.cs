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
        public string Name { get; private set; } = null!;


        // Nullable if not created by a user - created by admin
        public Guid? CreatedBy { get; set; }
        public ApplicationUser? User { get; set; }


        // ---------- Navigation Collections ----------
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; }


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }

        // ---------- Methods ----------

        /*
        /// <summary>
        /// Updates the name of the category.
        /// </summary>
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.");

            Name = newName.Trim();
            UpdatedAt = DateTime.UtcNow;
        }*/

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
