using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealConstants
    {
        // ---------- IDs ----------
        public const string BreakfastId = "a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f";
        public const string LunchId = "f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f";

        // ---------- Meal Types ----------
        public const MealType BreakfastType = MealType.Breakfast;
        public const MealType LunchType = MealType.Lunch;

        // ---------- Macronutrients ----------
        public const float BreakfastCalories = 400;
        public const float BreakfastProtein = 25;
        public const float BreakfastCarbs = 50;
        public const float BreakfastFat = 10;

        public const float LunchCalories = 700;
        public const float LunchProtein = 40;
        public const float LunchCarbs = 80;
        public const float LunchFat = 20;

        // ---------- MealPlanDay IDs (example, adjust as needed) ----------
        public const string BreakfastDayId = "11111111-2222-3333-4444-555555555555";
        public const string LunchDayId = "66666666-7777-8888-9999-000000000000";
    }
}
