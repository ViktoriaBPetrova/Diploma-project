using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealPlanConstants
    {
        // ---------- IDs ----------
        public const string UserMealPlanId = "d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c";

        // ---------- User IDs ----------
        public const string UserId = UserConstants.UserId;

        // ---------- Names ----------
        public const string UserMealPlanName = "John's Lean Bulk Plan";

        // ---------- Descriptions ----------
        public const string UserMealPlanDescription = "A meal plan focused on lean muscle gain.";

        // ---------- Nutrition ----------
        public const float UserMealPlanCalories = 2500;
        public const float UserMealPlanProtein = 150;
        public const float UserMealPlanCarbs = 300;
        public const float UserMealPlanFat = 70;
    }
}
