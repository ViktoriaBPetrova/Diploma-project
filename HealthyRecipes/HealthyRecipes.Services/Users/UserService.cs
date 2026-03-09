using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Users
{
    public class UserService : IUser
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<UserService> _logger;

        public UserService(HealthyRecipesDbContext context, ILogger<UserService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(Guid id)
        {
            try
            {
                return await _context.Users
                    .Include(u => u.Allergies).ThenInclude(a => a.Ingredient)
                    .Include(u => u.CommentRatings).ThenInclude(cr => cr.Recipe)
                    .Include(u => u.SavedRecipes).ThenInclude(sr => sr.Recipe)
                    .Include(u => u.SavedMealPlans).ThenInclude(smp => smp.MealPlan)
                    .Include(u => u.CreatedCategories)
                    .Include(u => u.CreatedRecipes)
                    .Include(u => u.CreatedMealPlans)
                    .Include(u => u.CreatedIngredients)
                    .FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving user with ID: {UserId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool includeDeleted = false)
        {
            try
            {
                return await _context.Users
                    .Where(u => includeDeleted || !u.Deleted)
                    .OrderBy(u => u.UserName)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving all users");
                throw;
            }
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            if (user == null) throw new ArgumentNullException(nameof(user));
            try
            {
                var existing = await _context.Users.FirstOrDefaultAsync(u => u.Id == user.Id && !u.Deleted);
                if (existing == null) return false;

                existing.FirstName = user.FirstName;
                existing.LastName = user.LastName;
                existing.Bio = user.Bio;
                existing.Height = user.Height;
                existing.Weight = user.Weight;
                existing.ImageUrl = user.ImageUrl;
                existing.ProteinGoal = user.ProteinGoal;
                existing.CarbsGoal = user.CarbsGoal;
                existing.FatGoal = user.FatGoal;
                existing.Calories = user.Calories;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} updated", user.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating user: {UserId}", user.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteUserAsync(Guid id)
        {
            try
            {
                var existing = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && !u.Deleted);
                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} soft deleted", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting user: {UserId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreUserAsync(Guid id)
        {
            try
            {
                var existing = await _context.Users.FirstOrDefaultAsync(u => u.Id == id && u.Deleted);
                if (existing == null) return false;

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} restored", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring user: {UserId}", id);
                throw;
            }
        }
    }
}
