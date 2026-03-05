using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.SavedRecipes
{
    public interface ISavedRecipe
    {
        Task SaveRecipeAsync(Guid userId, Guid recipeId);
        Task<bool> UnsaveRecipeAsync(Guid userId, Guid recipeId);
        Task<IEnumerable<SavedRecipe>> GetSavedRecipesByUserAsync(Guid userId);
        Task<bool> IsRecipeSavedAsync(Guid userId, Guid recipeId);
    }
}
