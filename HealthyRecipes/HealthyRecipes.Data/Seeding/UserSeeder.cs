using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public static class UserSeeder
    {
        public static IEnumerable<ApplicationUser> GenerateUsers()
        {
            DateTime seedingDate = new DateTime(2025, 4, 20);

            IEnumerable<ApplicationUser> users = new List<ApplicationUser>()
            {
            new ApplicationUser(seedingDate) // Regular user
            {
                Id = Guid.Parse(UserConstants.UserId),

                FirstName = UserConstants.UserFirstName,
                LastName = UserConstants.UserLastName,

                Bio = UserConstants.UserBio,

                Height = UserConstants.UserHeight,
                Weight = UserConstants.UserWeight,

                ProteinGoal = UserConstants.UserProteinGoal,
                CarbsGoal = UserConstants.UserCarbsGoal,
                FatGoal = UserConstants.UserFatGoal,
                Calories = UserConstants.UserCalories,

                UserName = UserConstants.Username,
                NormalizedUserName = UserConstants.Username.ToUpper(),

                Email = UserConstants.Email,
                NormalizedEmail = UserConstants.Email.ToUpper(),
                EmailConfirmed = true,

                SecurityStamp = UserConstants.UserSecurityStamp,

                PhoneNumber = UserConstants.PhoneNumber,
                PhoneNumberConfirmed = true
            },

            new ApplicationUser(seedingDate) // Admin user
            {
                Id = Guid.Parse(UserConstants.AdminUserId),

                FirstName = UserConstants.AdminFirstName,
                LastName = UserConstants.AdminLastName,

                Bio = UserConstants.AdminBio,

                Height = UserConstants.AdminHeight,
                Weight = UserConstants.AdminWeight,

                ProteinGoal = UserConstants.AdminProteinGoal,
                CarbsGoal = UserConstants.AdminCarbsGoal,
                FatGoal = UserConstants.AdminFatGoal,
                Calories = UserConstants.AdminCalories,

                UserName = UserConstants.AdminUsername,
                NormalizedUserName = UserConstants.AdminUsername.ToUpper(),

                Email = UserConstants.AdminEmail,
                NormalizedEmail = UserConstants.AdminEmail.ToUpper(),
                EmailConfirmed = true,

                SecurityStamp = UserConstants.AdminSecurityStamp,

                PhoneNumber = UserConstants.PhoneNumber,
                PhoneNumberConfirmed = true
            }
            };

            // Set password for all users (development only)
            var hasher = new PasswordHasher<ApplicationUser>();
            foreach (var user in users)
            {
                user.PasswordHash = hasher.HashPassword(user, UserConstants.Password);
            }

            return users;
        }

    }
}
