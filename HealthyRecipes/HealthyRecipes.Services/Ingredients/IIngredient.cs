using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Services.Ingredients
{
    /// <summary>
    /// Interface for Ingredient service operations.
    /// </summary>
    public interface IIngredient
    {
        /// <summary>
        /// Creates a new ingredient.
        /// </summary>
        Task<Guid> CreateIngredientAsync(Ingredient ingredient);

        /// <summary>
        /// Retrieves an ingredient by ID.
        /// </summary>
        Task<Ingredient?> GetIngredientByIdAsync(Guid id);

        /// <summary>
        /// Retrieves all ingredients.
        /// </summary>
        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false);

        /// <summary>
        /// Retrieves ingredients by their source (User-created vs API).
        /// </summary>
        Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source);

        /// <summary>
        /// Updates an existing ingredient.
        /// </summary>
        Task<bool> UpdateIngredientAsync(Ingredient ingredient);

        /// <summary>
        /// Soft deletes an ingredient.
        /// </summary>
        Task<bool> SoftDeleteIngredientAsync(Guid id);

        /// <summary>
        /// Restores a soft-deleted ingredient.
        /// </summary>
        Task<bool> RestoreIngredientAsync(Guid id);
    }
}
