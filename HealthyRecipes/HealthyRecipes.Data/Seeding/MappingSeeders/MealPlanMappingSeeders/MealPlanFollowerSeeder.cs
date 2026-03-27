using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.MealPlanTracking;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanFollowerSeeders
{

    /// <summary>
    /// Generates MealPlanFollower seed data with Phase 2 consent fields.
    /// Users follow OTHER people's meal plans, not their own.
    /// 
    /// Following relationships:
    /// - Sarah follows John's Lean Bulk Plan (completed, public consent)
    /// - Mike follows Sarah's Plant-Based Week (completed, private consent - dropped after Day 2)
    /// - Emma follows John's Lean Bulk Plan (actively following)
    /// - John follows Emma's Balanced Nutrition (actively following)
    /// </summary>
    public static class MealPlanFollowerSeeder
    {
        public static IEnumerable<MealPlanFollower> GenerateMealPlanFollowers()
        {
            DateTime seedingDate = new DateTime(2025, 4, 20);

            IEnumerable<MealPlanFollower> mealPlanFollowers = new List<MealPlanFollower>()
            {
                // ========== SARAH FOLLOWS JOHN'S LEAN BULK PLAN ==========
                // Sarah completed John's plan and consented to make it public
                new MealPlanFollower(
                    Guid.Parse(UserConstants.User2Id), // Sarah
                    Guid.Parse(MealPlanConstants.UserMealPlanId), // John's Lean Bulk Plan (5 days)
                    seedingDate.AddDays(-10) // Started 10 days ago
                )
                {
                    IsActive = false,
                    Status = MealPlanFollowerStatus.Completed,
                    CompletedAt = seedingDate.AddDays(-5), // Completed 5 days ago
                    ExpectedCompletionDate = seedingDate.AddDays(-10).AddDays(5), // Started -10, plan is 5 days = -5
                    HasSeenCompletionPrompt = true,
                    // Sarah chose to share publicly
                    ShowOnProfileAsCompleted = true,
                    ShareJournalPublicly = true,
                    ConsentGivenAt = seedingDate.AddDays(-5).AddHours(2) // 2 hours after completion
                },
 
                // ========== MIKE FOLLOWS SARAH'S PLANT-BASED WEEK ==========
                // Mike completed Sarah's plan but keeps it private (didn't work for his training)
                new MealPlanFollower(
                    Guid.Parse(UserConstants.User3Id), // Mike
                    Guid.Parse(MealPlanConstants.SarahMealPlanId), // Sarah's Plant-Based Week (5 days)
                    seedingDate.AddDays(-8) // Started 8 days ago
                )
                {
                    IsActive = false,
                    Status = MealPlanFollowerStatus.Dropped, // Dropped after Day 2
                    DropoutReason = "Plant-based diet wasn't compatible with my marathon training needs. Low energy on runs.",
                    ExpectedCompletionDate = seedingDate.AddDays(-8).AddDays(5), // Started -8, plan is 5 days = -3
                    HasSeenCompletionPrompt = true,
                    //Mike keeps everything private
                    ShowOnProfileAsCompleted = false,
                    ShareJournalPublicly = false,
                    ConsentGivenAt = seedingDate.AddDays(-6).AddHours(1) // Dropped on Day 2
                },
 
                // ========== EMMA FOLLOWS JOHN'S LEAN BULK PLAN ==========
                // Emma is actively following John's plan (nutritionist testing it)
                new MealPlanFollower(
                    Guid.Parse(UserConstants.User4Id), // Emma
                    Guid.Parse(MealPlanConstants.UserMealPlanId), // John's Lean Bulk Plan (5 days)
                    seedingDate.AddDays(-3) // Started 3 days ago
                )
                {
                    IsActive = true,
                    Status = MealPlanFollowerStatus.Active,
                    ExpectedCompletionDate = seedingDate.AddDays(-3).AddDays(5), // Started -3, plan is 5 days = +2
                    HasSeenCompletionPrompt = false,
                    // (not set yet - plan not completed)
                    ShowOnProfileAsCompleted = false,
                    ShareJournalPublicly = false,
                    ConsentGivenAt = null
                },
 
                // ========== JOHN FOLLOWS EMMA'S BALANCED NUTRITION ==========
                // John is actively following Emma's plan (trying a balanced approach)
                new MealPlanFollower(
                    Guid.Parse(UserConstants.UserId), // John
                    Guid.Parse(MealPlanConstants.EmmaMealPlanId), // Emma's Balanced Nutrition Guide (5 days)
                    seedingDate.AddDays(-3) // Started 3 days ago
                )
                {
                    IsActive = true,
                    Status = MealPlanFollowerStatus.Active,
                    ExpectedCompletionDate = seedingDate.AddDays(-3).AddDays(5), // Started -3, plan is 5 days = +2
                    HasSeenCompletionPrompt = false,
                    // (not set yet - plan not completed)
                    ShowOnProfileAsCompleted = false,
                    ShareJournalPublicly = false,
                    ConsentGivenAt = null
                }
            };

            return mealPlanFollowers;
        }
    }
}
