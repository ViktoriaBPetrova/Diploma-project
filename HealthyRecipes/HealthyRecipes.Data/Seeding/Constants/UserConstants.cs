using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants
{
    public class UserConstants
    {       
        // ---------- IDs ----------
        public const string UserId = "e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01";
        public const string AdminUserId = "b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02";

        // ---------- Username / Email ----------
        public const string Username = "user@email.com";
        public const string AdminUsername = "admin@email.com";

        public const string Email = "user@email.com";
        public const string AdminEmail = "admin@email.com";

        // ---------- Security ----------
        public const string UserSecurityStamp = "a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d";
        public const string AdminSecurityStamp = "d6c5b4a3-2f1e-0d9c-8b7a-6e5f4d3c2b1a";

        // ---------- Phone number ---------- //same
        public const string PhoneNumber = "0897123456";

        // ---------- Password ---------- // same for both
        public const string Password = "123456";

        // ---------- Names ----------
        public const string UserFirstName = "John";
        public const string UserLastName = "Doe";
        public const string AdminFirstName = "Anna";
        public const string AdminLastName = "Stone";

        // ---------- Bios ----------
        public const string UserBio = "Fitness enthusiast";
        public const string AdminBio = "System administrator";

        // ---------- Stats ----------
        public const float UserHeight = 180;
        public const float UserWeight = 80;

        public const float UserProteinGoal = 150;
        public const float UserCarbsGoal = 300;
        public const float UserFatGoal = 60;
        public const float UserCalories = 2500;

        public const float AdminHeight = 167;
        public const float AdminWeight = 60;

        public const float AdminProteinGoal = 100;
        public const float AdminCarbsGoal = 250;
        public const float AdminFatGoal = 70;
        public const float AdminCalories = 2000;

    }
}
