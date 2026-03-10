using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Categories
{
    public interface ICategory
    {

        Task<Guid> CreateCategoryAsync(Category category);

        Task<Category?> GetCategoryByIdAsync(Guid id);


        Task<bool> UpdateCategoryAsync(Category category);

        Task<bool> SoftDeleteCategoryAsync(Guid id);

        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool includeDeleted = false);

        Task<bool> RestoreCategoryAsync(Guid id);
    }
}
