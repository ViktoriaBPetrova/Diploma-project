using System;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    /// <summary>
    /// Constants for MealPlanDayEntry seed data.
    /// FIXED: References existing UserConstants and MealPlanDayConstants GUIDs.
    /// 
    /// Following relationships:
    /// - Sarah follows John's Lean Bulk Plan (completed, public)
    /// - Mike follows Sarah's Plant-Based Week (dropped, private)
    /// - Emma follows John's Lean Bulk Plan (active)
    /// - John follows Emma's Balanced Nutrition (active)
    /// </summary>
    public class MealPlanDayEntryConstants
    {
        // ========== SARAH FOLLOWING JOHN'S LEAN BULK PLAN ==========

        // Sarah - Day 1 Reflection (John's Plan)
        public const string SarahFollowingJohnDay1EntryId = "d2111111-2111-4d21-8d21-211111111111";
        // UserId = UserConstants.User2Id (Sarah)
        // MealPlanDayId = MealPlanDayConstants.JohnDay1Id (John's plan Day 1)
        public const string SarahFollowingJohnDay1EntryOverallFeeling = "First day on John's lean bulk plan complete! The protein intake is higher than I'm used to, but I felt energized throughout the day. My yoga practice was strong and I didn't feel heavy or sluggish. Excited to see how this week goes!";


        // Sarah - Day 2 Reflection (John's Plan)
        public const string SarahFollowingJohnDay2EntryId = "d2111111-2111-4d21-8d21-211111111112";
        // UserId = UserConstants.User2Id
        // MealPlanDayId = MealPlanDayConstants.JohnDay2Id
        public const string SarahFollowingJohnDay2EntryOverallFeeling = "Day 2 went even better! I'm adapting to the higher protein and actually enjoying it. Post-workout recovery feels faster. This plan is challenging my preconceptions about protein intake in a good way.";


        // Sarah - Day 3 Reflection (John's Plan)
        public const string SarahFollowingJohnDay3EntryId = "d2111111-2111-4d21-8d21-211111111113";
        // UserId = UserConstants.User2Id
        // MealPlanDayId = MealPlanDayConstants.JohnDay3Id
        public const string SarahFollowingJohnDay3EntryOverallFeeling = "Halfway through and I'm seeing the benefits! Muscle definition is improving and I feel stronger in my practice. John really knows his stuff - this plan is scientifically sound and sustainable.";


        // Sarah - Day 4 Reflection (John's Plan)
        public const string SarahFollowingJohnDay4EntryId = "d2111111-2111-4d21-8d21-211111111114";
        // UserId = UserConstants.User2Id
        // MealPlanDayId = MealPlanDayConstants.JohnDay4Id
        public const string SarahFollowingJohnDay4EntryOverallFeeling = "Day 4 complete! I'm noticing real changes - better recovery, more energy, and my strength has improved noticeably. This plan is a game-changer for my yoga practice and overall fitness.";


        // Sarah - Day 5 Reflection (John's Plan)
        public const string SarahFollowingJohnDay5EntryId = "d2111111-2111-4d21-8d21-211111111115";
        // UserId = UserConstants.User2Id
        // MealPlanDayId = MealPlanDayConstants.JohnDay5Id
        public const string SarahFollowingJohnDay5EntryOverallFeeling = "Final day complete! This 5-day journey completely changed my perspective on protein and nutrition. I feel stronger, more energized, and my body composition has visibly improved. I'm so grateful for John's expertise - this plan is sustainable and effective. Definitely sharing this publicly to inspire others!";
 

        // ========== MIKE FOLLOWING SARAH'S PLANT-BASED WEEK ==========

        // Mike - Day 1 Reflection (Sarah's Plant-Based Plan)
        public const string MikeFollowingSarahDay1EntryId = "d3222222-3222-4d32-8d32-322222222211";
        // UserId = UserConstants.User3Id (Mike)
        // MealPlanDayId = MealPlanDayConstants.SarahDay1Id (Sarah's plan Day 1)
        public const string MikeFollowingSarahDay1EntryOverallFeeling = "First day trying Sarah's plant-based approach. The meals were lighter than I'm used to. My 10K this morning felt okay but I noticed less energy in the final kilometers. Not sure if this protein level will support my marathon training.";


        // Mike - Day 2 Reflection (Sarah's Plant-Based Plan)
        public const string MikeFollowingSarahDay2EntryId = "d3222222-3222-4d32-8d32-322222222212";
        // UserId = UserConstants.User3Id
        // MealPlanDayId = MealPlanDayConstants.SarahDay2Id
        public const string MikeFollowingSarahDay2EntryOverallFeeling = "Struggled on today's run. Energy dropped significantly around the 8km mark. Recovery feels slower too. I appreciate the clean eating approach but I don't think plant-based aligns with my endurance training needs right now.";

        // ========== EMMA FOLLOWING JOHN'S LEAN BULK PLAN ==========

        // Emma - Day 1 Reflection (John's Plan)
        public const string EmmaFollowingJohnDay1EntryId = "d4111111-4111-4d41-8d41-411111111111";
        // UserId = UserConstants.User4Id (Emma)
        // MealPlanDayId = MealPlanDayConstants.JohnDay1Id (John's plan Day 1)
        public const string EmmaFollowingJohnDay1EntryOverallFeeling = "As a nutritionist, I'm impressed with John's macro balance! Day 1 was fantastic - the protein distribution throughout the day maintains steady energy. This is exactly the kind of sustainable approach I recommend to my clients. Perfect for muscle building without extreme restrictions.";

        // Emma - Day 2 Reflection (John's Plan)
        public const string EmmaFollowingJohnDay2EntryId = "d4111111-4111-4d41-8d41-411111111112";
        // UserId = UserConstants.User4Id
        // MealPlanDayId = MealPlanDayConstants.JohnDay2Id
        public const string EmmaFollowingJohnDay2EntryOverallFeeling = "Day 2 reinforces what I love about this plan - it's repeatable and practical. No cravings, steady energy, and the meals are genuinely enjoyable. I'm definitely going to analyze this structure for my client programs!";


        // ========== JOHN FOLLOWING EMMA'S BALANCED NUTRITION ==========

        // John - Day 1 Reflection (Emma's Plan)
        public const string JohnFollowingEmmaDay1EntryId = "d1444444-1444-4d14-8d14-144444444411";
        // UserId = UserConstants.UserId (John)
        // MealPlanDayId = MealPlanDayConstants.EmmaDay1Id (Emma's plan Day 1)
        public const string JohnFollowingEmmaDay1EntryOverallFeeling = "First day on Emma's balanced nutrition plan. It's a nice change from my usual high-protein focus. The meals feel more sustainable and less restrictive. Still hit my workout hard - maybe you don't need extreme macros to make progress!";


        // John - Day 2 Reflection (Emma's Plan)
        public const string JohnFollowingEmmaDay2EntryId = "d1444444-1444-4d14-8d14-144444444412";
        // UserId = UserConstants.UserId
        // MealPlanDayId = MealPlanDayConstants.EmmaDay2Id
        public const string JohnFollowingEmmaDay2EntryOverallFeeling = "Day 2 and I'm really enjoying this approach. Emma's focus on sustainability is eye-opening - this feels like something I could maintain long-term, not just a temporary bulk phase. Great balance of macros without being dogmatic.";
    }
}