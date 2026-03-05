using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.RecipeIngredients
{
    public interface IRecipeIngredient
    {
        Task AddIngredientToRecipeAsync(Guid recipeId, Guid ingredientId, float quantityInGrams);
        Task<bool> UpdateQuantityAsync(Guid recipeId, Guid ingredientId, float newQuantityInGrams);
        Task<bool> RemoveIngredientFromRecipeAsync(Guid recipeId, Guid ingredientId);
        Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipeAsync(Guid recipeId);
    }
}
