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
                 // Assign Admin role to admin user (Anna Stone)
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.AdminUserId),
                    RoleId = Guid.Parse(RoleConstants.AdminRoleId)
                },
                
                // Assign User role to John Doe
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.UserId),
                    RoleId = Guid.Parse(RoleConstants.UserRoleId)
                },
 
                // Assign User role to Sarah Johnson
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.User2Id),
                    RoleId = Guid.Parse(RoleConstants.UserRoleId)
                },
 
                // Assign User role to Mike Williams
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.User3Id),
                    RoleId = Guid.Parse(RoleConstants.UserRoleId)
                },
 
                // Assign User role to Emma Davis
                new IdentityUserRole<Guid>
                {
                    UserId = Guid.Parse(UserConstants.User4Id),
                    RoleId = Guid.Parse(RoleConstants.UserRoleId)
                }
            };

            return userRoles;
        }
    }
}
