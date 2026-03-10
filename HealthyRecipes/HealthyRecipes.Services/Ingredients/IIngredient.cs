using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Services.Ingredients
{
    public interface IIngredient
    {

        Task<Guid> CreateIngredientAsync(Ingredient ingredient);


        Task<Ingredient?> GetIngredientByIdAsync(Guid id);


        Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false);


        Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source);

        Task<bool> UpdateIngredientAsync(Ingredient ingredient);


        Task<bool> SoftDeleteIngredientAsync(Guid id);

        Task<bool> RestoreIngredientAsync(Guid id);
    }
}
