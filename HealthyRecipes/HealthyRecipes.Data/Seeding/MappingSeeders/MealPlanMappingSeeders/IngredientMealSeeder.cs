using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanMappingSeeders
{
    public class IngredientMealSeeder
    {
        public static IEnumerable<IngredientMeal> GenerateIngredientMeals()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<IngredientMeal> ingredientMeals = new List<IngredientMeal>()
            {
                                // ========== JOHN'S MEAL PLAN (High Protein Focus) ==========
                // Day 1 Breakfast: Veggie Omelette + sides
                // Recipe has: Eggs (protein), spinach, bell pepper, onion (veggies/fiber), olive oil (fat)
                // Adding: Berries (fiber)
                new IngredientMeal(
                    IngredientMealConstants.JohnDay1Breakfast_BerriesIngredientId,
                    IngredientMealConstants.JohnDay1Breakfast_BerriesMealId,
                    seedingDate)
                {
                    QuantityInGrams = IngredientMealConstants.JohnDay1Breakfast_BerriesQuantityInGrams,
                    QuantityInCups = IngredientMealConstants.JohnDay1Breakfast_BerriesQuantityInCups,
                    OriginalUnit = IngredientMealConstants.JohnDay1Breakfast_BerriesOriginalUnit,
                },
 
                // ========== MIKE'S MEAL PLAN (High Carb/Protein for Marathon Training) ==========
                // Day 1 Breakfast: Overnight Oats + sides
                // Recipe has: Oats (carbs), almond milk, chia seeds (fat), banana (carbs), honey
                // Adding: Greek yogurt (extra protein for recovery)
                new IngredientMeal(
                    IngredientMealConstants.MikeDay1Breakfast_GreekYogurtIngredientId,
                    IngredientMealConstants.MikeDay1Breakfast_GreekYogurtMealId,
                    seedingDate)
                {
                    QuantityInGrams = IngredientMealConstants.MikeDay1Breakfast_GreekYogurtQuantityInGrams,
                    OriginalUnit = IngredientMealConstants.MikeDay1Breakfast_GreekYogurtOriginalUnit
                },
 
                // ========== EMMA'S MEAL PLAN (Balanced Nutrition) ==========
                // Day 1 Breakfast: Greek Yogurt Bowl + sides
                // Recipe has: Greek yogurt (protein), blueberries (fiber), almonds (fat), honey (carbs)
                // Adding: Banana
                new IngredientMeal(
                    IngredientMealConstants.EmmaDay1Breakfast_BananaIngredientId,
                    IngredientMealConstants.EmmaDay1Breakfast_BananaMealId,
                    seedingDate)
                {
                    QuantityInGrams = IngredientMealConstants.EmmaDay1Breakfast_BananaQuantityInGrams,
                    OriginalUnit = IngredientMealConstants.EmmaDay1Breakfast_BananaOriginalUnit
                },
            };

            return ingredientMeals;
        }
    }
}
