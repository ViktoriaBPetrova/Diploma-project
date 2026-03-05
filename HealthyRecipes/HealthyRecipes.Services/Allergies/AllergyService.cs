using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Allergies
{
    public class AllergyService : IAllergy
    {
        private readonly HealthyRecipesDbContext _context;

        public AllergyService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task AddAllergyAsync(Guid userId, Guid ingredientId)
        {
            var existing = await _context.Allergies
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IngredientId == ingredientId);

            if (existing != null)
            {
                // Restore if previously soft-deleted
                if (existing.Deleted)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.UpdatedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return; // Already exists and active
            }

            _context.Allergies.Add(new Allergy
            {
                UserId = userId,
                IngredientId = ingredientId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Allergy>> GetAllergiesByUserAsync(Guid userId)
        {
            return await _context.Allergies
                .Include(a => a.Ingredient)
                .Where(a => a.UserId == userId && !a.Deleted)
                .ToListAsync();
        }

        public async Task<bool> RemoveAllergyAsync(Guid userId, Guid ingredientId)
        {
            var existing = await _context.Allergies
                .FirstOrDefaultAsync(a => a.UserId == userId && a.IngredientId == ingredientId && !a.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> HasAllergyAsync(Guid userId, Guid ingredientId)
        {
            return await _context.Allergies
                .AnyAsync(a => a.UserId == userId && a.IngredientId == ingredientId && !a.Deleted);
        }
    }
}
