using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.SavedMealPlans
{
    public class SavedMealPlanService : ISavedMealPlan
    {
        private readonly HealthyRecipesDbContext _context;

        public SavedMealPlanService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task SaveMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            var existing = await _context.SavedMealPlans
                .FirstOrDefaultAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId);

            if (existing != null)
            {
                if (existing.Deleted)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.UpdatedAt = DateTime.UtcNow;
                    await _context.SaveChangesAsync();
                }
                return; // Already saved and active
            }

            _context.SavedMealPlans.Add(new SavedMealPlan
            {
                UserId = userId,
                MealPlanId = mealPlanId
            });

            await _context.SaveChangesAsync();
        }

        public async Task<bool> UnsaveMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            var existing = await _context.SavedMealPlans
                .FirstOrDefaultAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId && !smp.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<SavedMealPlan>> GetSavedMealPlansByUserAsync(Guid userId)
        {
            return await _context.SavedMealPlans
                .Include(smp => smp.MealPlan)
                    .ThenInclude(mp => mp.MealPlanDays)
                .Where(smp => smp.UserId == userId && !smp.Deleted)
                .OrderByDescending(smp => smp.CreatedAt)
                .ToListAsync();
        }

        public async Task<bool> IsMealPlanSavedAsync(Guid userId, Guid mealPlanId)
        {
            return await _context.SavedMealPlans
                .AnyAsync(smp => smp.UserId == userId && smp.MealPlanId == mealPlanId && !smp.Deleted);
        }
    }
}
