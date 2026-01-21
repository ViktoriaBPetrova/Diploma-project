using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Categories
{
    public class CategoryService : ICategory
    {
        private readonly HealthyRecipesDbContext _context;

        public CategoryService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category.Id;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            return await _context.Categories
                .Include(c => c.RecipeCategories) //idk
                .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool includeDeleted = false)
        {
            return await _context.Categories
                .Include(c => c.RecipeCategories)
                .Where(c => includeDeleted || !c.Deleted) //idk
                .ToListAsync();
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            Category existing = await _context.Categories.FirstOrDefaultAsync(c => c.Id == category.Id && !c.Deleted);
            if (existing == null)
                return false;

            existing.UpdatedAt = DateTime.UtcNow;
            existing.Name = category.Name;

            _context.Categories.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteCategoryAsync(Guid id)
        {
            Category existing = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;

            _context.Categories.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
