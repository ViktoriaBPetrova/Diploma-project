using HealthyRecipes.Data.Seeding.Constants.Identity;
using Microsoft.AspNetCore.Identity;

namespace HealthyRecipes.Data.Seeding.Identity
{
    public static class RoleSeeder
    {
        public static IEnumerable<IdentityRole<Guid>> GenerateRoles()
        {
            IEnumerable<IdentityRole<Guid>> roles = new List<IdentityRole<Guid>>()
            {
                // Admin Role
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse(RoleConstants.AdminRoleId),
                    Name = RoleConstants.AdminRoleName,
                    NormalizedName = RoleConstants.AdminRoleNormalized,
                    ConcurrencyStamp = RoleConstants.AdminRoleConcurrencyStamp
                },
                
                // User Role
                new IdentityRole<Guid>
                {
                    Id = Guid.Parse(RoleConstants.UserRoleId),
                    Name = RoleConstants.UserRoleName,
                    NormalizedName = RoleConstants.UserRoleNormalized,
                    ConcurrencyStamp = RoleConstants.UserRoleConcurrencyStamp
                }
            };

            return roles;
        }
    }
}
