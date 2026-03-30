using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.User_Info;

namespace HealthyRecipes.Services.SavedIngredients
{
    public interface ISavedIngredient
    {
        Task SaveIngredientAsync(Guid userId, Guid ingredientId);
        Task<bool> UnsaveIngredientAsync(Guid userId, Guid ingredientId);
        Task<IEnumerable<SavedIngredient>> GetSavedIngredientsByUserAsync(Guid userId);
        Task<bool> IsIngredientSavedAsync(Guid userId, Guid ingredientId);
    }
}
