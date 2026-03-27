using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;

namespace HealthyRecipes.Data.Seeding.MealPlanSeeders
{
    /// <summary>
    /// Generates seed data for MealEntry entities.
    /// 
    /// Following relationships:
    /// - Sarah (User2) follows John's Lean Bulk Plan (completed, public - 13 entries across 5 days)
    /// - Mike (User3) follows Sarah's Plant-Based Week (dropped, private - 3 entries across 2 days)
    /// - Emma (User4) follows John's Lean Bulk Plan (active - 3 entries across 2 days)
    /// - John (User) follows Emma's Balanced Nutrition (active - 3 entries across 2 days)
    /// 
    /// Total: 22 meal entries
    /// </summary>
    public class MealEntrySeeder
    {
        public static IEnumerable<MealEntry> GenerateMealEntries()
        {
            // Seeding date - these are "logged" entries from the past
            DateTime seedingDate = new DateTime(2025, 4, 21);

            List<MealEntry> mealEntries = new List<MealEntry>()
            {
                // ========== SARAH FOLLOWING JOHN'S LEAN BULK PLAN ==========
                
                // Sarah - Day 1 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay1BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id), // Sarah
                    MealId = Guid.Parse(MealConstants.JohnDay1BreakfastId), // John's plan
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay1BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay1BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-10).AddHours(7).AddMinutes(30), // April 10, 7:30 AM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-10).AddHours(8),
                    UpdatedAt = seedingDate.AddDays(-10).AddHours(8)
                },
                
                // Sarah - Day 1 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay1LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay1LunchId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay1LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay1LunchEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-10).AddHours(13), // April 10, 1 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-10).AddHours(13).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-10).AddHours(13).AddMinutes(30)
                },
                
                // Sarah - Day 1 Dinner
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay1DinnerEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay1DinnerId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay1DinnerEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay1DinnerEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-10).AddHours(19), // April 10, 7 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-10).AddHours(19).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-10).AddHours(19).AddMinutes(30)
                },

                // Sarah - Day 2 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay2BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay2BreakfastId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay2BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay2BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-9).AddHours(7).AddMinutes(15), // April 11, 7:15 AM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-9).AddHours(7).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-9).AddHours(7).AddMinutes(45)
                },
                
                // Sarah - Day 2 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay2LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay2LunchId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay2LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay2LunchEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-9).AddHours(12).AddMinutes(45), // April 11, 12:45 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-9).AddHours(13).AddMinutes(15),
                    UpdatedAt = seedingDate.AddDays(-9).AddHours(13).AddMinutes(15)
                },

                // Sarah - Day 3 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay3BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay3BreakfastId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay3BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay3BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-8).AddHours(7).AddMinutes(45), // April 12, 7:45 AM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(8).AddMinutes(15),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(8).AddMinutes(15)
                },

                // Sarah - Day 3 Dinner
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay3DinnerEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay3DinnerId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay3DinnerEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay3DinnerEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-8).AddHours(19), // April 12, 7 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(19).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(19).AddMinutes(30)
                },

                // Sarah - Day 4 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay4BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay4BreakfastId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay4BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay4BreakfastEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-7).AddHours(7).AddMinutes(30), // April 13, 7:30 AM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-7).AddHours(8),
                    UpdatedAt = seedingDate.AddDays(-7).AddHours(8)
                },

                // Sarah - Day 4 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay4LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay4LunchId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay4LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay4LunchEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-7).AddHours(13), // April 13, 1 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-7).AddHours(13).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-7).AddHours(13).AddMinutes(30)
                },

                // Sarah - Day 5 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay5BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay5BreakfastId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay5BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay5BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-6).AddHours(7).AddMinutes(15), // April 14, 7:15 AM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-6).AddHours(7).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-6).AddHours(7).AddMinutes(45)
                },

                // Sarah - Day 5 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay5LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay5LunchId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay5LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay5LunchEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-6).AddHours(12).AddMinutes(30), // April 14, 12:30 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-6).AddHours(13),
                    UpdatedAt = seedingDate.AddDays(-6).AddHours(13)
                },

                // Sarah - Day 5 Dinner
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.SarahFollowingJohnDay5DinnerEntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealId = Guid.Parse(MealConstants.JohnDay5DinnerId),
                    FeelingComment = MealEntryConstants.SarahFollowingJohnDay5DinnerEntryFeeling,
                    PhotoUrl = MealEntryConstants.SarahFollowingJohnDay5DinnerEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-6).AddHours(19), // April 14, 7 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-6).AddHours(19).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-6).AddHours(19).AddMinutes(30)
                },

                // ========== MIKE FOLLOWING SARAH'S PLANT-BASED WEEK ==========
                
                // Mike - Day 1 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.MikeFollowingSarahDay1BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User3Id), // Mike
                    MealId = Guid.Parse(MealConstants.SarahDay1BreakfastId), // Sarah's plan
                    FeelingComment = MealEntryConstants.MikeFollowingSarahDay1BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.MikeFollowingSarahDay1BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-8).AddHours(6).AddMinutes(30), // April 12, 6:30 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(7),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(7)
                },
                
                // Mike - Day 1 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.MikeFollowingSarahDay1LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User3Id),
                    MealId = Guid.Parse(MealConstants.SarahDay1LunchId),
                    FeelingComment = MealEntryConstants.MikeFollowingSarahDay1LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.MikeFollowingSarahDay1LunchEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-8).AddHours(11).AddMinutes(30), // April 12, 11:30 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(12),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(12)
                },

                // Mike - Day 2 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.MikeFollowingSarahDay2BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User3Id),
                    MealId = Guid.Parse(MealConstants.SarahDay2BreakfastId),
                    FeelingComment = MealEntryConstants.MikeFollowingSarahDay2BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.MikeFollowingSarahDay2BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-7).AddHours(6).AddMinutes(15), // April 13, 6:15 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-7).AddHours(6).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-7).AddHours(6).AddMinutes(45)
                },

                // ========== EMMA FOLLOWING JOHN'S LEAN BULK PLAN ==========
                
                // Emma - Day 1 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.EmmaFollowingJohnDay1BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User4Id), // Emma
                    MealId = Guid.Parse(MealConstants.JohnDay1BreakfastId), // John's plan
                    FeelingComment = MealEntryConstants.EmmaFollowingJohnDay1BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.EmmaFollowingJohnDay1BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-3).AddHours(8).AddMinutes(15), // April 17, 8:15 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(8).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(8).AddMinutes(45)
                },
                
                // Emma - Day 1 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.EmmaFollowingJohnDay1LunchEntryId),
                    UserId = Guid.Parse(UserConstants.User4Id),
                    MealId = Guid.Parse(MealConstants.JohnDay1LunchId),
                    FeelingComment = MealEntryConstants.EmmaFollowingJohnDay1LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.EmmaFollowingJohnDay1LunchEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-3).AddHours(12).AddMinutes(30), // April 17, 12:30 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(13),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(13)
                },

                // Emma - Day 2 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.EmmaFollowingJohnDay2BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.User4Id),
                    MealId = Guid.Parse(MealConstants.JohnDay2BreakfastId),
                    FeelingComment = MealEntryConstants.EmmaFollowingJohnDay2BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.EmmaFollowingJohnDay2BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-2).AddHours(8), // April 18, 8 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-2).AddHours(8).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-2).AddHours(8).AddMinutes(30)
                },

                // ========== JOHN FOLLOWING EMMA'S BALANCED NUTRITION ==========
                
                // John - Day 1 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.JohnFollowingEmmaDay1BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.UserId), // John
                    MealId = Guid.Parse(MealConstants.EmmaDay1BreakfastId), // Emma's plan
                    FeelingComment = MealEntryConstants.JohnFollowingEmmaDay1BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.JohnFollowingEmmaDay1BreakfastEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-3).AddHours(7).AddMinutes(45), // April 17, 7:45 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(8).AddMinutes(15),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(8).AddMinutes(15)
                },
                
                // John - Day 1 Lunch
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.JohnFollowingEmmaDay1LunchEntryId),
                    UserId = Guid.Parse(UserConstants.UserId),
                    MealId = Guid.Parse(MealConstants.EmmaDay1LunchId),
                    FeelingComment = MealEntryConstants.JohnFollowingEmmaDay1LunchEntryFeeling,
                    PhotoUrl = MealEntryConstants.JohnFollowingEmmaDay1LunchEntryPhotoUrl,
                    ConsumedAt = seedingDate.AddDays(-3).AddHours(12).AddMinutes(15), // April 17, 12:15 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(12).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(12).AddMinutes(45)
                },

                // John - Day 2 Breakfast
                new MealEntry
                {
                    Id = Guid.Parse(MealEntryConstants.JohnFollowingEmmaDay2BreakfastEntryId),
                    UserId = Guid.Parse(UserConstants.UserId),
                    MealId = Guid.Parse(MealConstants.EmmaDay2BreakfastId),
                    FeelingComment = MealEntryConstants.JohnFollowingEmmaDay2BreakfastEntryFeeling,
                    PhotoUrl = MealEntryConstants.JohnFollowingEmmaDay2BreakfastEntryPhotoUrl, // null
                    ConsumedAt = seedingDate.AddDays(-2).AddHours(7).AddMinutes(30), // April 18, 7:30 AM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-2).AddHours(8),
                    UpdatedAt = seedingDate.AddDays(-2).AddHours(8)
                }
            };

            return mealEntries;
        }
    }
}