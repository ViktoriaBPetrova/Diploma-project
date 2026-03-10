using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Ingredients
{
    public class IngredientService : IIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly IApi _apiService;
        private readonly ILogger<IngredientService> _logger;

        public IngredientService(
            HealthyRecipesDbContext context,
            IApi apiService,
            ILogger<IngredientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            try
            {
                _context.Ingredients.Add(ingredient);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient created: {IngredientName} (ID: {IngredientId})", 
                    ingredient.Name, ingredient.Id);
                return ingredient.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating ingredient: {IngredientName}", ingredient.Name);
                throw;
            }
        }

        public async Task<Ingredient?> GetIngredientByIdAsync(Guid id)
        {
            try
            {
                return await _context.Ingredients
                    .Include(i => i.RecipeIngredients)
                    .Include(i => i.Allergies)
                    .Include(i => i.User)
                    .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient with ID: {IngredientId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync(bool includeDeleted = false)
        {
            try
            {
                return await _context.Ingredients
                    .Include(i => i.RecipeIngredients)
                    .Include(i => i.User)
                    .Where(i => includeDeleted || !i.Deleted)
                    .OrderBy(i => i.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all ingredients");
                throw;
            }
        }

        public async Task<IEnumerable<Ingredient>> GetIngredientsBySourceAsync(Source source)
        {
            try
            {
                return await _context.Ingredients
                    .Where(i => i.Source == source && !i.Deleted)
                    .OrderBy(i => i.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients by source: {Source}", source);
                throw;
            }
        }

        public async Task<bool> UpdateIngredientAsync(Ingredient ingredient)
        {
            if (ingredient == null)
                throw new ArgumentNullException(nameof(ingredient));

            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == ingredient.Id && !i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Ingredient with ID {IngredientId} not found for update", ingredient.Id);
                    return false;
                }

                existing.Name = ingredient.Name;
                existing.Brand = ingredient.Brand;
                existing.CaloriesPer100g = ingredient.CaloriesPer100g;
                existing.ProteinPer100g = ingredient.ProteinPer100g;
                existing.CarbsPer100g = ingredient.CarbsPer100g;
                existing.FatPer100g = ingredient.FatPer100g;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} updated successfully", ingredient.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient with ID: {IngredientId}", ingredient.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteIngredientAsync(Guid id)
        {
            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == id && !i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Ingredient with ID {IngredientId} not found for deletion", id);
                    return false;
                }

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} soft deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting ingredient with ID: {IngredientId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreIngredientAsync(Guid id)
        {
            try
            {
                var existing = await _context.Ingredients
                    .FirstOrDefaultAsync(i => i.Id == id && i.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Deleted ingredient with ID {IngredientId} not found for restoration", id);
                    return false;
                }

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;

                _context.Ingredients.Update(existing);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Ingredient {IngredientId} restored successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring ingredient with ID: {IngredientId}", id);
                throw;
            }
        }
    }
}
