using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.User_Info;
using HealthyRecipes.Services.SavedIngredients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.SavedIngredients
{
    public class SavedIngredientService : ISavedIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<SavedIngredientService> _logger;

        public SavedIngredientService(HealthyRecipesDbContext context, ILogger<SavedIngredientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<SavedIngredient>> GetSavedIngredientsByUserAsync(Guid userId)
        {
            try
            {
                return await _context.SavedIngredients
                    .Include(si => si.Ingredient)
                        .ThenInclude(i => i.RecipeIngredients)
                            .ThenInclude(ri => ri.Recipe)
                    .Where(sr => sr.UserId == userId && !sr.Deleted)
                    .OrderByDescending(sr => sr.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving saved recipes for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> IsIngredientSavedAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                return await _context.SavedIngredients
                    .AnyAsync(sr => sr.UserId == userId && sr.IngredientId == ingredientId && !sr.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if recipe is saved");
                throw;
            }
        }

        public async Task SaveIngredientAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.SavedIngredients
                    .FirstOrDefaultAsync(sr => sr.UserId == userId && sr.IngredientId == ingredientId);

                if (existing != null)
                {
                    if (existing.Deleted)
                    {
                        existing.Deleted = false;
                        existing.DeletedAt = null;
                        existing.UpdatedAt = DateTime.UtcNow;
                        await _context.SaveChangesAsync();
                    }
                    return;
                }

                _context.SavedIngredients.Add(new SavedIngredient { UserId = userId, IngredientId = ingredientId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} saved by user {UserId}", ingredientId, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving ingredient");
                throw;
            }
        }

        public async Task<bool> UnsaveIngredientAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.SavedIngredients
                    .FirstOrDefaultAsync(sr => sr.UserId == userId && sr.IngredientId == ingredientId && !sr.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} unsaved by user {UserId}", ingredientId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error unsaving ingredient");
                throw;
            }
        }
    }
}
