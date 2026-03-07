using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.MealPlans
{
    public class MealPlanService : IMealPlan
    {
        private readonly HealthyRecipesDbContext _context;

        public MealPlanService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<MealPlan?> GetByIdAsync(Guid id)
        {
            return await _context.MealPlans
                .Include(m => m.MealPlanDays)
                .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
        }

        public async Task<IEnumerable<MealPlan>> GetMealPlansByUserAsync(Guid userId)
        {
            return await _context.MealPlans
                .Where(m => m.UserId == userId && !m.Deleted)
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();
        }

        public async Task<Guid> CreateMealPlanAsync(MealPlan mealPlan)
        {
            _context.MealPlans.Add(mealPlan);
            await _context.SaveChangesAsync();
            return mealPlan.Id;
        }

        public async Task<bool> UpdateMealPlanAsync(MealPlan mealPlan)
        {
            var existing = await _context.MealPlans
                .FirstOrDefaultAsync(m => m.Id == mealPlan.Id && !m.Deleted);

            if (existing == null)
                return false;

            existing.Name = mealPlan.Name;
            existing.Description = mealPlan.Description;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            var existing = await _context.MealPlans
                .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreMealPlanAsync(Guid id)
        {
            var existing = await _context.MealPlans
                .FirstOrDefaultAsync(m => m.Id == id && m.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task RecalculateNutritionalTotalsAsync(Guid mealPlanId)
        {
            var mealPlan = await _context.MealPlans
                .Include(m => m.MealPlanDays)
                .FirstOrDefaultAsync(m => m.Id == mealPlanId && !m.Deleted);

            if (mealPlan == null)
                return;

            var activeDays = mealPlan.MealPlanDays.Where(d => !d.Deleted).ToList();

            mealPlan.Calories = activeDays.Sum(d => d.Calories);
            mealPlan.Protein  = activeDays.Sum(d => d.Protein);
            mealPlan.Carbs    = activeDays.Sum(d => d.Carbs);
            mealPlan.Fat      = activeDays.Sum(d => d.Fat);
            mealPlan.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }
    }
}
