using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<IEnumerable<MealPlan>> GetUserMealPlansAsync(Guid userId)
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
            var existing = await _context.MealPlans.FindAsync(mealPlan.Id);
            if (existing == null || existing.Deleted) return false;

            // Update properties
            existing.Name = mealPlan.Name;
            existing.Description = mealPlan.Description;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            var mealPlan = await _context.MealPlans.FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
            if (mealPlan == null) return false;

            mealPlan.Deleted = true;
            mealPlan.DeletedAt = DateTime.UtcNow;

            _context.MealPlans.Update(mealPlan);//?
            await _context.SaveChangesAsync();
            return true;
        }

        // Logic to handle your 'private set' nutrition totals
        public async Task RecalculateNutritionalTotalsAsync(Guid mealPlanId)
        {
            var mealPlan = await _context.MealPlans
                .Include(m => m.MealPlanDays)
                .FirstOrDefaultAsync(m => m.Id == mealPlanId);

            if (mealPlan != null)
            {
                // You would sum up the nutrients from all MealPlanDays here
                // Example:
                // mealPlan.Calories = mealPlan.MealPlanDays.Sum(d => d.TotalCalories);

                mealPlan.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
            }
        }

        public Task<IEnumerable<MealPlan>> GetAllMealPlansAsync(Guid userId)
        {
            throw new NotImplementedException();
        }
    }
}
