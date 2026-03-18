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
        public const string User2Id = "c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12";
        public const string User3Id = "d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23";
        public const string User4Id = "e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34";

        // ---------- Username / Email ----------
        public const string Username = "user@email.com";
        public const string AdminUsername = "admin@email.com";
        public const string User2Username = "sarah.fitness@email.com";
        public const string User3Username = "mike.healthy@email.com";
        public const string User4Username = "emma.wellness@email.com";

        public const string Email = "user@email.com";
        public const string AdminEmail = "admin@email.com";
        public const string User2Email = "sarah.fitness@email.com";
        public const string User3Email = "mike.healthy@email.com";
        public const string User4Email = "emma.wellness@email.com";

        // ---------- Security ----------
        public const string UserSecurityStamp = "a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d";
        public const string AdminSecurityStamp = "d6c5b4a3-2f1e-0d9c-8b7a-6e5f4d3c2b1a";
        public const string User2SecurityStamp = "f8e7d6c5-4b3a-2f1e-0d9c-8b7a6e5f4d3c";
        public const string User3SecurityStamp = "a9b8c7d6-5e4f-3a2b-1c0d-9e8f7a6b5c4d";
        public const string User4SecurityStamp = "b1c2d3e4-6f7a-4b5c-2d3e-0f1a8b9c7d6e";

        // ---------- Phone number ----------
        public const string PhoneNumber = "0897123456";
        public const string User2PhoneNumber = "0898234567";
        public const string User3PhoneNumber = "0899345678";
        public const string User4PhoneNumber = "0897456789";

        // ---------- Password ----------
        public const string Password = "123456";

        // ---------- PasswordHash ----------
        public const string AdminPasswordHash = "AQAAAAIAAYagAAAAEDZoKDzNOFTI2VDaWN/Fs6od0Ie+BN4qIF2V4oopqWQRBgA56Rs8YTIG2uZISte5aw==";
        public const string UserPasswordHash = "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==";
        // Using the SAME hash for all new users
        public const string User2PasswordHash = "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg=="; // Same as UserPasswordHash
        public const string User3PasswordHash = "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==";
        public const string User4PasswordHash = "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==";

        // ---------- Concurrencystamp ----------
        public const string UserConcurrencyStamp = "67a287df-fd85-4a1c-8603-fb50a54ca624";
        public const string AdminConcurrencyStamp = "e4a36463-b39d-4ac6-b748-4d81e8e7e8e9";
        public const string User2ConcurrencyStamp = "a5b6c7d8-e9f1-4a2b-3c4d-5e6f7a8b9c0d";
        public const string User3ConcurrencyStamp = "b6c7d8e9-f1a2-4b3c-4d5e-6f7a8b9c0d1e";
        public const string User4ConcurrencyStamp = "c7d8e9f1-a2b3-4c4d-5e6f-7a8b9c0d1e2f";

        // ---------- Names ----------
        public const string UserFirstName = "John";
        public const string UserLastName = "Doe";
        public const string AdminFirstName = "Anna";
        public const string AdminLastName = "Stone";
        public const string User2FirstName = "Sarah";
        public const string User2LastName = "Johnson";
        public const string User3FirstName = "Mike";
        public const string User3LastName = "Williams";
        public const string User4FirstName = "Emma";
        public const string User4LastName = "Davis";

        // ---------- Bios ----------
        public const string UserBio = "Fitness enthusiast";
        public const string AdminBio = "System administrator";
        public const string User2Bio = "Yoga instructor and clean eating advocate. Love experimenting with plant-based recipes!";
        public const string User3Bio = "Marathon runner tracking macros for peak performance. Always looking for high-protein meal ideas.";
        public const string User4Bio = "Nutritionist helping people find balance. Believer in sustainable healthy habits, not extreme diets.";

        // ---------- Stats - User (John Doe) ----------
        public const float UserHeight = 180;
        public const float UserWeight = 80;
        public const float UserProteinGoal = 150;
        public const float UserCarbsGoal = 300;
        public const float UserFatGoal = 60;
        public const float UserCalories = 2500;

        // ---------- Stats - Admin (Anna Stone) ----------
        public const float AdminHeight = 167;
        public const float AdminWeight = 60;
        public const float AdminProteinGoal = 100;
        public const float AdminCarbsGoal = 250;
        public const float AdminFatGoal = 70;
        public const float AdminCalories = 2000;

        // ---------- Stats - User2 (Sarah Johnson) ----------
        public const float User2Height = 165;
        public const float User2Weight = 58;
        public const float User2ProteinGoal = 90;
        public const float User2CarbsGoal = 220;
        public const float User2FatGoal = 55;
        public const float User2Calories = 1800;

        // ---------- Stats - User3 (Mike Williams) ----------
        public const float User3Height = 185;
        public const float User3Weight = 78;
        public const float User3ProteinGoal = 180;
        public const float User3CarbsGoal = 350;
        public const float User3FatGoal = 65;
        public const float User3Calories = 2800;

        // ---------- Stats - User4 (Emma Davis) ----------
        public const float User4Height = 170;
        public const float User4Weight = 63;
        public const float User4ProteinGoal = 110;
        public const float User4CarbsGoal = 260;
        public const float User4FatGoal = 60;
        public const float User4Calories = 2100;

    }
}
