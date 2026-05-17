using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyRecipes.Data.Enums;
using DayOfWeek = HealthyRecipes.Data.Enums.DayOfWeek;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealPlanDayConstants
    {
        // Note: Each MealPlanDay aggregates 3 meals (Breakfast + Lunch + Dinner)
        // Macros = Sum of the 3 meal macros from MealConstants

        // ═══════════════════════════════════════════════════════════
        // JOHN'S LEAN BULK PLAN - 5 Days
        // ═══════════════════════════════════════════════════════════

        // ========== John - Day 1 ==========
        public const string JohnDay1Id = "a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d";
        public const DayOfWeek JohnDay1DayOfWeek = DayOfWeek.Monday;
        public const int JohnDay1DayNumber = 1;
        // Breakfast (Veggie Omelette + Berries) + Lunch (Chicken Rice Bowl) + Dinner (Grilled Salmon Quinoa)
        public const float JohnDay1Calories = MealConstants.JohnDay1BreakfastCalories + MealConstants.JohnDay1LunchCalories + MealConstants.JohnDay1DinnerCalories;
        public const float JohnDay1Protein = MealConstants.JohnDay1BreakfastProtein + MealConstants.JohnDay1LunchProtein + MealConstants.JohnDay1DinnerProtein;
        public const float JohnDay1Carbs = MealConstants.JohnDay1BreakfastCarbs + MealConstants.JohnDay1LunchCarbs + MealConstants.JohnDay1DinnerCarbs;
        public const float JohnDay1Fat = MealConstants.JohnDay1BreakfastFat + MealConstants.JohnDay1LunchFat + MealConstants.JohnDay1DinnerFat;

        // ========== John - Day 2 ==========
        public const string JohnDay2Id = "b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e";
        public const DayOfWeek JohnDay2DayOfWeek = DayOfWeek.Tuesday;
        public const int JohnDay2DayNumber = 2;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Chicken Stir Fry) + Dinner (Chicken Rice Bowl)
        public const float JohnDay2Calories = MealConstants.JohnDay2BreakfastCalories + MealConstants.JohnDay2LunchCalories + MealConstants.JohnDay2DinnerCalories;
        public const float JohnDay2Protein = MealConstants.JohnDay2BreakfastProtein + MealConstants.JohnDay2LunchProtein + MealConstants.JohnDay2DinnerProtein;
        public const float JohnDay2Carbs = MealConstants.JohnDay2BreakfastCarbs + MealConstants.JohnDay2LunchCarbs + MealConstants.JohnDay2DinnerCarbs;
        public const float JohnDay2Fat = MealConstants.JohnDay2BreakfastFat + MealConstants.JohnDay2LunchFat + MealConstants.JohnDay2DinnerFat;

        // ========== John - Day 3 ==========
        public const string JohnDay3Id = "c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f";
        public const DayOfWeek JohnDay3DayOfWeek = DayOfWeek.Wednesday;
        public const int JohnDay3DayNumber = 3;
        // Breakfast (Overnight Oats) + Lunch (Grilled Salmon Quinoa) + Dinner (Veggie Omelette)
        public const float JohnDay3Calories = MealConstants.JohnDay3BreakfastCalories + MealConstants.JohnDay3LunchCalories + MealConstants.JohnDay3DinnerCalories;
        public const float JohnDay3Protein = MealConstants.JohnDay3BreakfastProtein + MealConstants.JohnDay3LunchProtein + MealConstants.JohnDay3DinnerProtein;
        public const float JohnDay3Carbs = MealConstants.JohnDay3BreakfastCarbs + MealConstants.JohnDay3LunchCarbs + MealConstants.JohnDay3DinnerCarbs;
        public const float JohnDay3Fat = MealConstants.JohnDay3BreakfastFat + MealConstants.JohnDay3LunchFat + MealConstants.JohnDay3DinnerFat;

        // ========== John - Day 4 ==========
        public const string JohnDay4Id = "d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a";
        public const DayOfWeek JohnDay4DayOfWeek = DayOfWeek.Thursday;
        public const int JohnDay4DayNumber = 4;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Chicken Rice Bowl) + Dinner (Chicken Stir Fry)
        public const float JohnDay4Calories = MealConstants.JohnDay4BreakfastCalories + MealConstants.JohnDay4LunchCalories + MealConstants.JohnDay4DinnerCalories;
        public const float JohnDay4Protein = MealConstants.JohnDay4BreakfastProtein + MealConstants.JohnDay4LunchProtein + MealConstants.JohnDay4DinnerProtein;
        public const float JohnDay4Carbs = MealConstants.JohnDay4BreakfastCarbs + MealConstants.JohnDay4LunchCarbs + MealConstants.JohnDay4DinnerCarbs;
        public const float JohnDay4Fat = MealConstants.JohnDay4BreakfastFat + MealConstants.JohnDay4LunchFat + MealConstants.JohnDay4DinnerFat;

        // ========== John - Day 5 ==========
        public const string JohnDay5Id = "e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b";
        public const DayOfWeek JohnDay5DayOfWeek = DayOfWeek.Friday;
        public const int JohnDay5DayNumber = 5;
        // Breakfast (Veggie Omelette) + Lunch (Grilled Salmon Quinoa) + Dinner (Chicken Rice Bowl)
        public const float JohnDay5Calories = MealConstants.JohnDay5BreakfastCalories + MealConstants.JohnDay5LunchCalories + MealConstants.JohnDay5DinnerCalories;
        public const float JohnDay5Protein = MealConstants.JohnDay5BreakfastProtein + MealConstants.JohnDay5LunchProtein + MealConstants.JohnDay5DinnerProtein;
        public const float JohnDay5Carbs = MealConstants.JohnDay5BreakfastCarbs + MealConstants.JohnDay5LunchCarbs + MealConstants.JohnDay5DinnerCarbs;
        public const float JohnDay5Fat = MealConstants.JohnDay5BreakfastFat + MealConstants.JohnDay5LunchFat + MealConstants.JohnDay5DinnerFat;

        // ═══════════════════════════════════════════════════════════
        // SARAH'S PLANT-BASED WEEK - 5 Days
        // ═══════════════════════════════════════════════════════════

        // ========== Sarah - Day 1 ==========
        public const string SarahDay1Id = "f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c";
        public const DayOfWeek SarahDay1DayOfWeek = DayOfWeek.Monday;
        public const int SarahDay1DayNumber = 1;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Buddha Bowl) + Dinner (Mediterranean Salad)
        public const float SarahDay1Calories = MealConstants.SarahDay1BreakfastCalories + MealConstants.SarahDay1LunchCalories + MealConstants.SarahDay1DinnerCalories;
        public const float SarahDay1Protein = MealConstants.SarahDay1BreakfastProtein + MealConstants.SarahDay1LunchProtein + MealConstants.SarahDay1DinnerProtein;
        public const float SarahDay1Carbs = MealConstants.SarahDay1BreakfastCarbs + MealConstants.SarahDay1LunchCarbs + MealConstants.SarahDay1DinnerCarbs;
        public const float SarahDay1Fat = MealConstants.SarahDay1BreakfastFat + MealConstants.SarahDay1LunchFat + MealConstants.SarahDay1DinnerFat;

        // ========== Sarah - Day 2 ==========
        public const string SarahDay2Id = "a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d";
        public const DayOfWeek SarahDay2DayOfWeek = DayOfWeek.Tuesday;
        public const int SarahDay2DayNumber = 2;
        // Breakfast (Overnight Oats) + Lunch (Buddha Bowl) + Dinner (Greek Yogurt Bowl)
        public const float SarahDay2Calories = MealConstants.SarahDay2BreakfastCalories + MealConstants.SarahDay2LunchCalories + MealConstants.SarahDay2DinnerCalories;
        public const float SarahDay2Protein = MealConstants.SarahDay2BreakfastProtein + MealConstants.SarahDay2LunchProtein + MealConstants.SarahDay2DinnerProtein;
        public const float SarahDay2Carbs = MealConstants.SarahDay2BreakfastCarbs + MealConstants.SarahDay2LunchCarbs + MealConstants.SarahDay2DinnerCarbs;
        public const float SarahDay2Fat = MealConstants.SarahDay2BreakfastFat + MealConstants.SarahDay2LunchFat + MealConstants.SarahDay2DinnerFat;

        // ========== Sarah - Day 3 ==========
        public const string SarahDay3Id = "b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e";
        public const DayOfWeek SarahDay3DayOfWeek = DayOfWeek.Wednesday;
        public const int SarahDay3DayNumber = 3;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Mediterranean Salad) + Dinner (Buddha Bowl)
        public const float SarahDay3Calories = MealConstants.SarahDay3BreakfastCalories + MealConstants.SarahDay3LunchCalories + MealConstants.SarahDay3DinnerCalories;
        public const float SarahDay3Protein = MealConstants.SarahDay3BreakfastProtein + MealConstants.SarahDay3LunchProtein + MealConstants.SarahDay3DinnerProtein;
        public const float SarahDay3Carbs = MealConstants.SarahDay3BreakfastCarbs + MealConstants.SarahDay3LunchCarbs + MealConstants.SarahDay3DinnerCarbs;
        public const float SarahDay3Fat = MealConstants.SarahDay3BreakfastFat + MealConstants.SarahDay3LunchFat + MealConstants.SarahDay3DinnerFat;

        // ========== Sarah - Day 4 ==========
        public const string SarahDay4Id = "c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f";
        public const DayOfWeek SarahDay4DayOfWeek = DayOfWeek.Thursday;
        public const int SarahDay4DayNumber = 4;
        // Breakfast (Overnight Oats) + Lunch (Buddha Bowl) + Dinner (Mediterranean Salad)
        public const float SarahDay4Calories = MealConstants.SarahDay4BreakfastCalories + MealConstants.SarahDay4LunchCalories + MealConstants.SarahDay4DinnerCalories;
        public const float SarahDay4Protein = MealConstants.SarahDay4BreakfastProtein + MealConstants.SarahDay4LunchProtein + MealConstants.SarahDay4DinnerProtein;
        public const float SarahDay4Carbs = MealConstants.SarahDay4BreakfastCarbs + MealConstants.SarahDay4LunchCarbs + MealConstants.SarahDay4DinnerCarbs;
        public const float SarahDay4Fat = MealConstants.SarahDay4BreakfastFat + MealConstants.SarahDay4LunchFat + MealConstants.SarahDay4DinnerFat;

        // ========== Sarah - Day 5 ==========
        public const string SarahDay5Id = "d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a";
        public const DayOfWeek SarahDay5DayOfWeek = DayOfWeek.Friday;
        public const int SarahDay5DayNumber = 5;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Buddha Bowl) + Dinner (Mediterranean Salad)
        public const float SarahDay5Calories = MealConstants.SarahDay5BreakfastCalories + MealConstants.SarahDay5LunchCalories + MealConstants.SarahDay5DinnerCalories;
        public const float SarahDay5Protein = MealConstants.SarahDay5BreakfastProtein + MealConstants.SarahDay5LunchProtein + MealConstants.SarahDay5DinnerProtein;
        public const float SarahDay5Carbs = MealConstants.SarahDay5BreakfastCarbs + MealConstants.SarahDay5LunchCarbs + MealConstants.SarahDay5DinnerCarbs;
        public const float SarahDay5Fat = MealConstants.SarahDay5BreakfastFat + MealConstants.SarahDay5LunchFat + MealConstants.SarahDay5DinnerFat;

        // ═══════════════════════════════════════════════════════════
        // MIKE'S MARATHON TRAINING - 5 Days
        // ═══════════════════════════════════════════════════════════

        // ========== Mike - Day 1 ==========
        public const string MikeDay1Id = "e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b";
        public const DayOfWeek MikeDay1DayOfWeek = DayOfWeek.Monday;
        public const int MikeDay1DayNumber = 1;
        // Breakfast (Overnight Oats + Greek Yogurt) + Lunch (Chicken Rice Bowl) + Dinner (Chicken Stir Fry)
        public const float MikeDay1Calories = MealConstants.MikeDay1BreakfastCalories + MealConstants.MikeDay1LunchCalories + MealConstants.MikeDay1DinnerCalories;
        public const float MikeDay1Protein = MealConstants.MikeDay1BreakfastProtein + MealConstants.MikeDay1LunchProtein + MealConstants.MikeDay1DinnerProtein;
        public const float MikeDay1Carbs = MealConstants.MikeDay1BreakfastCarbs + MealConstants.MikeDay1LunchCarbs + MealConstants.MikeDay1DinnerCarbs;
        public const float MikeDay1Fat = MealConstants.MikeDay1BreakfastFat + MealConstants.MikeDay1LunchFat + MealConstants.MikeDay1DinnerFat;

        // ========== Mike - Day 2 ==========
        public const string MikeDay2Id = "f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c";
        public const DayOfWeek MikeDay2DayOfWeek = DayOfWeek.Tuesday;
        public const int MikeDay2DayNumber = 2;
        // Breakfast (Veggie Omelette) + Lunch (Chicken Stir Fry) + Dinner (Grilled Salmon Quinoa)
        public const float MikeDay2Calories = MealConstants.MikeDay2BreakfastCalories + MealConstants.MikeDay2LunchCalories + MealConstants.MikeDay2DinnerCalories;
        public const float MikeDay2Protein = MealConstants.MikeDay2BreakfastProtein + MealConstants.MikeDay2LunchProtein + MealConstants.MikeDay2DinnerProtein;
        public const float MikeDay2Carbs = MealConstants.MikeDay2BreakfastCarbs + MealConstants.MikeDay2LunchCarbs + MealConstants.MikeDay2DinnerCarbs;
        public const float MikeDay2Fat = MealConstants.MikeDay2BreakfastFat + MealConstants.MikeDay2LunchFat + MealConstants.MikeDay2DinnerFat;

        // ========== Mike - Day 3 ==========
        public const string MikeDay3Id = "a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d";
        public const DayOfWeek MikeDay3DayOfWeek = DayOfWeek.Wednesday;
        public const int MikeDay3DayNumber = 3;
        // Breakfast (Overnight Oats) + Lunch (Chicken Rice Bowl) + Dinner (Chicken Stir Fry)
        public const float MikeDay3Calories = MealConstants.MikeDay3BreakfastCalories + MealConstants.MikeDay3LunchCalories + MealConstants.MikeDay3DinnerCalories;
        public const float MikeDay3Protein = MealConstants.MikeDay3BreakfastProtein + MealConstants.MikeDay3LunchProtein + MealConstants.MikeDay3DinnerProtein;
        public const float MikeDay3Carbs = MealConstants.MikeDay3BreakfastCarbs + MealConstants.MikeDay3LunchCarbs + MealConstants.MikeDay3DinnerCarbs;
        public const float MikeDay3Fat = MealConstants.MikeDay3BreakfastFat + MealConstants.MikeDay3LunchFat + MealConstants.MikeDay3DinnerFat;

        // ========== Mike - Day 4 ==========
        public const string MikeDay4Id = "b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e";
        public const DayOfWeek MikeDay4DayOfWeek = DayOfWeek.Thursday;
        public const int MikeDay4DayNumber = 4;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Grilled Salmon Quinoa) + Dinner (Chicken Rice Bowl)
        public const float MikeDay4Calories = MealConstants.MikeDay4BreakfastCalories + MealConstants.MikeDay4LunchCalories + MealConstants.MikeDay4DinnerCalories;
        public const float MikeDay4Protein = MealConstants.MikeDay4BreakfastProtein + MealConstants.MikeDay4LunchProtein + MealConstants.MikeDay4DinnerProtein;
        public const float MikeDay4Carbs = MealConstants.MikeDay4BreakfastCarbs + MealConstants.MikeDay4LunchCarbs + MealConstants.MikeDay4DinnerCarbs;
        public const float MikeDay4Fat = MealConstants.MikeDay4BreakfastFat + MealConstants.MikeDay4LunchFat + MealConstants.MikeDay4DinnerFat;

        // ========== Mike - Day 5 ==========
        public const string MikeDay5Id = "c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f";
        public const DayOfWeek MikeDay5DayOfWeek = DayOfWeek.Friday;
        public const int MikeDay5DayNumber = 5;
        // Breakfast (Overnight Oats) + Lunch (Chicken Stir Fry) + Dinner (Chicken Rice Bowl)
        public const float MikeDay5Calories = MealConstants.MikeDay5BreakfastCalories + MealConstants.MikeDay5LunchCalories + MealConstants.MikeDay5DinnerCalories;
        public const float MikeDay5Protein = MealConstants.MikeDay5BreakfastProtein + MealConstants.MikeDay5LunchProtein + MealConstants.MikeDay5DinnerProtein;
        public const float MikeDay5Carbs = MealConstants.MikeDay5BreakfastCarbs + MealConstants.MikeDay5LunchCarbs + MealConstants.MikeDay5DinnerCarbs;
        public const float MikeDay5Fat = MealConstants.MikeDay5BreakfastFat + MealConstants.MikeDay5LunchFat + MealConstants.MikeDay5DinnerFat;

        // ═══════════════════════════════════════════════════════════
        // EMMA'S BALANCED NUTRITION - 5 Days
        // ═══════════════════════════════════════════════════════════

        // ========== Emma - Day 1 ==========
        public const string EmmaDay1Id = "d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a";
        public const DayOfWeek EmmaDay1DayOfWeek = DayOfWeek.Monday;
        public const int EmmaDay1DayNumber = 1;
        // Breakfast (Greek Yogurt Bowl + Banana) + Lunch (Grilled Salmon Quinoa) + Dinner (Mediterranean Salad)
        public const float EmmaDay1Calories = MealConstants.EmmaDay1BreakfastCalories + MealConstants.EmmaDay1LunchCalories + MealConstants.EmmaDay1DinnerCalories;
        public const float EmmaDay1Protein = MealConstants.EmmaDay1BreakfastProtein + MealConstants.EmmaDay1LunchProtein + MealConstants.EmmaDay1DinnerProtein;
        public const float EmmaDay1Carbs = MealConstants.EmmaDay1BreakfastCarbs + MealConstants.EmmaDay1LunchCarbs + MealConstants.EmmaDay1DinnerCarbs;
        public const float EmmaDay1Fat = MealConstants.EmmaDay1BreakfastFat + MealConstants.EmmaDay1LunchFat + MealConstants.EmmaDay1DinnerFat;

        // ========== Emma - Day 2 ==========
        public const string EmmaDay2Id = "e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b";
        public const DayOfWeek EmmaDay2DayOfWeek = DayOfWeek.Tuesday;
        public const int EmmaDay2DayNumber = 2;
        // Breakfast (Overnight Oats) + Lunch (Chicken Rice Bowl) + Dinner (Buddha Bowl)
        public const float EmmaDay2Calories = MealConstants.EmmaDay2BreakfastCalories + MealConstants.EmmaDay2LunchCalories + MealConstants.EmmaDay2DinnerCalories;
        public const float EmmaDay2Protein = MealConstants.EmmaDay2BreakfastProtein + MealConstants.EmmaDay2LunchProtein + MealConstants.EmmaDay2DinnerProtein;
        public const float EmmaDay2Carbs = MealConstants.EmmaDay2BreakfastCarbs + MealConstants.EmmaDay2LunchCarbs + MealConstants.EmmaDay2DinnerCarbs;
        public const float EmmaDay2Fat = MealConstants.EmmaDay2BreakfastFat + MealConstants.EmmaDay2LunchFat + MealConstants.EmmaDay2DinnerFat;

        // ========== Emma - Day 3 ==========
        public const string EmmaDay3Id = "f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c";
        public const DayOfWeek EmmaDay3DayOfWeek = DayOfWeek.Wednesday;
        public const int EmmaDay3DayNumber = 3;
        // Breakfast (Veggie Omelette) + Lunch (Mediterranean Salad) + Dinner (Grilled Salmon Quinoa)
        public const float EmmaDay3Calories = MealConstants.EmmaDay3BreakfastCalories + MealConstants.EmmaDay3LunchCalories + MealConstants.EmmaDay3DinnerCalories;
        public const float EmmaDay3Protein = MealConstants.EmmaDay3BreakfastProtein + MealConstants.EmmaDay3LunchProtein + MealConstants.EmmaDay3DinnerProtein;
        public const float EmmaDay3Carbs = MealConstants.EmmaDay3BreakfastCarbs + MealConstants.EmmaDay3LunchCarbs + MealConstants.EmmaDay3DinnerCarbs;
        public const float EmmaDay3Fat = MealConstants.EmmaDay3BreakfastFat + MealConstants.EmmaDay3LunchFat + MealConstants.EmmaDay3DinnerFat;

        // ========== Emma - Day 4 ==========
        public const string EmmaDay4Id = "a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d";
        public const DayOfWeek EmmaDay4DayOfWeek = DayOfWeek.Thursday;
        public const int EmmaDay4DayNumber = 4;
        // Breakfast (Greek Yogurt Bowl) + Lunch (Chicken Stir Fry) + Dinner (Buddha Bowl)
        public const float EmmaDay4Calories = MealConstants.EmmaDay4BreakfastCalories + MealConstants.EmmaDay4LunchCalories + MealConstants.EmmaDay4DinnerCalories;
        public const float EmmaDay4Protein = MealConstants.EmmaDay4BreakfastProtein + MealConstants.EmmaDay4LunchProtein + MealConstants.EmmaDay4DinnerProtein;
        public const float EmmaDay4Carbs = MealConstants.EmmaDay4BreakfastCarbs + MealConstants.EmmaDay4LunchCarbs + MealConstants.EmmaDay4DinnerCarbs;
        public const float EmmaDay4Fat = MealConstants.EmmaDay4BreakfastFat + MealConstants.EmmaDay4LunchFat + MealConstants.EmmaDay4DinnerFat;

        // ========== Emma - Day 5 ==========
        public const string EmmaDay5Id = "b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e";
        public const DayOfWeek EmmaDay5DayOfWeek = DayOfWeek.Friday;
        public const int EmmaDay5DayNumber = 5;
        // Breakfast (Overnight Oats) + Lunch (Grilled Salmon Quinoa) + Dinner (Mediterranean Salad)
        public const float EmmaDay5Calories = MealConstants.EmmaDay5BreakfastCalories + MealConstants.EmmaDay5LunchCalories + MealConstants.EmmaDay5DinnerCalories;
        public const float EmmaDay5Protein = MealConstants.EmmaDay5BreakfastProtein + MealConstants.EmmaDay5LunchProtein + MealConstants.EmmaDay5DinnerProtein;
        public const float EmmaDay5Carbs = MealConstants.EmmaDay5BreakfastCarbs + MealConstants.EmmaDay5LunchCarbs + MealConstants.EmmaDay5DinnerCarbs;
        public const float EmmaDay5Fat = MealConstants.EmmaDay5BreakfastFat + MealConstants.EmmaDay5LunchFat + MealConstants.EmmaDay5DinnerFat;
    }
}