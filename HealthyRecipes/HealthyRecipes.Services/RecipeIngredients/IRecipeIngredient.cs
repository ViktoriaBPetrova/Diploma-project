using HealthyRecipes.Data.Entities.MappingEntities;

public interface IRecipeIngredient
{
    Task AddIngredientToRecipeAsync(Guid recipeId, Guid ingredientId, float quantity, string unit);
    Task<bool> UpdateQuantityAsync(Guid recipeId, Guid ingredientId, float quantity, string unit);
    float ConvertToGrams(float quantity, string unit);
    float ConvertFromGrams(float grams, string unit);
    string FormatQuantity(float? quantity, string? unit);
    Task<bool> RemoveIngredientFromRecipeAsync(Guid recipeId, Guid ingredientId);
    Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipeAsync(Guid recipeId);
}