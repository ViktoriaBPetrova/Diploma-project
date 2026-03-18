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
            // Regular user - John Doe
                new ApplicationUser(seedingDate)
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
                    PhoneNumberConfirmed = true,
                    PasswordHash = UserConstants.UserPasswordHash,
                    ConcurrencyStamp = UserConstants.UserConcurrencyStamp
                },

                // Admin user - Anna Stone
                new ApplicationUser(seedingDate)
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
                    PhoneNumberConfirmed = true,
                    PasswordHash = UserConstants.AdminPasswordHash,
                    ConcurrencyStamp = UserConstants.AdminConcurrencyStamp
                },

                // User 2 - Sarah Johnson (Yoga instructor)
                new ApplicationUser(seedingDate)
                {
                    Id = Guid.Parse(UserConstants.User2Id),
                    FirstName = UserConstants.User2FirstName,
                    LastName = UserConstants.User2LastName,
                    Bio = UserConstants.User2Bio,
                    Height = UserConstants.User2Height,
                    Weight = UserConstants.User2Weight,
                    ProteinGoal = UserConstants.User2ProteinGoal,
                    CarbsGoal = UserConstants.User2CarbsGoal,
                    FatGoal = UserConstants.User2FatGoal,
                    Calories = UserConstants.User2Calories,
                    UserName = UserConstants.User2Username,
                    NormalizedUserName = UserConstants.User2Username.ToUpper(),
                    Email = UserConstants.User2Email,
                    NormalizedEmail = UserConstants.User2Email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = UserConstants.User2SecurityStamp,
                    PhoneNumber = UserConstants.User2PhoneNumber,
                    PhoneNumberConfirmed = true,
                    PasswordHash = UserConstants.User2PasswordHash,
                    ConcurrencyStamp = UserConstants.User2ConcurrencyStamp
                },

                // User 3 - Mike Williams (Marathon runner)
                new ApplicationUser(seedingDate)
                {
                    Id = Guid.Parse(UserConstants.User3Id),
                    FirstName = UserConstants.User3FirstName,
                    LastName = UserConstants.User3LastName,
                    Bio = UserConstants.User3Bio,
                    Height = UserConstants.User3Height,
                    Weight = UserConstants.User3Weight,
                    ProteinGoal = UserConstants.User3ProteinGoal,
                    CarbsGoal = UserConstants.User3CarbsGoal,
                    FatGoal = UserConstants.User3FatGoal,
                    Calories = UserConstants.User3Calories,
                    UserName = UserConstants.User3Username,
                    NormalizedUserName = UserConstants.User3Username.ToUpper(),
                    Email = UserConstants.User3Email,
                    NormalizedEmail = UserConstants.User3Email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = UserConstants.User3SecurityStamp,
                    PhoneNumber = UserConstants.User3PhoneNumber,
                    PhoneNumberConfirmed = true,
                    PasswordHash = UserConstants.User3PasswordHash,
                    ConcurrencyStamp = UserConstants.User3ConcurrencyStamp
                },

                // User 4 - Emma Davis (Nutritionist)
                new ApplicationUser(seedingDate)
                {
                    Id = Guid.Parse(UserConstants.User4Id),
                    FirstName = UserConstants.User4FirstName,
                    LastName = UserConstants.User4LastName,
                    Bio = UserConstants.User4Bio,
                    Height = UserConstants.User4Height,
                    Weight = UserConstants.User4Weight,
                    ProteinGoal = UserConstants.User4ProteinGoal,
                    CarbsGoal = UserConstants.User4CarbsGoal,
                    FatGoal = UserConstants.User4FatGoal,
                    Calories = UserConstants.User4Calories,
                    UserName = UserConstants.User4Username,
                    NormalizedUserName = UserConstants.User4Username.ToUpper(),
                    Email = UserConstants.User4Email,
                    NormalizedEmail = UserConstants.User4Email.ToUpper(),
                    EmailConfirmed = true,
                    SecurityStamp = UserConstants.User4SecurityStamp,
                    PhoneNumber = UserConstants.User4PhoneNumber,
                    PhoneNumberConfirmed = true,
                    PasswordHash = UserConstants.User4PasswordHash,
                    ConcurrencyStamp = UserConstants.User4ConcurrencyStamp
                }
            };
            return users;
        }

    }
}
