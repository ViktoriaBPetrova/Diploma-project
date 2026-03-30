using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Ingredients.Models;

namespace HealthyRecipes.Services.Ingredients
{
    public interface IIngredient
    {

        Task<Ingredient?> CreateIngredientAsync(Ingredient ingredient);


        Task<Ingredient?> GetIngredientByIdAsync(Guid id);

        Task<Ingredient?> GetIngredientByNameAsync(string name);
        Task<IEnumerable<Ingredient>> SearchIngredientAsync(string searchTerm);

        Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source);

        Task<bool> UpdateIngredientAsync(Ingredient ingredient);


        Task<bool> SoftDeleteIngredientAsync(Guid id);

        Task<bool> RestoreIngredientAsync(Guid id);

        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false);

        Task<(IEnumerable<Ingredient> ingredients, int totalCount)> GetFilteredIngredientsWithApiAsync(
             IngredientFilterDto filter);

        Task<IEnumerable<Ingredient>> SearchIngredientsWithApiAsync(
    string searchTerm,
    int maxResults = 10,
    Guid? userId = null);

    }
}
