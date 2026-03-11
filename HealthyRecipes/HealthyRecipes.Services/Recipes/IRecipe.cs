using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Recipes.Models;

namespace HealthyRecipes.Services.Recipes
{
    public interface IRecipe
    {

        Task<Guid> CreateRecipeAsync(Recipe recipe);


        Task<Recipe?> GetRecipeByIdAsync(Guid id);


        Task<bool> UpdateRecipeAsync(Recipe recipe);


        Task<IEnumerable<Recipe>> GetAllRecipesAsync(bool includeDeleted = false);


        Task<bool> RecalculateRecipeNutritionAsync(Guid id);

        Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate);

        Task<(List<Recipe> Recipes, int TotalCount)> GetFilteredRecipesAsync(RecipeFilterDto filter);

        Task<bool> SoftDeleteRecipeAsync(Guid id);

        Task<bool> RestoreRecipeAsync(Guid id);
    }
}
