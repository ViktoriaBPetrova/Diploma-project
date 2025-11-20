using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Data.Entities
{
    public class Category
    {
        // Primary key
        public Guid Id { get; init; } = Guid.NewGuid();

        // Name of the category with validation
        public string Name { get; private set; } = null!;


        // Nullable if not created by a user - created by admin
        public string? CreatedBy { get; set; }
        public ApplicationUser? User { get; set; }


        // ---------- Navigation Collections ----------
        public IEnumerable<RecipeCategory> RecipeCategories { get; set; } = new List<RecipeCategory>();


        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }


        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // ---------- Methods ----------

        /// <summary>
        /// Updates the name of the category.
        /// </summary>
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty.");

            Name = newName.Trim();
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
