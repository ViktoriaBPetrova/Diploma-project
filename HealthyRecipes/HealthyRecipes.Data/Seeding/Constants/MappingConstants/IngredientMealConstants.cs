using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MappingConstants
{
    // These represent side ingredients added to meals to balance macros and hit nutritional goals.
    public class IngredientMealConstants
    {
        // ========== JOHN'S MEAL PLAN - Day 1 Breakfast ==========
        // Recipe: Veggie Omelette (has eggs, spinach, bell pepper, onion, olive oil)
        // Needs: Mixed Berries - for fiber and micronutrients
        public const string JohnDay1Breakfast_BerriesIngredientId = IngredientConstants.BerriesId;
        public const string JohnDay1Breakfast_BerriesMealId = MealPlanConstants.MealConstants.JohnDay1BreakfastId;
        public const float JohnDay1Breakfast_BerriesQuantityInGrams = 100f; // 1 cup of mixed berries
        public const string JohnDay1Breakfast_BerriesOriginalUnit = "cup";
        public const float JohnDay1Breakfast_BerriesQuantityInCups = 1f;
        public const float JohnDay1Breakfast_BerriesCalories = ((IngredientConstants.BerriesCaloriesPer100g / 100) * JohnDay1Breakfast_BerriesQuantityInGrams);
        public const float JohnDay1Breakfast_BerriesProtein = ((IngredientConstants.BerriesFatPer100g / 100) * JohnDay1Breakfast_BerriesQuantityInGrams);
        public const float JohnDay1Breakfast_BerriesCarbs = ((IngredientConstants.BerriesCarbsPer100g / 100) * JohnDay1Breakfast_BerriesQuantityInGrams);
        public const float JohnDay1Breakfast_BerriesFat = ((IngredientConstants.BerriesFatPer100g / 100) * JohnDay1Breakfast_BerriesQuantityInGrams);

        // ========== MIKE'S MEAL PLAN - Day 1 Breakfast ========== porotein
        // Recipe: Overnight Oats (has oats, almond milk, chia seeds, banana, honey)
        // High carb athlete needs: Greek Yogurt - for extra protein
        public const string MikeDay1Breakfast_GreekYogurtIngredientId = IngredientConstants.GreekYogurtId;
        public const string MikeDay1Breakfast_GreekYogurtMealId = MealPlanConstants.MealConstants.MikeDay1BreakfastId;
        public const float MikeDay1Breakfast_GreekYogurtQuantityInGrams = 150f; // about 3/4 cup
        public const string MikeDay1Breakfast_GreekYogurtOriginalUnit = "grams";
        public const float MikeDay1Breakfast_GreekYogurtCalories = ((IngredientConstants.GreekYogurtCaloriesPer100g / 100) * MikeDay1Breakfast_GreekYogurtQuantityInGrams);
        public const float MikeDay1Breakfast_GreekYogurtProtein = ((IngredientConstants.GreekYogurtProteinPer100g / 100) * MikeDay1Breakfast_GreekYogurtQuantityInGrams);
        public const float MikeDay1Breakfast_GreekYogurtCarbs = ((IngredientConstants.GreekYogurtCarbsPer100g / 100) * MikeDay1Breakfast_GreekYogurtQuantityInGrams);
        public const float MikeDay1Breakfast_GreekYogurtFat = ((IngredientConstants.GreekYogurtFatPer100g / 100) * MikeDay1Breakfast_GreekYogurtQuantityInGrams);

        // ========== EMMA'S MEAL PLAN - Day 1 Breakfast ==========sustainable
        // Recipe: Greek Yogurt Bowl (has Greek yogurt, blueberries, almonds, honey)
        // Adding: Banana for extra carbs and potassium
        public const string EmmaDay1Breakfast_BananaIngredientId = IngredientConstants.BananaId;
        public const string EmmaDay1Breakfast_BananaMealId = MealPlanConstants.MealConstants.EmmaDay1BreakfastId;
        public const float EmmaDay1Breakfast_BananaQuantityInGrams = 80f; 
        public const string EmmaDay1Breakfast_BananaOriginalUnit = "grams";
        public const float EmmaDay1Breakfast_BananaCalories = ((IngredientConstants.BananaCaloriesPer100g / 100) * EmmaDay1Breakfast_BananaQuantityInGrams);
        public const float EmmaDay1Breakfast_BananaProtein = ((IngredientConstants.BananaProteinPer100g / 100) * EmmaDay1Breakfast_BananaQuantityInGrams);
        public const float EmmaDay1Breakfast_BananaCarbs = ((IngredientConstants.BananaCarbsPer100g / 100) * EmmaDay1Breakfast_BananaQuantityInGrams);
        public const float EmmaDay1Breakfast_BananaFat = ((IngredientConstants.BananaFatPer100g / 100) * EmmaDay1Breakfast_BananaQuantityInGrams);

    }
}
