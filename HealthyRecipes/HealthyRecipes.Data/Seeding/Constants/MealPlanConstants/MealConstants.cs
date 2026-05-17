using HealthyRecipes.Data.Enums;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MealPlanConstants
{
    public class MealConstants
    {
        // Note: Each MealPlanDay will have 3 meals: Breakfast, Lunch, Dinner
        // Total: 4 Users × 5 Days × 3 Meals = 60 Meal IDs
        // Macros = Recipe Macros + Ingredient Macros (where applicable)

        // ═══════════════════════════════════════════════════════════
        // JOHN'S MEAL PLAN (High Protein Focus)
        // ═══════════════════════════════════════════════════════════

        // ========== JOHN'S MEAL PLAN - Day 1 ==========
        public const string JohnDay1BreakfastId = "11111111-1111-4111-8111-111111111111";
        public const MealType JohnDay1BreakfastType = MealType.Breakfast;
        // Veggie Omelette + Berries (100g)
        public const float JohnDay1BreakfastCalories = RecipeMealConstants.JohnDay1Breakfast_VeggieOmeletteCalories + IngredientMealConstants.JohnDay1Breakfast_BerriesCalories;
        public const float JohnDay1BreakfastProtein = RecipeMealConstants.JohnDay1Breakfast_VeggieOmeletteProtein + IngredientMealConstants.JohnDay1Breakfast_BerriesProtein;
        public const float JohnDay1BreakfastCarbs = RecipeMealConstants.JohnDay1Breakfast_VeggieOmeletteCarbs + IngredientMealConstants.JohnDay1Breakfast_BerriesCarbs;
        public const float JohnDay1BreakfastFat = RecipeMealConstants.JohnDay1Breakfast_VeggieOmeletteFat + IngredientMealConstants.JohnDay1Breakfast_BerriesFat;

        public const string JohnDay1LunchId = "11111111-1111-4111-8111-111111111112";
        public const MealType JohnDay1LunchType = MealType.Lunch;
        // Chicken Rice Bowl (no sides)
        public const float JohnDay1LunchCalories = RecipeMealConstants.JohnDay1Lunch_ChickenRiceBowlCalories;
        public const float JohnDay1LunchProtein = RecipeMealConstants.JohnDay1Lunch_ChickenRiceBowlProtein;
        public const float JohnDay1LunchCarbs = RecipeMealConstants.JohnDay1Lunch_ChickenRiceBowlCarbs;
        public const float JohnDay1LunchFat = RecipeMealConstants.JohnDay1Lunch_ChickenRiceBowlFat;

        public const string JohnDay1DinnerId = "11111111-1111-4111-8111-111111111113";
        public const MealType JohnDay1DinnerType = MealType.Dinner;
        // Grilled Salmon Quinoa (no sides)
        public const float JohnDay1DinnerCalories = RecipeMealConstants.JohnDay1Dinner_GrilledSalmonQuinoaCalories;
        public const float JohnDay1DinnerProtein = RecipeMealConstants.JohnDay1Dinner_GrilledSalmonQuinoaProtein;
        public const float JohnDay1DinnerCarbs = RecipeMealConstants.JohnDay1Dinner_GrilledSalmonQuinoaCarbs;
        public const float JohnDay1DinnerFat = RecipeMealConstants.JohnDay1Dinner_GrilledSalmonQuinoaFat;

        // ========== JOHN'S MEAL PLAN - Day 2 ==========
        public const string JohnDay2BreakfastId = "11111111-1111-4111-8111-111111111121";
        public const MealType JohnDay2BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float JohnDay2BreakfastCalories = RecipeMealConstants.JohnDay2Breakfast_GreekYogurtBowlCalories;
        public const float JohnDay2BreakfastProtein = RecipeMealConstants.JohnDay2Breakfast_GreekYogurtBowlProtein;
        public const float JohnDay2BreakfastCarbs = RecipeMealConstants.JohnDay2Breakfast_GreekYogurtBowlCarbs;
        public const float JohnDay2BreakfastFat = RecipeMealConstants.JohnDay2Breakfast_GreekYogurtBowlFat;

        public const string JohnDay2LunchId = "11111111-1111-4111-8111-111111111122";
        public const MealType JohnDay2LunchType = MealType.Lunch;
        // Chicken Stir Fry (no sides)
        public const float JohnDay2LunchCalories = RecipeMealConstants.JohnDay2Lunch_ChickenStirFryCalories;
        public const float JohnDay2LunchProtein = RecipeMealConstants.JohnDay2Lunch_ChickenStirFryProtein;
        public const float JohnDay2LunchCarbs = RecipeMealConstants.JohnDay2Lunch_ChickenStirFryCarbs;
        public const float JohnDay2LunchFat = RecipeMealConstants.JohnDay2Lunch_ChickenStirFryFat;

        public const string JohnDay2DinnerId = "11111111-1111-4111-8111-111111111123";
        public const MealType JohnDay2DinnerType = MealType.Dinner;
        // Chicken Rice Bowl (no sides)
        public const float JohnDay2DinnerCalories = RecipeMealConstants.JohnDay2Dinner_ChickenRiceBowlCalories;
        public const float JohnDay2DinnerProtein = RecipeMealConstants.JohnDay2Dinner_ChickenRiceBowlProtein;
        public const float JohnDay2DinnerCarbs = RecipeMealConstants.JohnDay2Dinner_ChickenRiceBowlCarbs;
        public const float JohnDay2DinnerFat = RecipeMealConstants.JohnDay2Dinner_ChickenRiceBowlFat;

        // ========== JOHN'S MEAL PLAN - Day 3 ==========
        public const string JohnDay3BreakfastId = "11111111-1111-4111-8111-111111111131";
        public const MealType JohnDay3BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float JohnDay3BreakfastCalories = RecipeMealConstants.JohnDay3Breakfast_OvernightOatsCalories;
        public const float JohnDay3BreakfastProtein = RecipeMealConstants.JohnDay3Breakfast_OvernightOatsProtein;
        public const float JohnDay3BreakfastCarbs = RecipeMealConstants.JohnDay3Breakfast_OvernightOatsCarbs;
        public const float JohnDay3BreakfastFat = RecipeMealConstants.JohnDay3Breakfast_OvernightOatsFat;

        public const string JohnDay3LunchId = "11111111-1111-4111-8111-111111111132";
        public const MealType JohnDay3LunchType = MealType.Lunch;
        // Grilled Salmon Quinoa (no sides)
        public const float JohnDay3LunchCalories = RecipeMealConstants.JohnDay3Lunch_GrilledSalmonQuinoaCalories;
        public const float JohnDay3LunchProtein = RecipeMealConstants.JohnDay3Lunch_GrilledSalmonQuinoaProtein;
        public const float JohnDay3LunchCarbs = RecipeMealConstants.JohnDay3Lunch_GrilledSalmonQuinoaCarbs;
        public const float JohnDay3LunchFat = RecipeMealConstants.JohnDay3Lunch_GrilledSalmonQuinoaFat;

        public const string JohnDay3DinnerId = "11111111-1111-4111-8111-111111111133";
        public const MealType JohnDay3DinnerType = MealType.Dinner;
        // Veggie Omelette (no sides)
        public const float JohnDay3DinnerCalories = RecipeMealConstants.JohnDay3Dinner_VeggieOmeletteCalories;
        public const float JohnDay3DinnerProtein = RecipeMealConstants.JohnDay3Dinner_VeggieOmeletteProtein;
        public const float JohnDay3DinnerCarbs = RecipeMealConstants.JohnDay3Dinner_VeggieOmeletteCarbs;
        public const float JohnDay3DinnerFat = RecipeMealConstants.JohnDay3Dinner_VeggieOmeletteFat;

        // ========== JOHN'S MEAL PLAN - Day 4 ==========
        public const string JohnDay4BreakfastId = "11111111-1111-4111-8111-111111111141";
        public const MealType JohnDay4BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float JohnDay4BreakfastCalories = RecipeMealConstants.JohnDay4Breakfast_GreekYogurtBowlCalories;
        public const float JohnDay4BreakfastProtein = RecipeMealConstants.JohnDay4Breakfast_GreekYogurtBowlProtein;
        public const float JohnDay4BreakfastCarbs = RecipeMealConstants.JohnDay4Breakfast_GreekYogurtBowlCarbs;
        public const float JohnDay4BreakfastFat = RecipeMealConstants.JohnDay4Breakfast_GreekYogurtBowlFat;

        public const string JohnDay4LunchId = "11111111-1111-4111-8111-111111111142";
        public const MealType JohnDay4LunchType = MealType.Lunch;
        // Chicken Rice Bowl (no sides)
        public const float JohnDay4LunchCalories = RecipeMealConstants.JohnDay4Lunch_ChickenRiceBowlCalories;
        public const float JohnDay4LunchProtein = RecipeMealConstants.JohnDay4Lunch_ChickenRiceBowlProtein;
        public const float JohnDay4LunchCarbs = RecipeMealConstants.JohnDay4Lunch_ChickenRiceBowlCarbs;
        public const float JohnDay4LunchFat = RecipeMealConstants.JohnDay4Lunch_ChickenRiceBowlFat;

        public const string JohnDay4DinnerId = "11111111-1111-4111-8111-111111111143";
        public const MealType JohnDay4DinnerType = MealType.Dinner;
        // Chicken Stir Fry (no sides)
        public const float JohnDay4DinnerCalories = RecipeMealConstants.JohnDay4Dinner_ChickenStirFryCalories;
        public const float JohnDay4DinnerProtein = RecipeMealConstants.JohnDay4Dinner_ChickenStirFryProtein;
        public const float JohnDay4DinnerCarbs = RecipeMealConstants.JohnDay4Dinner_ChickenStirFryCarbs;
        public const float JohnDay4DinnerFat = RecipeMealConstants.JohnDay4Dinner_ChickenStirFryFat;

        // ========== JOHN'S MEAL PLAN - Day 5 ==========
        public const string JohnDay5BreakfastId = "11111111-1111-4111-8111-111111111151";
        public const MealType JohnDay5BreakfastType = MealType.Breakfast;
        // Veggie Omelette (no sides)
        public const float JohnDay5BreakfastCalories = RecipeMealConstants.JohnDay5Breakfast_VeggieOmeletteCalories;
        public const float JohnDay5BreakfastProtein = RecipeMealConstants.JohnDay5Breakfast_VeggieOmeletteProtein;
        public const float JohnDay5BreakfastCarbs = RecipeMealConstants.JohnDay5Breakfast_VeggieOmeletteCarbs;
        public const float JohnDay5BreakfastFat = RecipeMealConstants.JohnDay5Breakfast_VeggieOmeletteFat;

        public const string JohnDay5LunchId = "11111111-1111-4111-8111-111111111152";
        public const MealType JohnDay5LunchType = MealType.Lunch;
        // Grilled Salmon Quinoa (no sides)
        public const float JohnDay5LunchCalories = RecipeMealConstants.JohnDay5Lunch_GrilledSalmonQuinoaCalories;
        public const float JohnDay5LunchProtein = RecipeMealConstants.JohnDay5Lunch_GrilledSalmonQuinoaProtein;
        public const float JohnDay5LunchCarbs = RecipeMealConstants.JohnDay5Lunch_GrilledSalmonQuinoaCarbs;
        public const float JohnDay5LunchFat = RecipeMealConstants.JohnDay5Lunch_GrilledSalmonQuinoaFat;

        public const string JohnDay5DinnerId = "11111111-1111-4111-8111-111111111153";
        public const MealType JohnDay5DinnerType = MealType.Dinner;
        // Chicken Rice Bowl (no sides)
        public const float JohnDay5DinnerCalories = RecipeMealConstants.JohnDay5Dinner_ChickenRiceBowlCalories;
        public const float JohnDay5DinnerProtein = RecipeMealConstants.JohnDay5Dinner_ChickenRiceBowlProtein;
        public const float JohnDay5DinnerCarbs = RecipeMealConstants.JohnDay5Dinner_ChickenRiceBowlCarbs;
        public const float JohnDay5DinnerFat = RecipeMealConstants.JohnDay5Dinner_ChickenRiceBowlFat;

        // ═══════════════════════════════════════════════════════════
        // SARAH'S MEAL PLAN (Plant-Based Focus)
        // ═══════════════════════════════════════════════════════════

        // ========== SARAH'S MEAL PLAN - Day 1 ==========
        public const string SarahDay1BreakfastId = "22222222-2222-4222-8222-222222222211";
        public const MealType SarahDay1BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float SarahDay1BreakfastCalories = RecipeMealConstants.SarahDay1Breakfast_GreekYogurtBowlCalories;
        public const float SarahDay1BreakfastProtein = RecipeMealConstants.SarahDay1Breakfast_GreekYogurtBowlProtein;
        public const float SarahDay1BreakfastCarbs = RecipeMealConstants.SarahDay1Breakfast_GreekYogurtBowlCarbs;
        public const float SarahDay1BreakfastFat = RecipeMealConstants.SarahDay1Breakfast_GreekYogurtBowlFat;

        public const string SarahDay1LunchId = "22222222-2222-4222-8222-222222222212";
        public const MealType SarahDay1LunchType = MealType.Lunch;
        // Buddha Bowl (no sides)
        public const float SarahDay1LunchCalories = RecipeMealConstants.SarahDay1Lunch_BuddhaBowlCalories;
        public const float SarahDay1LunchProtein = RecipeMealConstants.SarahDay1Lunch_BuddhaBowlProtein;
        public const float SarahDay1LunchCarbs = RecipeMealConstants.SarahDay1Lunch_BuddhaBowlCarbs;
        public const float SarahDay1LunchFat = RecipeMealConstants.SarahDay1Lunch_BuddhaBowlFat;

        public const string SarahDay1DinnerId = "22222222-2222-4222-8222-222222222213";
        public const MealType SarahDay1DinnerType = MealType.Dinner;
        // Mediterranean Salad (no sides)
        public const float SarahDay1DinnerCalories = RecipeMealConstants.SarahDay1Dinner_MediterraneanSaladCalories;
        public const float SarahDay1DinnerProtein = RecipeMealConstants.SarahDay1Dinner_MediterraneanSaladProtein;
        public const float SarahDay1DinnerCarbs = RecipeMealConstants.SarahDay1Dinner_MediterraneanSaladCarbs;
        public const float SarahDay1DinnerFat = RecipeMealConstants.SarahDay1Dinner_MediterraneanSaladFat;

        // ========== SARAH'S MEAL PLAN - Day 2 ==========
        public const string SarahDay2BreakfastId = "22222222-2222-4222-8222-222222222221";
        public const MealType SarahDay2BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float SarahDay2BreakfastCalories = RecipeMealConstants.SarahDay2Breakfast_OvernightOatsCalories;
        public const float SarahDay2BreakfastProtein = RecipeMealConstants.SarahDay2Breakfast_OvernightOatsProtein;
        public const float SarahDay2BreakfastCarbs = RecipeMealConstants.SarahDay2Breakfast_OvernightOatsCarbs;
        public const float SarahDay2BreakfastFat = RecipeMealConstants.SarahDay2Breakfast_OvernightOatsFat;

        public const string SarahDay2LunchId = "22222222-2222-4222-8222-222222222222";
        public const MealType SarahDay2LunchType = MealType.Lunch;
        // Buddha Bowl (no sides)
        public const float SarahDay2LunchCalories = RecipeMealConstants.SarahDay2Lunch_BuddhaBowlCalories;
        public const float SarahDay2LunchProtein = RecipeMealConstants.SarahDay2Lunch_BuddhaBowlProtein;
        public const float SarahDay2LunchCarbs = RecipeMealConstants.SarahDay2Lunch_BuddhaBowlCarbs;
        public const float SarahDay2LunchFat = RecipeMealConstants.SarahDay2Lunch_BuddhaBowlFat;

        public const string SarahDay2DinnerId = "22222222-2222-4222-8222-222222222223";
        public const MealType SarahDay2DinnerType = MealType.Dinner;
        // Greek Yogurt Bowl (no sides)
        public const float SarahDay2DinnerCalories = RecipeMealConstants.SarahDay2Dinner_GreekYogurtBowlCalories;
        public const float SarahDay2DinnerProtein = RecipeMealConstants.SarahDay2Dinner_GreekYogurtBowlProtein;
        public const float SarahDay2DinnerCarbs = RecipeMealConstants.SarahDay2Dinner_GreekYogurtBowlCarbs;
        public const float SarahDay2DinnerFat = RecipeMealConstants.SarahDay2Dinner_GreekYogurtBowlFat;

        // ========== SARAH'S MEAL PLAN - Day 3 ==========
        public const string SarahDay3BreakfastId = "22222222-2222-4222-8222-222222222231";
        public const MealType SarahDay3BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float SarahDay3BreakfastCalories = RecipeMealConstants.SarahDay3Breakfast_GreekYogurtBowlCalories;
        public const float SarahDay3BreakfastProtein = RecipeMealConstants.SarahDay3Breakfast_GreekYogurtBowlProtein;
        public const float SarahDay3BreakfastCarbs = RecipeMealConstants.SarahDay3Breakfast_GreekYogurtBowlCarbs;
        public const float SarahDay3BreakfastFat = RecipeMealConstants.SarahDay3Breakfast_GreekYogurtBowlFat;

        public const string SarahDay3LunchId = "22222222-2222-4222-8222-222222222232";
        public const MealType SarahDay3LunchType = MealType.Lunch;
        // Mediterranean Salad (no sides)
        public const float SarahDay3LunchCalories = RecipeMealConstants.SarahDay3Lunch_MediterraneanSaladCalories;
        public const float SarahDay3LunchProtein = RecipeMealConstants.SarahDay3Lunch_MediterraneanSaladProtein;
        public const float SarahDay3LunchCarbs = RecipeMealConstants.SarahDay3Lunch_MediterraneanSaladCarbs;
        public const float SarahDay3LunchFat = RecipeMealConstants.SarahDay3Lunch_MediterraneanSaladFat;

        public const string SarahDay3DinnerId = "22222222-2222-4222-8222-222222222233";
        public const MealType SarahDay3DinnerType = MealType.Dinner;
        // Buddha Bowl (no sides)
        public const float SarahDay3DinnerCalories = RecipeMealConstants.SarahDay3Dinner_BuddhaBowlCalories;
        public const float SarahDay3DinnerProtein = RecipeMealConstants.SarahDay3Dinner_BuddhaBowlProtein;
        public const float SarahDay3DinnerCarbs = RecipeMealConstants.SarahDay3Dinner_BuddhaBowlCarbs;
        public const float SarahDay3DinnerFat = RecipeMealConstants.SarahDay3Dinner_BuddhaBowlFat;

        // ========== SARAH'S MEAL PLAN - Day 4 ==========
        public const string SarahDay4BreakfastId = "22222222-2222-4222-8222-222222222241";
        public const MealType SarahDay4BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float SarahDay4BreakfastCalories = RecipeMealConstants.SarahDay4Breakfast_OvernightOatsCalories;
        public const float SarahDay4BreakfastProtein = RecipeMealConstants.SarahDay4Breakfast_OvernightOatsProtein;
        public const float SarahDay4BreakfastCarbs = RecipeMealConstants.SarahDay4Breakfast_OvernightOatsCarbs;
        public const float SarahDay4BreakfastFat = RecipeMealConstants.SarahDay4Breakfast_OvernightOatsFat;

        public const string SarahDay4LunchId = "22222222-2222-4222-8222-222222222242";
        public const MealType SarahDay4LunchType = MealType.Lunch;
        // Buddha Bowl (no sides)
        public const float SarahDay4LunchCalories = RecipeMealConstants.SarahDay4Lunch_BuddhaBowlCalories;
        public const float SarahDay4LunchProtein = RecipeMealConstants.SarahDay4Lunch_BuddhaBowlProtein;
        public const float SarahDay4LunchCarbs = RecipeMealConstants.SarahDay4Lunch_BuddhaBowlCarbs;
        public const float SarahDay4LunchFat = RecipeMealConstants.SarahDay4Lunch_BuddhaBowlFat;

        public const string SarahDay4DinnerId = "22222222-2222-4222-8222-222222222243";
        public const MealType SarahDay4DinnerType = MealType.Dinner;
        // Mediterranean Salad (no sides)
        public const float SarahDay4DinnerCalories = RecipeMealConstants.SarahDay4Dinner_MediterraneanSaladCalories;
        public const float SarahDay4DinnerProtein = RecipeMealConstants.SarahDay4Dinner_MediterraneanSaladProtein;
        public const float SarahDay4DinnerCarbs = RecipeMealConstants.SarahDay4Dinner_MediterraneanSaladCarbs;
        public const float SarahDay4DinnerFat = RecipeMealConstants.SarahDay4Dinner_MediterraneanSaladFat;

        // ========== SARAH'S MEAL PLAN - Day 5 ==========
        public const string SarahDay5BreakfastId = "22222222-2222-4222-8222-222222222251";
        public const MealType SarahDay5BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float SarahDay5BreakfastCalories = RecipeMealConstants.SarahDay5Breakfast_GreekYogurtBowlCalories;
        public const float SarahDay5BreakfastProtein = RecipeMealConstants.SarahDay5Breakfast_GreekYogurtBowlProtein;
        public const float SarahDay5BreakfastCarbs = RecipeMealConstants.SarahDay5Breakfast_GreekYogurtBowlCarbs;
        public const float SarahDay5BreakfastFat = RecipeMealConstants.SarahDay5Breakfast_GreekYogurtBowlFat;

        public const string SarahDay5LunchId = "22222222-2222-4222-8222-222222222252";
        public const MealType SarahDay5LunchType = MealType.Lunch;
        // Buddha Bowl (no sides)
        public const float SarahDay5LunchCalories = RecipeMealConstants.SarahDay5Lunch_BuddhaBowlCalories;
        public const float SarahDay5LunchProtein = RecipeMealConstants.SarahDay5Lunch_BuddhaBowlProtein;
        public const float SarahDay5LunchCarbs = RecipeMealConstants.SarahDay5Lunch_BuddhaBowlCarbs;
        public const float SarahDay5LunchFat = RecipeMealConstants.SarahDay5Lunch_BuddhaBowlFat;

        public const string SarahDay5DinnerId = "22222222-2222-4222-8222-222222222253";
        public const MealType SarahDay5DinnerType = MealType.Dinner;
        // Mediterranean Salad (no sides)
        public const float SarahDay5DinnerCalories = RecipeMealConstants.SarahDay5Dinner_MediterraneanSaladCalories;
        public const float SarahDay5DinnerProtein = RecipeMealConstants.SarahDay5Dinner_MediterraneanSaladProtein;
        public const float SarahDay5DinnerCarbs = RecipeMealConstants.SarahDay5Dinner_MediterraneanSaladCarbs;
        public const float SarahDay5DinnerFat = RecipeMealConstants.SarahDay5Dinner_MediterraneanSaladFat;

        // ═══════════════════════════════════════════════════════════
        // MIKE'S MEAL PLAN (High Carb - Marathon Training)
        // ═══════════════════════════════════════════════════════════

        // ========== MIKE'S MEAL PLAN - Day 1 ==========
        public const string MikeDay1BreakfastId = "33333333-3333-4333-8333-333333333311";
        public const MealType MikeDay1BreakfastType = MealType.Breakfast;
        // Overnight Oats + Greek Yogurt (150g)
        public const float MikeDay1BreakfastCalories = RecipeMealConstants.MikeDay1Breakfast_OvernightOatsCalories + IngredientMealConstants.MikeDay1Breakfast_GreekYogurtCalories;
        public const float MikeDay1BreakfastProtein = RecipeMealConstants.MikeDay1Breakfast_OvernightOatsProtein + IngredientMealConstants.MikeDay1Breakfast_GreekYogurtProtein;
        public const float MikeDay1BreakfastCarbs = RecipeMealConstants.MikeDay1Breakfast_OvernightOatsCarbs + IngredientMealConstants.MikeDay1Breakfast_GreekYogurtCarbs;
        public const float MikeDay1BreakfastFat = RecipeMealConstants.MikeDay1Breakfast_OvernightOatsFat + IngredientMealConstants.MikeDay1Breakfast_GreekYogurtFat;

        public const string MikeDay1LunchId = "33333333-3333-4333-8333-333333333312";
        public const MealType MikeDay1LunchType = MealType.Lunch;
        // Chicken Rice Bowl (no sides)
        public const float MikeDay1LunchCalories = RecipeMealConstants.MikeDay1Lunch_ChickenRiceBowlCalories;
        public const float MikeDay1LunchProtein = RecipeMealConstants.MikeDay1Lunch_ChickenRiceBowlProtein;
        public const float MikeDay1LunchCarbs = RecipeMealConstants.MikeDay1Lunch_ChickenRiceBowlCarbs;
        public const float MikeDay1LunchFat = RecipeMealConstants.MikeDay1Lunch_ChickenRiceBowlFat;

        public const string MikeDay1DinnerId = "33333333-3333-4333-8333-333333333313";
        public const MealType MikeDay1DinnerType = MealType.Dinner;
        // Chicken Stir Fry (no sides)
        public const float MikeDay1DinnerCalories = RecipeMealConstants.MikeDay1Dinner_ChickenStirFryCalories;
        public const float MikeDay1DinnerProtein = RecipeMealConstants.MikeDay1Dinner_ChickenStirFryProtein;
        public const float MikeDay1DinnerCarbs = RecipeMealConstants.MikeDay1Dinner_ChickenStirFryCarbs;
        public const float MikeDay1DinnerFat = RecipeMealConstants.MikeDay1Dinner_ChickenStirFryFat;

        // ========== MIKE'S MEAL PLAN - Day 2 ==========
        public const string MikeDay2BreakfastId = "33333333-3333-4333-8333-333333333321";
        public const MealType MikeDay2BreakfastType = MealType.Breakfast;
        // Veggie Omelette (no sides)
        public const float MikeDay2BreakfastCalories = RecipeMealConstants.MikeDay2Breakfast_VeggieOmeletteCalories;
        public const float MikeDay2BreakfastProtein = RecipeMealConstants.MikeDay2Breakfast_VeggieOmeletteProtein;
        public const float MikeDay2BreakfastCarbs = RecipeMealConstants.MikeDay2Breakfast_VeggieOmeletteCarbs;
        public const float MikeDay2BreakfastFat = RecipeMealConstants.MikeDay2Breakfast_VeggieOmeletteFat;

        public const string MikeDay2LunchId = "33333333-3333-4333-8333-333333333322";
        public const MealType MikeDay2LunchType = MealType.Lunch;
        // Chicken Stir Fry (no sides)
        public const float MikeDay2LunchCalories = RecipeMealConstants.MikeDay2Lunch_ChickenStirFryCalories;
        public const float MikeDay2LunchProtein = RecipeMealConstants.MikeDay2Lunch_ChickenStirFryProtein;
        public const float MikeDay2LunchCarbs = RecipeMealConstants.MikeDay2Lunch_ChickenStirFryCarbs;
        public const float MikeDay2LunchFat = RecipeMealConstants.MikeDay2Lunch_ChickenStirFryFat;

        public const string MikeDay2DinnerId = "33333333-3333-4333-8333-333333333323";
        public const MealType MikeDay2DinnerType = MealType.Dinner;
        // Grilled Salmon Quinoa (no sides)
        public const float MikeDay2DinnerCalories = RecipeMealConstants.MikeDay2Dinner_GrilledSalmonQuinoaCalories;
        public const float MikeDay2DinnerProtein = RecipeMealConstants.MikeDay2Dinner_GrilledSalmonQuinoaProtein;
        public const float MikeDay2DinnerCarbs = RecipeMealConstants.MikeDay2Dinner_GrilledSalmonQuinoaCarbs;
        public const float MikeDay2DinnerFat = RecipeMealConstants.MikeDay2Dinner_GrilledSalmonQuinoaFat;

        // ========== MIKE'S MEAL PLAN - Day 3 ==========
        public const string MikeDay3BreakfastId = "33333333-3333-4333-8333-333333333331";
        public const MealType MikeDay3BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float MikeDay3BreakfastCalories = RecipeMealConstants.MikeDay3Breakfast_OvernightOatsCalories;
        public const float MikeDay3BreakfastProtein = RecipeMealConstants.MikeDay3Breakfast_OvernightOatsProtein;
        public const float MikeDay3BreakfastCarbs = RecipeMealConstants.MikeDay3Breakfast_OvernightOatsCarbs;
        public const float MikeDay3BreakfastFat = RecipeMealConstants.MikeDay3Breakfast_OvernightOatsFat;

        public const string MikeDay3LunchId = "33333333-3333-4333-8333-333333333332";
        public const MealType MikeDay3LunchType = MealType.Lunch;
        // Chicken Rice Bowl (no sides)
        public const float MikeDay3LunchCalories = RecipeMealConstants.MikeDay3Lunch_ChickenRiceBowlCalories;
        public const float MikeDay3LunchProtein = RecipeMealConstants.MikeDay3Lunch_ChickenRiceBowlProtein;
        public const float MikeDay3LunchCarbs = RecipeMealConstants.MikeDay3Lunch_ChickenRiceBowlCarbs;
        public const float MikeDay3LunchFat = RecipeMealConstants.MikeDay3Lunch_ChickenRiceBowlFat;

        public const string MikeDay3DinnerId = "33333333-3333-4333-8333-333333333333";
        public const MealType MikeDay3DinnerType = MealType.Dinner;
        // Chicken Stir Fry (no sides)
        public const float MikeDay3DinnerCalories = RecipeMealConstants.MikeDay3Dinner_ChickenStirFryCalories;
        public const float MikeDay3DinnerProtein = RecipeMealConstants.MikeDay3Dinner_ChickenStirFryProtein;
        public const float MikeDay3DinnerCarbs = RecipeMealConstants.MikeDay3Dinner_ChickenStirFryCarbs;
        public const float MikeDay3DinnerFat = RecipeMealConstants.MikeDay3Dinner_ChickenStirFryFat;

        // ========== MIKE'S MEAL PLAN - Day 4 ==========
        public const string MikeDay4BreakfastId = "33333333-3333-4333-8333-333333333341";
        public const MealType MikeDay4BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float MikeDay4BreakfastCalories = RecipeMealConstants.MikeDay4Breakfast_GreekYogurtBowlCalories;
        public const float MikeDay4BreakfastProtein = RecipeMealConstants.MikeDay4Breakfast_GreekYogurtBowlProtein;
        public const float MikeDay4BreakfastCarbs = RecipeMealConstants.MikeDay4Breakfast_GreekYogurtBowlCarbs;
        public const float MikeDay4BreakfastFat = RecipeMealConstants.MikeDay4Breakfast_GreekYogurtBowlFat;

        public const string MikeDay4LunchId = "33333333-3333-4333-8333-333333333342";
        public const MealType MikeDay4LunchType = MealType.Lunch;
        // Grilled Salmon Quinoa (no sides)
        public const float MikeDay4LunchCalories = RecipeMealConstants.MikeDay4Lunch_GrilledSalmonQuinoaCalories;
        public const float MikeDay4LunchProtein = RecipeMealConstants.MikeDay4Lunch_GrilledSalmonQuinoaProtein;
        public const float MikeDay4LunchCarbs = RecipeMealConstants.MikeDay4Lunch_GrilledSalmonQuinoaCarbs;
        public const float MikeDay4LunchFat = RecipeMealConstants.MikeDay4Lunch_GrilledSalmonQuinoaFat;

        public const string MikeDay4DinnerId = "33333333-3333-4333-8333-333333333343";
        public const MealType MikeDay4DinnerType = MealType.Dinner;
        // Chicken Rice Bowl (no sides)
        public const float MikeDay4DinnerCalories = RecipeMealConstants.MikeDay4Dinner_ChickenRiceBowlCalories;
        public const float MikeDay4DinnerProtein = RecipeMealConstants.MikeDay4Dinner_ChickenRiceBowlProtein;
        public const float MikeDay4DinnerCarbs = RecipeMealConstants.MikeDay4Dinner_ChickenRiceBowlCarbs;
        public const float MikeDay4DinnerFat = RecipeMealConstants.MikeDay4Dinner_ChickenRiceBowlFat;

        // ========== MIKE'S MEAL PLAN - Day 5 ==========
        public const string MikeDay5BreakfastId = "33333333-3333-4333-8333-333333333351";
        public const MealType MikeDay5BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float MikeDay5BreakfastCalories = RecipeMealConstants.MikeDay5Breakfast_OvernightOatsCalories;
        public const float MikeDay5BreakfastProtein = RecipeMealConstants.MikeDay5Breakfast_OvernightOatsProtein;
        public const float MikeDay5BreakfastCarbs = RecipeMealConstants.MikeDay5Breakfast_OvernightOatsCarbs;
        public const float MikeDay5BreakfastFat = RecipeMealConstants.MikeDay5Breakfast_OvernightOatsFat;

        public const string MikeDay5LunchId = "33333333-3333-4333-8333-333333333352";
        public const MealType MikeDay5LunchType = MealType.Lunch;
        // Chicken Stir Fry (no sides)
        public const float MikeDay5LunchCalories = RecipeMealConstants.MikeDay5Lunch_ChickenStirFryCalories;
        public const float MikeDay5LunchProtein = RecipeMealConstants.MikeDay5Lunch_ChickenStirFryProtein;
        public const float MikeDay5LunchCarbs = RecipeMealConstants.MikeDay5Lunch_ChickenStirFryCarbs;
        public const float MikeDay5LunchFat = RecipeMealConstants.MikeDay5Lunch_ChickenStirFryFat;

        public const string MikeDay5DinnerId = "33333333-3333-4333-8333-333333333353";
        public const MealType MikeDay5DinnerType = MealType.Dinner;
        // Chicken Rice Bowl (no sides)
        public const float MikeDay5DinnerCalories = RecipeMealConstants.MikeDay5Dinner_ChickenRiceBowlCalories;
        public const float MikeDay5DinnerProtein = RecipeMealConstants.MikeDay5Dinner_ChickenRiceBowlProtein;
        public const float MikeDay5DinnerCarbs = RecipeMealConstants.MikeDay5Dinner_ChickenRiceBowlCarbs;
        public const float MikeDay5DinnerFat = RecipeMealConstants.MikeDay5Dinner_ChickenRiceBowlFat;

        // ═══════════════════════════════════════════════════════════
        // EMMA'S MEAL PLAN (Balanced - Sustainable Wellness)
        // ═══════════════════════════════════════════════════════════

        // ========== EMMA'S MEAL PLAN - Day 1 ==========
        public const string EmmaDay1BreakfastId = "44444444-4444-4444-8444-444444444411";
        public const MealType EmmaDay1BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl + Banana (80g)
        public const float EmmaDay1BreakfastCalories = RecipeMealConstants.EmmaDay1Breakfast_GreekYogurtBowlCalories + IngredientMealConstants.EmmaDay1Breakfast_BananaCalories;
        public const float EmmaDay1BreakfastProtein = RecipeMealConstants.EmmaDay1Breakfast_GreekYogurtBowlProtein + IngredientMealConstants.EmmaDay1Breakfast_BananaProtein;
        public const float EmmaDay1BreakfastCarbs = RecipeMealConstants.EmmaDay1Breakfast_GreekYogurtBowlCarbs + IngredientMealConstants.EmmaDay1Breakfast_BananaCarbs;
        public const float EmmaDay1BreakfastFat = RecipeMealConstants.EmmaDay1Breakfast_GreekYogurtBowlFat + IngredientMealConstants.EmmaDay1Breakfast_BananaFat;

        public const string EmmaDay1LunchId = "44444444-4444-4444-8444-444444444412";
        public const MealType EmmaDay1LunchType = MealType.Lunch;
        // Grilled Salmon Quinoa (no sides)
        public const float EmmaDay1LunchCalories = RecipeMealConstants.EmmaDay1Lunch_GrilledSalmonQuinoaCalories;
        public const float EmmaDay1LunchProtein = RecipeMealConstants.EmmaDay1Lunch_GrilledSalmonQuinoaProtein;
        public const float EmmaDay1LunchCarbs = RecipeMealConstants.EmmaDay1Lunch_GrilledSalmonQuinoaCarbs;
        public const float EmmaDay1LunchFat = RecipeMealConstants.EmmaDay1Lunch_GrilledSalmonQuinoaFat;

        public const string EmmaDay1DinnerId = "44444444-4444-4444-8444-444444444413";
        public const MealType EmmaDay1DinnerType = MealType.Dinner;
        // Mediterranean Salad (no sides)
        public const float EmmaDay1DinnerCalories = RecipeMealConstants.EmmaDay1Dinner_MediterraneanSaladCalories;
        public const float EmmaDay1DinnerProtein = RecipeMealConstants.EmmaDay1Dinner_MediterraneanSaladProtein;
        public const float EmmaDay1DinnerCarbs = RecipeMealConstants.EmmaDay1Dinner_MediterraneanSaladCarbs;
        public const float EmmaDay1DinnerFat = RecipeMealConstants.EmmaDay1Dinner_MediterraneanSaladFat;

        // ========== EMMA'S MEAL PLAN - Day 2 ==========
        public const string EmmaDay2BreakfastId = "44444444-4444-4444-8444-444444444421";
        public const MealType EmmaDay2BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float EmmaDay2BreakfastCalories = RecipeMealConstants.EmmaDay2Breakfast_OvernightOatsCalories;
        public const float EmmaDay2BreakfastProtein = RecipeMealConstants.EmmaDay2Breakfast_OvernightOatsProtein;
        public const float EmmaDay2BreakfastCarbs = RecipeMealConstants.EmmaDay2Breakfast_OvernightOatsCarbs;
        public const float EmmaDay2BreakfastFat = RecipeMealConstants.EmmaDay2Breakfast_OvernightOatsFat;

        public const string EmmaDay2LunchId = "44444444-4444-4444-8444-444444444422";
        public const MealType EmmaDay2LunchType = MealType.Lunch;
        // Chicken Rice Bowl (no sides)
        public const float EmmaDay2LunchCalories = RecipeMealConstants.EmmaDay2Lunch_ChickenRiceBowlCalories;
        public const float EmmaDay2LunchProtein = RecipeMealConstants.EmmaDay2Lunch_ChickenRiceBowlProtein;
        public const float EmmaDay2LunchCarbs = RecipeMealConstants.EmmaDay2Lunch_ChickenRiceBowlCarbs;
        public const float EmmaDay2LunchFat = RecipeMealConstants.EmmaDay2Lunch_ChickenRiceBowlFat;

        public const string EmmaDay2DinnerId = "44444444-4444-4444-8444-444444444423";
        public const MealType EmmaDay2DinnerType = MealType.Dinner;
        // Buddha Bowl (no sides)
        public const float EmmaDay2DinnerCalories = RecipeMealConstants.EmmaDay2Dinner_BuddhaBowlCalories;
        public const float EmmaDay2DinnerProtein = RecipeMealConstants.EmmaDay2Dinner_BuddhaBowlProtein;
        public const float EmmaDay2DinnerCarbs = RecipeMealConstants.EmmaDay2Dinner_BuddhaBowlCarbs;
        public const float EmmaDay2DinnerFat = RecipeMealConstants.EmmaDay2Dinner_BuddhaBowlFat;

        // ========== EMMA'S MEAL PLAN - Day 3 ==========
        public const string EmmaDay3BreakfastId = "44444444-4444-4444-8444-444444444431";
        public const MealType EmmaDay3BreakfastType = MealType.Breakfast;
        // Veggie Omelette (no sides)
        public const float EmmaDay3BreakfastCalories = RecipeMealConstants.EmmaDay3Breakfast_VeggieOmeletteCalories;
        public const float EmmaDay3BreakfastProtein = RecipeMealConstants.EmmaDay3Breakfast_VeggieOmeletteProtein;
        public const float EmmaDay3BreakfastCarbs = RecipeMealConstants.EmmaDay3Breakfast_VeggieOmeletteCarbs;
        public const float EmmaDay3BreakfastFat = RecipeMealConstants.EmmaDay3Breakfast_VeggieOmeletteFat;

        public const string EmmaDay3LunchId = "44444444-4444-4444-8444-444444444432";
        public const MealType EmmaDay3LunchType = MealType.Lunch;
        // Mediterranean Salad (no sides)
        public const float EmmaDay3LunchCalories = RecipeMealConstants.EmmaDay3Lunch_MediterraneanSaladCalories;
        public const float EmmaDay3LunchProtein = RecipeMealConstants.EmmaDay3Lunch_MediterraneanSaladProtein;
        public const float EmmaDay3LunchCarbs = RecipeMealConstants.EmmaDay3Lunch_MediterraneanSaladCarbs;
        public const float EmmaDay3LunchFat = RecipeMealConstants.EmmaDay3Lunch_MediterraneanSaladFat;

        public const string EmmaDay3DinnerId = "44444444-4444-4444-8444-444444444433";
        public const MealType EmmaDay3DinnerType = MealType.Dinner;
        // Grilled Salmon Quinoa (no sides)
        public const float EmmaDay3DinnerCalories = RecipeMealConstants.EmmaDay3Dinner_GrilledSalmonQuinoaCalories;
        public const float EmmaDay3DinnerProtein = RecipeMealConstants.EmmaDay3Dinner_GrilledSalmonQuinoaProtein;
        public const float EmmaDay3DinnerCarbs = RecipeMealConstants.EmmaDay3Dinner_GrilledSalmonQuinoaCarbs;
        public const float EmmaDay3DinnerFat = RecipeMealConstants.EmmaDay3Dinner_GrilledSalmonQuinoaFat;

        // ========== EMMA'S MEAL PLAN - Day 4 ==========
        public const string EmmaDay4BreakfastId = "44444444-4444-4444-8444-444444444441";
        public const MealType EmmaDay4BreakfastType = MealType.Breakfast;
        // Greek Yogurt Bowl (no sides)
        public const float EmmaDay4BreakfastCalories = RecipeMealConstants.EmmaDay4Breakfast_GreekYogurtBowlCalories;
        public const float EmmaDay4BreakfastProtein = RecipeMealConstants.EmmaDay4Breakfast_GreekYogurtBowlProtein;
        public const float EmmaDay4BreakfastCarbs = RecipeMealConstants.EmmaDay4Breakfast_GreekYogurtBowlCarbs;
        public const float EmmaDay4BreakfastFat = RecipeMealConstants.EmmaDay4Breakfast_GreekYogurtBowlFat;

        public const string EmmaDay4LunchId = "44444444-4444-4444-8444-444444444442";
        public const MealType EmmaDay4LunchType = MealType.Lunch;
        // Chicken Stir Fry (no sides)
        public const float EmmaDay4LunchCalories = RecipeMealConstants.EmmaDay4Lunch_ChickenStirFryCalories;
        public const float EmmaDay4LunchProtein = RecipeMealConstants.EmmaDay4Lunch_ChickenStirFryProtein;
        public const float EmmaDay4LunchCarbs = RecipeMealConstants.EmmaDay4Lunch_ChickenStirFryCarbs;
        public const float EmmaDay4LunchFat = RecipeMealConstants.EmmaDay4Lunch_ChickenStirFryFat;

        public const string EmmaDay4DinnerId = "44444444-4444-4444-8444-444444444443";
        public const MealType EmmaDay4DinnerType = MealType.Dinner;
        // Buddha Bowl (no sides)
        public const float EmmaDay4DinnerCalories = RecipeMealConstants.EmmaDay4Dinner_BuddhaBowlCalories;
        public const float EmmaDay4DinnerProtein = RecipeMealConstants.EmmaDay4Dinner_BuddhaBowlProtein;
        public const float EmmaDay4DinnerCarbs = RecipeMealConstants.EmmaDay4Dinner_BuddhaBowlCarbs;
        public const float EmmaDay4DinnerFat = RecipeMealConstants.EmmaDay4Dinner_BuddhaBowlFat;

        // ========== EMMA'S MEAL PLAN - Day 5 ==========
        public const string EmmaDay5BreakfastId = "44444444-4444-4444-8444-444444444451";
        public const MealType EmmaDay5BreakfastType = MealType.Breakfast;
        // Overnight Oats (no sides)
        public const float EmmaDay5BreakfastCalories = RecipeMealConstants.EmmaDay5Breakfast_OvernightOatsCalories;
        public const float EmmaDay5BreakfastProtein = RecipeMealConstants.EmmaDay5Breakfast_OvernightOatsProtein;
        public const float EmmaDay5BreakfastCarbs = RecipeMealConstants.EmmaDay5Breakfast_OvernightOatsCarbs;
        public const float EmmaDay5BreakfastFat = RecipeMealConstants.EmmaDay5Breakfast_OvernightOatsFat;

        public const string EmmaDay5LunchId = "44444444-4444-4444-8444-444444444452";
        public const MealType EmmaDay5LunchType = MealType.Lunch;
        // Grilled Salmon Quinoa (no sides)
        public const float EmmaDay5LunchCalories = RecipeMealConstants.EmmaDay5Lunch_GrilledSalmonQuinoaCalories;
        public const float EmmaDay5LunchProtein = RecipeMealConstants.EmmaDay5Lunch_GrilledSalmonQuinoaProtein;
        public const float EmmaDay5LunchCarbs = RecipeMealConstants.EmmaDay5Lunch_GrilledSalmonQuinoaCarbs;
        public const float EmmaDay5LunchFat = RecipeMealConstants.EmmaDay5Lunch_GrilledSalmonQuinoaFat;

        public const string EmmaDay5DinnerId = "44444444-4444-4444-8444-444444444453";
        public const MealType EmmaDay5DinnerType = MealType.Dinner;
        // Mediterranean Salad (no sides)
        public const float EmmaDay5DinnerCalories = RecipeMealConstants.EmmaDay5Dinner_MediterraneanSaladCalories;
        public const float EmmaDay5DinnerProtein = RecipeMealConstants.EmmaDay5Dinner_MediterraneanSaladProtein;
        public const float EmmaDay5DinnerCarbs = RecipeMealConstants.EmmaDay5Dinner_MediterraneanSaladCarbs;
        public const float EmmaDay5DinnerFat = RecipeMealConstants.EmmaDay5Dinner_MediterraneanSaladFat;
    }
}