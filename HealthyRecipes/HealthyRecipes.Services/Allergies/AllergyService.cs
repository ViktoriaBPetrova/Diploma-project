using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Allergies
{
    public class AllergyService : IAllergy
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<AllergyService> _logger;

        public AllergyService(HealthyRecipesDbContext context, ILogger<AllergyService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddAllergyAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.Allergies
                    .FirstOrDefaultAsync(a => a.UserId == userId && a.IngredientId == ingredientId);

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

                _context.Allergies.Add(new Allergy { UserId = userId, IngredientId = ingredientId });
                await _context.SaveChangesAsync();
                _logger.LogInformation("Allergy added for user {UserId} to ingredient {IngredientId}", userId, ingredientId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding allergy");
                throw;
            }
        }

        public async Task<IEnumerable<Allergy>> GetAllergiesByUserAsync(Guid userId)
        {
            try
            {
                return await _context.Allergies
                    .Include(a => a.Ingredient)
                    .Where(a => a.UserId == userId && !a.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving allergies for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> RemoveAllergyAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.Allergies
                    .FirstOrDefaultAsync(a => a.UserId == userId && a.IngredientId == ingredientId && !a.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Allergy removed for user {UserId} from ingredient {IngredientId}", userId, ingredientId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing allergy");
                throw;
            }
        }

        public async Task<bool> HasAllergyAsync(Guid userId, Guid ingredientId)
        {
            try
            {
                return await _context.Allergies
                    .AnyAsync(a => a.UserId == userId && a.IngredientId == ingredientId && !a.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking allergy");
                throw;
            }
        }
    }
}
