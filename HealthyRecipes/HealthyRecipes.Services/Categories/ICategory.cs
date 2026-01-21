using HealthyRecipes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Categories
{
    public interface ICategory
    {
        Task<Guid> CreateCategoryAsync(Category category); // c
        Task<Category?> GetCategoryByIdAsync(Guid id); // r
        Task<bool> UpdateCategoryAsync(Category category); // u
        Task<bool> SoftDeleteCategoryAsync(Guid id); // d
        Task<IEnumerable<Category>> GetAllCategoriesAsync(bool includeDeleted = false);

    }
}
