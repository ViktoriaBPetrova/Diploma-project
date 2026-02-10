using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Recipes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Users
{
    public class UserService : IUser
    {
        private readonly HealthyRecipesDbContext _context;
        public UserService(HealthyRecipesDbContext context)
        {
            this._context = context;
        }

        public async Task<Guid> CreateUserAsync(ApplicationUser user)
        {
            _context.ApplicationUsers.Add(user);
            await _context.SaveChangesAsync();
            return user.Id;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool includeDeleted = false)
        {
            throw new NotImplementedException();
        }

        public async Task<ApplicationUser?> GetUserByIdAsync(Guid id)
        {
            return await _context.ApplicationUsers
               .Include(u => u.Allergies)
               .Include(r => r.CommentRatings)
               .Include(r => r.SavedRecipes)
               .Include(r => r.SavedMealPlans)
               .Include(r => r.CreatedCategories)
               .Include(r => r.CreatedRecipes)
               .Include(r => r.CreatedMealPlans)
               .Include(r => r.CreatedIngredients)
               .FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
        }

        public async Task<bool> RestoreUserAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SoftDeleteUserAsync(Guid id)
        {
            var existing = await _context.ApplicationUsers.FirstOrDefaultAsync(r => r.Id == id && !r.Deleted);
            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;

            _context.ApplicationUsers.Update(existing);//?
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
