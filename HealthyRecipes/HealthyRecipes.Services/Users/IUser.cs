using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.Users
{
    public interface IUser
    {
        Task<ApplicationUser?> GetUserByIdAsync(Guid id);
        Task<IEnumerable<ApplicationUser>> GetAllUsersAsync(bool includeDeleted = false);
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<bool> SoftDeleteUserAsync(Guid id);
        Task<bool> RestoreUserAsync(Guid id);
    }
}
