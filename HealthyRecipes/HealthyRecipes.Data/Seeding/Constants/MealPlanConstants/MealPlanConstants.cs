using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealPlanConstants
    {
        // ---------- Meal Plan 1: John's Lean Bulk Plan ----------
        public const string UserMealPlanId = "d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c";
        public const string UserId = UserConstants.UserId;
        public const string UserMealPlanName = "John's Lean Bulk Plan";
        public const string UserMealPlanDescription = "A meal plan focused on lean muscle gain.";

        // ---------- Meal Plan 2: Sarah's Plant-Based Week ----------
        public const string SarahMealPlanId = "e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c";
        public const string SarahUserId = UserConstants.User2Id;
        public const string SarahMealPlanName = "Sarah's Plant-Based Week";
        public const string SarahMealPlanDescription =
            "A complete week of nutritious plant-based meals. Perfect for yoga practitioners and clean eating enthusiasts.";

        // ---------- Meal Plan 3: Mike's Marathon Training ----------
        public const string MikeMealPlanId = "f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d";
        public const string MikeUserId = UserConstants.User3Id;
        public const string MikeMealPlanName = "Mike's Marathon Training Plan";
        public const string MikeMealPlanDescription =
            "High-protein, high-carb meal plan designed for endurance athletes and marathon training.";

        // ---------- Meal Plan 4: Emma's Balanced Nutrition ----------
        public const string EmmaMealPlanId = "a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e";
        public const string EmmaUserId = UserConstants.User4Id;
        public const string EmmaMealPlanName = "Emma's Balanced Nutrition Guide";
        public const string EmmaMealPlanDescription =
            "A sustainable, well-balanced meal plan for overall health and wellness. No extreme dieting required.";
    }
}
