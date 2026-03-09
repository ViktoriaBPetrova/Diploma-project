using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Categories
{
    /// <summary>
    /// Service for managing Category entities.
    /// </summary>
    public class CategoryService : ICategory
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(
            HealthyRecipesDbContext context,
            ILogger<CategoryService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Category created: {CategoryName} (ID: {CategoryId})", 
                    category.Name, category.Id);
                return category.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating category: {CategoryName}", category.Name);
                throw;
            }
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid id)
        {
            try
            {
                return await _context.Categories
                    .Include(c => c.RecipeCategories)
                        .ThenInclude(rc => rc.Recipe)
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving category with ID: {CategoryId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync(bool includeDeleted = false)
        {
            try
            {
                return await _context.Categories
                    .Include(c => c.RecipeCategories)
                    .Include(c => c.User)
                    .Where(c => includeDeleted || !c.Deleted)
                    .OrderBy(c => c.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all categories");
                throw;
            }
        }

        public async Task<bool> UpdateCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            try
            {
                var existing = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == category.Id && !c.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Category with ID {CategoryId} not found for update", category.Id);
                    return false;
                }

                existing.Name = category.Name;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Categories.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Category {CategoryId} updated successfully", category.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating category with ID: {CategoryId}", category.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteCategoryAsync(Guid id)
        {
            try
            {
                var existing = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id && !c.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Category with ID {CategoryId} not found for deletion", id);
                    return false;
                }

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Categories.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Category {CategoryId} soft deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting category with ID: {CategoryId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreCategoryAsync(Guid id)
        {
            try
            {
                var existing = await _context.Categories
                    .FirstOrDefaultAsync(c => c.Id == id && c.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Deleted category with ID {CategoryId} not found for restoration", id);
                    return false;
                }

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Categories.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Category {CategoryId} restored successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring category with ID: {CategoryId}", id);
                throw;
            }
        }
    }
}
