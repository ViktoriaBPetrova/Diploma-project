using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;

namespace HealthyRecipes.Data.Seeding.MealPlanSeeders
{
    /// <summary>
    /// Generates seed data for MealPlanDayEntry entities.
    /// FIXED: References existing UserConstants and MealPlanDayConstants GUIDs.
    /// 
    /// Following relationships:
    /// - Sarah (User2) follows John's Lean Bulk Plan (completed, public - 5 day reflections)
    /// - Mike (User3) follows Sarah's Plant-Based Week (dropped, private - 2 day reflections)
    /// - Emma (User4) follows John's Lean Bulk Plan (active - 2 day reflections)
    /// - John (User) follows Emma's Balanced Nutrition (active - 2 day reflections)
    /// 
    /// Total: 11 day reflections
    /// </summary>
    public class MealPlanDayEntrySeeder
    {
        public static IEnumerable<MealPlanDayEntry> GenerateMealPlanDayEntries()
        {
            // Seeding date - these are "completed" day reflections
            DateTime seedingDate = new DateTime(2025, 4, 21);

            List<MealPlanDayEntry> dayEntries = new List<MealPlanDayEntry>()
            {
                // ========== SARAH FOLLOWING JOHN'S LEAN BULK PLAN ==========
                
                // Sarah - Day 1 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.SarahFollowingJohnDay1EntryId),
                    UserId = Guid.Parse(UserConstants.User2Id), // Sarah
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id), // John's plan Day 1
                    OverallFeeling = MealPlanDayEntryConstants.SarahFollowingJohnDay1EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-10).AddHours(20), // April 10, 8 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-10).AddHours(20),
                    UpdatedAt = seedingDate.AddDays(-10).AddHours(20)
                },

                // Sarah - Day 2 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.SarahFollowingJohnDay2EntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id), // John's plan Day 2
                    OverallFeeling = MealPlanDayEntryConstants.SarahFollowingJohnDay2EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-9).AddHours(20).AddMinutes(15), // April 11, 8:15 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-9).AddHours(20).AddMinutes(15),
                    UpdatedAt = seedingDate.AddDays(-9).AddHours(20).AddMinutes(15)
                },

                // Sarah - Day 3 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.SarahFollowingJohnDay3EntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id), // John's plan Day 3
                    OverallFeeling = MealPlanDayEntryConstants.SarahFollowingJohnDay3EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-8).AddHours(19).AddMinutes(45), // April 12, 7:45 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(19).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(19).AddMinutes(45)
                },

                // Sarah - Day 4 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.SarahFollowingJohnDay4EntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id), // John's plan Day 4
                    OverallFeeling = MealPlanDayEntryConstants.SarahFollowingJohnDay4EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-7).AddHours(20), // April 13, 8 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-7).AddHours(20),
                    UpdatedAt = seedingDate.AddDays(-7).AddHours(20)
                },

                // Sarah - Day 5 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.SarahFollowingJohnDay5EntryId),
                    UserId = Guid.Parse(UserConstants.User2Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id), // John's plan Day 5
                    OverallFeeling = MealPlanDayEntryConstants.SarahFollowingJohnDay5EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-6).AddHours(20).AddMinutes(30), // April 14, 8:30 PM
                    IsPublic = true,
                    CreatedAt = seedingDate.AddDays(-6).AddHours(20).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-6).AddHours(20).AddMinutes(30)
                },

                // ========== MIKE FOLLOWING SARAH'S PLANT-BASED WEEK ==========
                
                // Mike - Day 1 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.MikeFollowingSarahDay1EntryId),
                    UserId = Guid.Parse(UserConstants.User3Id), // Mike
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id), // Sarah's plan Day 1
                    OverallFeeling = MealPlanDayEntryConstants.MikeFollowingSarahDay1EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-8).AddHours(21).AddMinutes(30), // April 12, 9:30 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-8).AddHours(21).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-8).AddHours(21).AddMinutes(30)
                },

                // Mike - Day 2 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.MikeFollowingSarahDay2EntryId),
                    UserId = Guid.Parse(UserConstants.User3Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id), // Sarah's plan Day 2
                    OverallFeeling = MealPlanDayEntryConstants.MikeFollowingSarahDay2EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-7).AddHours(21), // April 13, 9 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-7).AddHours(21),
                    UpdatedAt = seedingDate.AddDays(-7).AddHours(21)
                },

                // ========== EMMA FOLLOWING JOHN'S LEAN BULK PLAN ==========
                
                // Emma - Day 1 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.EmmaFollowingJohnDay1EntryId),
                    UserId = Guid.Parse(UserConstants.User4Id), // Emma
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id), // John's plan Day 1
                    OverallFeeling = MealPlanDayEntryConstants.EmmaFollowingJohnDay1EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-3).AddHours(20).AddMinutes(30), // April 17, 8:30 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(20).AddMinutes(30),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(20).AddMinutes(30)
                },

                // Emma - Day 2 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.EmmaFollowingJohnDay2EntryId),
                    UserId = Guid.Parse(UserConstants.User4Id),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id), // John's plan Day 2
                    OverallFeeling = MealPlanDayEntryConstants.EmmaFollowingJohnDay2EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-2).AddHours(20).AddMinutes(45), // April 18, 8:45 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-2).AddHours(20).AddMinutes(45),
                    UpdatedAt = seedingDate.AddDays(-2).AddHours(20).AddMinutes(45)
                },

                // ========== JOHN FOLLOWING EMMA'S BALANCED NUTRITION ==========
                
                // John - Day 1 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.JohnFollowingEmmaDay1EntryId),
                    UserId = Guid.Parse(UserConstants.UserId), // John
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id), // Emma's plan Day 1
                    OverallFeeling = MealPlanDayEntryConstants.JohnFollowingEmmaDay1EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-3).AddHours(21), // April 17, 9 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-3).AddHours(21),
                    UpdatedAt = seedingDate.AddDays(-3).AddHours(21)
                },

                // John - Day 2 Reflection
                new MealPlanDayEntry
                {
                    Id = Guid.Parse(MealPlanDayEntryConstants.JohnFollowingEmmaDay2EntryId),
                    UserId = Guid.Parse(UserConstants.UserId),
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id), // Emma's plan Day 2
                    OverallFeeling = MealPlanDayEntryConstants.JohnFollowingEmmaDay2EntryOverallFeeling,
                    CompletedAt = seedingDate.AddDays(-2).AddHours(21).AddMinutes(15), // April 18, 9:15 PM
                    IsPublic = false,
                    CreatedAt = seedingDate.AddDays(-2).AddHours(21).AddMinutes(15),
                    UpdatedAt = seedingDate.AddDays(-2).AddHours(21).AddMinutes(15)
                }
            };

            return dayEntries;
        }
    }
}