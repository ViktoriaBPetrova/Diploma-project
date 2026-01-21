using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Recipes
{
    public interface IRecipe
    {
        Task<Guid> CreateRecipeAsync(Recipe recipe); // c
        Task<Recipe?> GetRecipeByIdAsync(Guid id); // r
        Task<bool> UpdateRecipeAsync(Recipe recipe); // u
        Task<bool> SoftDeleteRecipeAsync(Guid id); // d
        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeDeleted = false);
        Task<bool> RestoreRecipeAsync(Guid id);
        Task<bool> RecalculateRecipeNutritionAsync(Guid id);

        Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate);


    }
}
