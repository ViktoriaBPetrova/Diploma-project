using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Categories
{
    /// <summary>
    /// Interface for Category service operations.
    /// </summary>
    public interface ICategory
    {
        /// <summary>
        /// Creates a new category.
        /// </summary>
        Task<Guid> CreateCategoryAsync(Category category);

        /// <summary>
        /// Retrieves a category by ID.
        /// </summary>
        Task<Category?> GetCategoryByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing category.
        /// </summary>
        Task<bool> UpdateCategoryAsync(Category category);

        /// <summary>
        /// Soft deletes a category.
        /// </summary>
        Task<bool> SoftDeleteCategoryAsync(Guid id);

        /// <summary>
        /// Retrieves all categories.
        /// </summary>
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool includeDeleted = false);

        /// <summary>
        /// Restores a soft-deleted category.
        /// </summary>
        Task<bool> RestoreCategoryAsync(Guid id);
    }
}
