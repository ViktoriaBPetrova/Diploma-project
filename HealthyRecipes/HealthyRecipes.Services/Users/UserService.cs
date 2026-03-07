using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Users
{
    public class UserService : IUser
    {
        private readonly HealthyRecipesDbContext _context;

        public UserService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(Guid id)
        {
            return await _context.Users
                .Include(u => u.Allergies)
                    .ThenInclude(a => a.Ingredient)
                .Include(u => u.CommentRatings)
                    .ThenInclude(cr => cr.Recipe)
                .Include(u => u.SavedRecipes)
                    .ThenInclude(sr => sr.Recipe)
                .Include(u => u.SavedMealPlans)
                    .ThenInclude(smp => smp.MealPlan)
                .Include(u => u.CreatedCategories)
                .Include(u => u.CreatedRecipes)
                .Include(u => u.CreatedMealPlans)
                .Include(u => u.CreatedIngredients)
                .FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool includeDeleted = false)
        {
            return await _context.Users
                .Where(u => includeDeleted || !u.Deleted)
                .OrderBy(u => u.UserName)
                .ToListAsync();
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == user.Id && !u.Deleted);

            if (existing == null)
                return false;

            existing.FirstName   = user.FirstName;
            existing.LastName    = user.LastName;
            existing.Bio         = user.Bio;
            existing.Height      = user.Height;
            existing.Weight      = user.Weight;
            existing.ImageUrl    = user.ImageUrl;
            existing.ProteinGoal = user.ProteinGoal;
            existing.CarbsGoal   = user.CarbsGoal;
            existing.FatGoal     = user.FatGoal;
            existing.Calories    = user.Calories;
            existing.UpdatedAt   = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteUserAsync(Guid id)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);

            if (existing == null)
                return false;

            existing.Deleted   = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RestoreUserAsync(Guid id)
        {
            var existing = await _context.Users
                .FirstOrDefaultAsync(u => u.Id == id && u.Deleted);

            if (existing == null)
                return false;

            existing.Deleted   = false;
            existing.DeletedAt = null;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
