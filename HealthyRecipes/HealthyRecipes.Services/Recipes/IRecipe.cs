using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Recipes
{
    /// <summary>
    /// Interface for Recipe service operations.
    /// Provides full CRUD functionality with soft delete support and nutrition calculation.
    /// </summary>
    public interface IRecipe
    {
        /// <summary>
        /// Creates a new recipe.
        /// </summary>
        /// <param name="recipe">The recipe to create</param>
        /// <returns>The ID of the created recipe</returns>
        Task<Guid> CreateRecipeAsync(Recipe recipe);

        /// <summary>
        /// Retrieves a recipe by its ID.
        /// </summary>
        /// <param name="id">The recipe ID</param>
        /// <returns>The recipe if found and not deleted, otherwise null</returns>
        Task<Recipe?> GetRecipeByIdAsync(Guid id);

        /// <summary>
        /// Updates an existing recipe.
        /// </summary>
        /// <param name="recipe">The recipe with updated values</param>
        /// <returns>True if successful, false if recipe not found</returns>
        Task<bool> UpdateRecipeAsync(Recipe recipe);

        /// <summary>
        /// Soft deletes a recipe.
        /// </summary>
        /// <param name="id">The recipe ID to delete</param>
        /// <returns>True if successful, false if recipe not found</returns>
        Task<bool> SoftDeleteRecipeAsync(Guid id);

        /// <summary>
        /// Retrieves all recipes with optional inclusion of soft-deleted records.
        /// </summary>
        /// <param name="includeDeleted">Whether to include deleted recipes</param>
        /// <returns>Collection of recipes</returns>
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeDeleted = false);

        /// <summary>
        /// Restores a soft-deleted recipe.
        /// </summary>
        /// <param name="id">The recipe ID to restore</param>
        /// <returns>True if successful, false if recipe not found</returns>
        Task<bool> RestoreRecipeAsync(Guid id);

        /// <summary>
        /// Recalculates nutrition totals based on recipe ingredients.
        /// </summary>
        /// <param name="id">The recipe ID</param>
        /// <returns>True if successful, false if recipe not found</returns>
        Task<bool> RecalculateRecipeNutritionAsync(Guid id);

        /// <summary>
        /// Retrieves recipes matching a predicate.
        /// </summary>
        /// <param name="predicate">Filter predicate</param>
        /// <returns>Filtered recipes</returns>
        Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate);
    }
}
