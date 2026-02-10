using HealthyRecipes.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Users
{
    public interface IUser
    {
        Task<Guid> CreateUserAsync(ApplicationUser user); // c
        Task<ApplicationUser?> GetUserByIdAsync(Guid id); // r
        Task<bool> UpdateUserAsync(ApplicationUser user); // u
        Task<bool> SoftDeleteUserAsync(Guid id); // d
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool includeDeleted = false);
        Task<bool> RestoreUserAsync(Guid id);
        

        //Task<IEnumerable<Recipe>> GetRecipeAsync(Func<Recipe, bool> predicate);
    }
}
