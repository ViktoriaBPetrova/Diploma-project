using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealPlanConstants
    {
        // Note: Each MealPlan aggregates 5 days (Day 1 + Day 2 + Day 3 + Day 4 + Day 5)
        // Macros = Sum of the 5 MealPlanDay macros from MealPlanDayConstants

        // ═══════════════════════════════════════════════════════════
        // MEAL PLAN 1: John's Lean Bulk Plan
        // ═══════════════════════════════════════════════════════════
        public const string UserMealPlanId = "d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c";
        public const string UserId = UserConstants.UserId;
        public const string UserMealPlanName = "John's Lean Bulk Plan";
        public const string UserMealPlanDescription = "A meal plan focused on lean muscle gain.";

        // Sum of John's 5 days (Day1 + Day2 + Day3 + Day4 + Day5)
        public const float UserMealPlanCalories = MealPlanDayConstants.JohnDay1Calories +
                                                   MealPlanDayConstants.JohnDay2Calories +
                                                   MealPlanDayConstants.JohnDay3Calories +
                                                   MealPlanDayConstants.JohnDay4Calories +
                                                   MealPlanDayConstants.JohnDay5Calories;

        public const float UserMealPlanProtein = MealPlanDayConstants.JohnDay1Protein +
                                                  MealPlanDayConstants.JohnDay2Protein +
                                                  MealPlanDayConstants.JohnDay3Protein +
                                                  MealPlanDayConstants.JohnDay4Protein +
                                                  MealPlanDayConstants.JohnDay5Protein;

        public const float UserMealPlanCarbs = MealPlanDayConstants.JohnDay1Carbs +
                                                MealPlanDayConstants.JohnDay2Carbs +
                                                MealPlanDayConstants.JohnDay3Carbs +
                                                MealPlanDayConstants.JohnDay4Carbs +
                                                MealPlanDayConstants.JohnDay5Carbs;

        public const float UserMealPlanFat = MealPlanDayConstants.JohnDay1Fat +
                                              MealPlanDayConstants.JohnDay2Fat +
                                              MealPlanDayConstants.JohnDay3Fat +
                                              MealPlanDayConstants.JohnDay4Fat +
                                              MealPlanDayConstants.JohnDay5Fat;

        // ═══════════════════════════════════════════════════════════
        // MEAL PLAN 2: Sarah's Plant-Based Week
        // ═══════════════════════════════════════════════════════════
        public const string SarahMealPlanId = "e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c";
        public const string SarahUserId = UserConstants.User2Id;
        public const string SarahMealPlanName = "Sarah's Plant-Based Week";
        public const string SarahMealPlanDescription =
            "A complete week of nutritious plant-based meals. Perfect for yoga practitioners and clean eating enthusiasts.";

        // Sum of Sarah's 5 days (Day1 + Day2 + Day3 + Day4 + Day5)
        public const float SarahMealPlanCalories = MealPlanDayConstants.SarahDay1Calories +
                                                    MealPlanDayConstants.SarahDay2Calories +
                                                    MealPlanDayConstants.SarahDay3Calories +
                                                    MealPlanDayConstants.SarahDay4Calories +
                                                    MealPlanDayConstants.SarahDay5Calories;

        public const float SarahMealPlanProtein = MealPlanDayConstants.SarahDay1Protein +
                                                   MealPlanDayConstants.SarahDay2Protein +
                                                   MealPlanDayConstants.SarahDay3Protein +
                                                   MealPlanDayConstants.SarahDay4Protein +
                                                   MealPlanDayConstants.SarahDay5Protein;

        public const float SarahMealPlanCarbs = MealPlanDayConstants.SarahDay1Carbs +
                                                 MealPlanDayConstants.SarahDay2Carbs +
                                                 MealPlanDayConstants.SarahDay3Carbs +
                                                 MealPlanDayConstants.SarahDay4Carbs +
                                                 MealPlanDayConstants.SarahDay5Carbs;

        public const float SarahMealPlanFat = MealPlanDayConstants.SarahDay1Fat +
                                               MealPlanDayConstants.SarahDay2Fat +
                                               MealPlanDayConstants.SarahDay3Fat +
                                               MealPlanDayConstants.SarahDay4Fat +
                                               MealPlanDayConstants.SarahDay5Fat;

        // ═══════════════════════════════════════════════════════════
        // MEAL PLAN 3: Mike's Marathon Training
        // ═══════════════════════════════════════════════════════════
        public const string MikeMealPlanId = "f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d";
        public const string MikeUserId = UserConstants.User3Id;
        public const string MikeMealPlanName = "Mike's Marathon Training Plan";
        public const string MikeMealPlanDescription =
            "High-protein, high-carb meal plan designed for endurance athletes and marathon training.";

        // Sum of Mike's 5 days (Day1 + Day2 + Day3 + Day4 + Day5)
        public const float MikeMealPlanCalories = MealPlanDayConstants.MikeDay1Calories +
                                                   MealPlanDayConstants.MikeDay2Calories +
                                                   MealPlanDayConstants.MikeDay3Calories +
                                                   MealPlanDayConstants.MikeDay4Calories +
                                                   MealPlanDayConstants.MikeDay5Calories;

        public const float MikeMealPlanProtein = MealPlanDayConstants.MikeDay1Protein +
                                                  MealPlanDayConstants.MikeDay2Protein +
                                                  MealPlanDayConstants.MikeDay3Protein +
                                                  MealPlanDayConstants.MikeDay4Protein +
                                                  MealPlanDayConstants.MikeDay5Protein;

        public const float MikeMealPlanCarbs = MealPlanDayConstants.MikeDay1Carbs +
                                                MealPlanDayConstants.MikeDay2Carbs +
                                                MealPlanDayConstants.MikeDay3Carbs +
                                                MealPlanDayConstants.MikeDay4Carbs +
                                                MealPlanDayConstants.MikeDay5Carbs;

        public const float MikeMealPlanFat = MealPlanDayConstants.MikeDay1Fat +
                                              MealPlanDayConstants.MikeDay2Fat +
                                              MealPlanDayConstants.MikeDay3Fat +
                                              MealPlanDayConstants.MikeDay4Fat +
                                              MealPlanDayConstants.MikeDay5Fat;

        // ═══════════════════════════════════════════════════════════
        // MEAL PLAN 4: Emma's Balanced Nutrition
        // ═══════════════════════════════════════════════════════════
        public const string EmmaMealPlanId = "a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e";
        public const string EmmaUserId = UserConstants.User4Id;
        public const string EmmaMealPlanName = "Emma's Balanced Nutrition Guide";
        public const string EmmaMealPlanDescription =
            "A sustainable, well-balanced meal plan for overall health and wellness. No extreme dieting required.";

        // Sum of Emma's 5 days (Day1 + Day2 + Day3 + Day4 + Day5)
        public const float EmmaMealPlanCalories = MealPlanDayConstants.EmmaDay1Calories +
                                                   MealPlanDayConstants.EmmaDay2Calories +
                                                   MealPlanDayConstants.EmmaDay3Calories +
                                                   MealPlanDayConstants.EmmaDay4Calories +
                                                   MealPlanDayConstants.EmmaDay5Calories;

        public const float EmmaMealPlanProtein = MealPlanDayConstants.EmmaDay1Protein +
                                                  MealPlanDayConstants.EmmaDay2Protein +
                                                  MealPlanDayConstants.EmmaDay3Protein +
                                                  MealPlanDayConstants.EmmaDay4Protein +
                                                  MealPlanDayConstants.EmmaDay5Protein;

        public const float EmmaMealPlanCarbs = MealPlanDayConstants.EmmaDay1Carbs +
                                                MealPlanDayConstants.EmmaDay2Carbs +
                                                MealPlanDayConstants.EmmaDay3Carbs +
                                                MealPlanDayConstants.EmmaDay4Carbs +
                                                MealPlanDayConstants.EmmaDay5Carbs;

        public const float EmmaMealPlanFat = MealPlanDayConstants.EmmaDay1Fat +
                                              MealPlanDayConstants.EmmaDay2Fat +
                                              MealPlanDayConstants.EmmaDay3Fat +
                                              MealPlanDayConstants.EmmaDay4Fat +
                                              MealPlanDayConstants.EmmaDay5Fat;
    }
}