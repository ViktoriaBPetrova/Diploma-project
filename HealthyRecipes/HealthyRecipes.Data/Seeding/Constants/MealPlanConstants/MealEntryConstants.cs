using System;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    /// <summary>
    /// Constants for MealEntry seed data.
    /// CORRECTED: Uses existing UserConstants and MealConstants GUIDs.
    /// 
    /// Following relationships:
    /// - Sarah follows John's Lean Bulk Plan (completed, public)
    /// - Mike follows Sarah's Plant-Based Week (completed, private)
    /// - Emma follows John's Lean Bulk Plan (active)
    /// - John follows Emma's Balanced Nutrition (active)
    /// </summary>
    public class MealEntryConstants
    {
        // ========== SARAH FOLLOWING JOHN'S LEAN BULK PLAN ==========
        // Sarah completed this plan and consented to public sharing

        // Sarah - Day 1 of John's Plan - Breakfast
        public const string SarahFollowingJohnDay1BreakfastEntryId = "e2111111-2111-4e21-8e21-211111111111";
        // UserId = UserConstants.User2Id (Sarah)
        // MealId = MealConstants.JohnDay1BreakfastId (John's plan Day 1 Breakfast)
        public const string SarahFollowingJohnDay1BreakfastEntryFeeling = "Starting John's lean bulk plan! Excited to see how this protein-focused approach works for me.";
        public const string SarahFollowingJohnDay1BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-breakfast-1.jpg";


        // Sarah - Day 1 of John's Plan - Lunch
        public const string SarahFollowingJohnDay1LunchEntryId = "e2111111-2111-4e21-8e21-211111111112";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay1LunchId
        public const string SarahFollowingJohnDay1LunchEntryFeeling = "More protein than I'm used to, but feeling surprisingly energized!";
        public const string SarahFollowingJohnDay1LunchEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-lunch-1.jpg";


        // Sarah - Day 1 of John's Plan - Dinner
        public const string SarahFollowingJohnDay1DinnerEntryId = "e2111111-2111-4e21-8e21-211111111113";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay1DinnerId
        public const string SarahFollowingJohnDay1DinnerEntryFeeling = "Day 1 complete! Adapting to this higher protein intake.";
        public const string SarahFollowingJohnDay1DinnerEntryPhotoUrl = null;


        // Sarah - Day 2 of John's Plan - Breakfast
        public const string SarahFollowingJohnDay2BreakfastEntryId = "e2111111-2111-4e21-8e21-211111111121";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay2BreakfastId
        public const string SarahFollowingJohnDay2BreakfastEntryFeeling = "Feeling stronger already! This plan is working great.";
        public const string SarahFollowingJohnDay2BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-breakfast-2.jpg";


        // Sarah - Day 2 of John's Plan - Lunch
        public const string SarahFollowingJohnDay2LunchEntryId = "e2111111-2111-4e21-8e21-211111111122";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay2LunchId
        public const string SarahFollowingJohnDay2LunchEntryFeeling = "Post-workout meal hits different with this protein level!";
        public const string SarahFollowingJohnDay2LunchEntryPhotoUrl = null;


        // Sarah - Day 3 of John's Plan - Breakfast
        public const string SarahFollowingJohnDay3BreakfastEntryId = "e2111111-2111-4e21-8e21-211111111131";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay3BreakfastId
        public const string SarahFollowingJohnDay3BreakfastEntryFeeling = "Halfway through the plan! Feeling strong and energized.";
        public const string SarahFollowingJohnDay3BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-breakfast-3.jpg";


        // Sarah - Day 3 of John's Plan - Dinner
        public const string SarahFollowingJohnDay3DinnerEntryId = "e2111111-2111-4e21-8e21-211111111133";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay3DinnerId
        public const string SarahFollowingJohnDay3DinnerEntryFeeling = "Day 3 complete. This is becoming a habit!";
        public const string SarahFollowingJohnDay3DinnerEntryPhotoUrl = null;
 

        // Sarah - Day 4 of John's Plan - Breakfast
        public const string SarahFollowingJohnDay4BreakfastEntryId = "e2111111-2111-4e21-8e21-211111111141";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay4BreakfastId
        public const string SarahFollowingJohnDay4BreakfastEntryFeeling = "Day 4 - feeling great! My yoga practice has never been this strong.";
        public const string SarahFollowingJohnDay4BreakfastEntryPhotoUrl = null;


        // Sarah - Day 4 of John's Plan - Lunch
        public const string SarahFollowingJohnDay4LunchEntryId = "e2111111-2111-4e21-8e21-211111111142";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay4LunchId
        public const string SarahFollowingJohnDay4LunchEntryFeeling = "Meal prep is getting easier. Love this plan!";
        public const string SarahFollowingJohnDay4LunchEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-lunch-4.jpg";


        // Sarah - Day 5 of John's Plan - Breakfast
        public const string SarahFollowingJohnDay5BreakfastEntryId = "e2111111-2111-4e21-8e21-211111111151";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay5BreakfastId
        public const string SarahFollowingJohnDay5BreakfastEntryFeeling = "Final day! Can't believe how much I've learned about protein intake.";
        public const string SarahFollowingJohnDay5BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-breakfast-5.jpg";


        // Sarah - Day 5 of John's Plan - Lunch
        public const string SarahFollowingJohnDay5LunchEntryId = "e2111111-2111-4e21-8e21-211111111152";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay5LunchId
        public const string SarahFollowingJohnDay5LunchEntryFeeling = "Last meal of the plan. I'm definitely going to keep some of these habits!";
        public const string SarahFollowingJohnDay5LunchEntryPhotoUrl = null;


        // Sarah - Day 5 of John's Plan - Dinner
        public const string SarahFollowingJohnDay5DinnerEntryId = "e2111111-2111-4e21-8e21-211111111153";
        // UserId = UserConstants.User2Id
        // MealId = MealConstants.JohnDay5DinnerId
        public const string SarahFollowingJohnDay5DinnerEntryFeeling = "Plan complete! This was an amazing journey. Thank you John for this incredible plan!";
        public const string SarahFollowingJohnDay5DinnerEntryPhotoUrl = "/uploads/meal-entries/sample/sarah-john-dinner-5.jpg";


        // ========== MIKE FOLLOWING SARAH'S PLANT-BASED WEEK ==========
        // Mike completed this plan but keeps it private (didn't work for his training)

        // Mike - Day 1 of Sarah's Plant-Based Plan - Breakfast
        public const string MikeFollowingSarahDay1BreakfastEntryId = "e3222222-3222-4e32-8e32-322222222211";
        // UserId = UserConstants.User3Id (Mike)
        // MealId = MealConstants.SarahDay1BreakfastId (Sarah's plan Day 1 Breakfast)
        public const string MikeFollowingSarahDay1BreakfastEntryFeeling = "Trying Sarah's plant-based approach. Let's see how this affects my marathon training.";
        public const string MikeFollowingSarahDay1BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/mike-sarah-breakfast-1.jpg";


        // Mike - Day 1 of Sarah's Plant-Based Plan - Lunch
        public const string MikeFollowingSarahDay1LunchEntryId = "e3222222-3222-4e32-8e32-322222222212";
        // UserId = UserConstants.User3Id
        // MealId = MealConstants.SarahDay1LunchId
        public const string MikeFollowingSarahDay1LunchEntryFeeling = "Lighter meal than usual. Not sure if this will fuel my long runs.";
        public const string MikeFollowingSarahDay1LunchEntryPhotoUrl = null;


        // Mike - Day 2 of Sarah's Plant-Based Plan - Breakfast
        public const string MikeFollowingSarahDay2BreakfastEntryId = "e3222222-3222-4e32-8e32-322222222221";
        // UserId = UserConstants.User3Id
        // MealId = MealConstants.SarahDay2BreakfastId
        public const string MikeFollowingSarahDay2BreakfastEntryFeeling = "Felt low on energy during my morning run. Need more protein for training.";
        public const string MikeFollowingSarahDay2BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/mike-sarah-breakfast-2.jpg";


        // ========== EMMA FOLLOWING JOHN'S LEAN BULK PLAN ==========
        // Emma is actively following (not completed yet)

        // Emma - Day 1 of John's Plan - Breakfast
        public const string EmmaFollowingJohnDay1BreakfastEntryId = "e4111111-4111-4e41-8e41-411111111111";
        // UserId = UserConstants.User4Id (Emma)
        // MealId = MealConstants.JohnDay1BreakfastId (John's plan Day 1 Breakfast)
        public const string EmmaFollowingJohnDay1BreakfastEntryFeeling = "Love John's structured approach to lean bulking. This is exactly what my clients need!";
        public const string EmmaFollowingJohnDay1BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/emma-john-breakfast-1.jpg";


        // Emma - Day 1 of John's Plan - Lunch
        public const string EmmaFollowingJohnDay1LunchEntryId = "e4111111-4111-4e41-8e41-411111111112";
        // UserId = UserConstants.User4Id
        // MealId = MealConstants.JohnDay1LunchId
        public const string EmmaFollowingJohnDay1LunchEntryFeeling = "Perfect macro balance for sustainable muscle building.";
        public const string EmmaFollowingJohnDay1LunchEntryPhotoUrl = null;


        // Emma - Day 2 of John's Plan - Breakfast
        public const string EmmaFollowingJohnDay2BreakfastEntryId = "e4111111-4111-4e41-8e41-411111111121";
        // UserId = UserConstants.User4Id
        // MealId = MealConstants.JohnDay2BreakfastId
        public const string EmmaFollowingJohnDay2BreakfastEntryFeeling = "Day 2 and loving the consistency. Great for building habits!";
        public const string EmmaFollowingJohnDay2BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/emma-john-breakfast-2.jpg";


        // ========== JOHN FOLLOWING EMMA'S BALANCED NUTRITION ==========
        // John is actively following Emma's plan

        // John - Day 1 of Emma's Plan - Breakfast
        public const string JohnFollowingEmmaDay1BreakfastEntryId = "e1444444-1444-4e14-8e14-144444444411";
        // UserId = UserConstants.UserId (John)
        // MealId = MealConstants.EmmaDay1BreakfastId (Emma's plan Day 1 Breakfast)
        public const string JohnFollowingEmmaDay1BreakfastEntryFeeling = "Trying Emma's balanced approach for a change. Let's see how this sustainable eating works!";
        public const string JohnFollowingEmmaDay1BreakfastEntryPhotoUrl = "/uploads/meal-entries/sample/john-emma-breakfast-1.jpg";
 

        // John - Day 1 of Emma's Plan - Lunch
        public const string JohnFollowingEmmaDay1LunchEntryId = "e1444444-1444-4e14-8e14-144444444412";
        // UserId = UserConstants.UserId
        // MealId = MealConstants.EmmaDay1LunchId
        public const string JohnFollowingEmmaDay1LunchEntryFeeling = "More balanced than my usual high-protein approach. Feeling good!";
        public const string JohnFollowingEmmaDay1LunchEntryPhotoUrl = "/uploads/meal-entries/sample/john-emma-lunch-1.jpg";

        // John - Day 2 of Emma's Plan - Breakfast
        public const string JohnFollowingEmmaDay2BreakfastEntryId = "e1444444-1444-4e14-8e14-144444444421";
        // UserId = UserConstants.UserId
        // MealId = MealConstants.EmmaDay2BreakfastId
        public const string JohnFollowingEmmaDay2BreakfastEntryFeeling = "This sustainable approach is actually really enjoyable. No restrictive vibes!";
        public const string JohnFollowingEmmaDay2BreakfastEntryPhotoUrl = null;
    }
}