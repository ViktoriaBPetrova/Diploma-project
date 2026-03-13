using HealthyRecipes.Data.Seeding.Constants.Identity;
using HealthyRecipes.Data.Seeding.Constants;
using Microsoft.AspNetCore.Identity;

namespace HealthyRecipes.Data.Seeding.Identity
{
    public static class UserRoleSeeder
    {
        public static IEnumerable<IdentityUserRole<Guid>> GenerateUserRoles()
        {
            IEnumerable<IdentityUserRole<Guid>> userRoles = new List<IdentityUserRole<Guid>>()
            {
                // Assign Admin role to admin user
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.AdminUserId),
                    RoleId = Guid.Parse(RoleConstants.AdminRoleId)
                },
                
                // Assign User role to regular user
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.UserId),
                    RoleId = Guid.Parse(RoleConstants.UserRoleId)
                }
            };

            return userRoles;
        }
    }
}
