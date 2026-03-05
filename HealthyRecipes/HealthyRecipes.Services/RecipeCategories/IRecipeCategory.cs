using HealthyRecipes.Data.Entities.MappingEntities;

namespace HealthyRecipes.Services.RecipeCategories
{
    public interface IRecipeCategory
    {
        Task AddCategoryToRecipeAsync(Guid recipeId, Guid categoryId);
        Task<bool> RemoveCategoryFromRecipeAsync(Guid recipeId, Guid categoryId);
        Task<IEnumerable<RecipeCategory>> GetCategoriesByRecipeAsync(Guid recipeId);
        Task<IEnumerable<RecipeCategory>> GetRecipesByCategoryAsync(Guid categoryId);
    }
}
