using HealthyRecipes.Data.Enums;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants
{
    public class RecipeConstants
    {
        // ---------- Recipe 1: Chicken & Rice Bowl ----------
        public const string ChickenRiceBowlId = "f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101";
        public const string ChickenRiceBowlTitle = "Healthy Chicken & Rice Bowl";
        public const string ChickenRiceBowlInfo =
            "A healthy and high-protein chicken and rice bowl with sautéed onion and garlic. " +
            "Perfect for meal prep and quick lunches.";
        public const int ChickenRiceBowlPrepTime = 30;
        public const int ChickenRiceBowlServings = 4;
        public const Difficulty ChickenRiceBowlDifficulty = Difficulty.Easy;
        // Nutritional values calculated from ingredients
        public const float ChickenRiceBowlCalories =
            (IngredientConstants.ChickenBreastCaloriesPer100g * RecipeIngredientConstants.ChickenRiceBowl_ChickenBreastQuantity / 100) +
            (IngredientConstants.WhiteRiceCaloriesPer100g * RecipeIngredientConstants.ChickenRiceBowl_RiceQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.ChickenRiceBowl_OliveOilQuantity / 100) +
            (IngredientConstants.GarlicCaloriesPer100g * RecipeIngredientConstants.ChickenRiceBowl_GarlicQuantity / 100);
        public const float ChickenRiceBowlProtein =
            (IngredientConstants.ChickenBreastProteinPer100g * RecipeIngredientConstants.ChickenRiceBowl_ChickenBreastQuantity / 100) +
            (IngredientConstants.WhiteRiceProteinPer100g * RecipeIngredientConstants.ChickenRiceBowl_RiceQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.ChickenRiceBowl_OliveOilQuantity / 100) +
            (IngredientConstants.GarlicProteinPer100g * RecipeIngredientConstants.ChickenRiceBowl_GarlicQuantity / 100);
        public const float ChickenRiceBowlCarbs =
            (IngredientConstants.ChickenBreastCarbsPer100g * RecipeIngredientConstants.ChickenRiceBowl_ChickenBreastQuantity / 100) +
            (IngredientConstants.WhiteRiceCarbsPer100g * RecipeIngredientConstants.ChickenRiceBowl_RiceQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.ChickenRiceBowl_OliveOilQuantity / 100) +
            (IngredientConstants.GarlicCarbsPer100g * RecipeIngredientConstants.ChickenRiceBowl_GarlicQuantity / 100);
        public const float ChickenRiceBowlFat =
            (IngredientConstants.ChickenBreastFatPer100g * RecipeIngredientConstants.ChickenRiceBowl_ChickenBreastQuantity / 100) +
            (IngredientConstants.WhiteRiceFatPer100g * RecipeIngredientConstants.ChickenRiceBowl_RiceQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.ChickenRiceBowl_OliveOilQuantity / 100) +
            (IngredientConstants.GarlicFatPer100g * RecipeIngredientConstants.ChickenRiceBowl_GarlicQuantity / 100);

        // ---------- Recipe 2: Grilled Salmon with Quinoa ----------
        public const string GrilledSalmonQuinoaId = "a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e";
        public const string GrilledSalmonQuinoaTitle = "Grilled Salmon with Lemon Quinoa";
        public const string GrilledSalmonQuinoaInfo =
            "Perfectly grilled salmon served over fluffy quinoa with a fresh lemon dressing. " +
            "Rich in omega-3 fatty acids and complete protein.";
        public const int GrilledSalmonQuinoaPrepTime = 25;
        public const int GrilledSalmonQuinoaServings = 2;
        public const Difficulty GrilledSalmonQuinoaDifficulty = Difficulty.Medium;
        // Nutritional values calculated from ingredients
        public const float GrilledSalmonQuinoaCalories =
            (IngredientConstants.SalmonCaloriesPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_SalmonQuantity / 100) +
            (IngredientConstants.QuinoaCaloriesPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_QuinoaQuantity / 100) +
            (IngredientConstants.BroccoliCaloriesPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_BroccoliQuantity / 100) +
            (IngredientConstants.LemonCaloriesPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_LemonQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_OliveOilQuantity / 100);
        public const float GrilledSalmonQuinoaProtein =
            (IngredientConstants.SalmonProteinPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_SalmonQuantity / 100) +
            (IngredientConstants.QuinoaProteinPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_QuinoaQuantity / 100) +
            (IngredientConstants.BroccoliProteinPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_BroccoliQuantity / 100) +
            (IngredientConstants.LemonProteinPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_LemonQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_OliveOilQuantity / 100);
        public const float GrilledSalmonQuinoaCarbs =
            (IngredientConstants.SalmonCarbsPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_SalmonQuantity / 100) +
            (IngredientConstants.QuinoaCarbsPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_QuinoaQuantity / 100) +
            (IngredientConstants.BroccoliCarbsPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_BroccoliQuantity / 100) +
            (IngredientConstants.LemonCarbsPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_LemonQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_OliveOilQuantity / 100);
        public const float GrilledSalmonQuinoaFat =
            (IngredientConstants.SalmonFatPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_SalmonQuantity / 100) +
            (IngredientConstants.QuinoaFatPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_QuinoaQuantity / 100) +
            (IngredientConstants.BroccoliFatPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_BroccoliQuantity / 100) +
            (IngredientConstants.LemonFatPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_LemonQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.GrilledSalmonQuinoa_OliveOilQuantity / 100);

        // ---------- Recipe 3: Greek Yogurt Breakfast Bowl ----------
        public const string GreekYogurtBowlId = "b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f";
        public const string GreekYogurtBowlTitle = "Greek Yogurt Breakfast Bowl";
        public const string GreekYogurtBowlInfo =
            "Creamy Greek yogurt topped with fresh blueberries, almonds, and a drizzle of honey. " +
            "A protein-packed breakfast that keeps you full all morning.";
        public const int GreekYogurtBowlPrepTime = 5;
        public const int GreekYogurtBowlServings = 1;
        public const Difficulty GreekYogurtBowlDifficulty = Difficulty.Easy;
        // Nutritional values calculated from ingredients
        public const float GreekYogurtBowlCalories =
            (IngredientConstants.GreekYogurtCaloriesPer100g * RecipeIngredientConstants.GreekYogurtBowl_GreekYogurtQuantity / 100) +
            (IngredientConstants.BerriesCaloriesPer100g * RecipeIngredientConstants.GreekYogurtBowl_BerriesQuantity / 100) +
            (IngredientConstants.HoneyCaloriesPer100g * RecipeIngredientConstants.GreekYogurtBowl_HoneyQuantity / 100) +
            (IngredientConstants.AlmondsCaloriesPer100g * RecipeIngredientConstants.GreekYogurtBowl_AlmondsQuantity / 100);
        public const float GreekYogurtBowlProtein =
            (IngredientConstants.GreekYogurtProteinPer100g * RecipeIngredientConstants.GreekYogurtBowl_GreekYogurtQuantity / 100) +
            (IngredientConstants.BerriesProteinPer100g * RecipeIngredientConstants.GreekYogurtBowl_BerriesQuantity / 100) +
            (IngredientConstants.HoneyProteinPer100g * RecipeIngredientConstants.GreekYogurtBowl_HoneyQuantity / 100) +
            (IngredientConstants.AlmondsProteinPer100g * RecipeIngredientConstants.GreekYogurtBowl_AlmondsQuantity / 100);
        public const float GreekYogurtBowlCarbs =
            (IngredientConstants.GreekYogurtCarbsPer100g * RecipeIngredientConstants.GreekYogurtBowl_GreekYogurtQuantity / 100) +
            (IngredientConstants.BerriesCarbsPer100g * RecipeIngredientConstants.GreekYogurtBowl_BerriesQuantity / 100) +
            (IngredientConstants.HoneyCarbsPer100g * RecipeIngredientConstants.GreekYogurtBowl_HoneyQuantity / 100) +
            (IngredientConstants.AlmondsCarbsPer100g * RecipeIngredientConstants.GreekYogurtBowl_AlmondsQuantity / 100);
        public const float GreekYogurtBowlFat =
            (IngredientConstants.GreekYogurtFatPer100g * RecipeIngredientConstants.GreekYogurtBowl_GreekYogurtQuantity / 100) +
            (IngredientConstants.BerriesFatPer100g * RecipeIngredientConstants.GreekYogurtBowl_BerriesQuantity / 100) +
            (IngredientConstants.HoneyFatPer100g * RecipeIngredientConstants.GreekYogurtBowl_HoneyQuantity / 100) +
            (IngredientConstants.AlmondsFatPer100g * RecipeIngredientConstants.GreekYogurtBowl_AlmondsQuantity / 100);

        // ---------- Recipe 4: Spinach & Sweet Potato Buddha Bowl ----------
        public const string BuddhaBowlId = "c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a";
        public const string BuddhaBowlTitle = "Spinach & Sweet Potato Buddha Bowl";
        public const string BuddhaBowlInfo =
            "A vibrant plant-based bowl loaded with roasted sweet potato, fresh spinach, " +
            "avocado, and a tahini dressing. Nutrient-dense and satisfying.";
        public const int BuddhaBowlPrepTime = 35;
        public const int BuddhaBowlServings = 2;
        public const Difficulty BuddhaBowlDifficulty = Difficulty.Medium;
        // Nutritional values calculated from ingredients
        public const float BuddhaBowlCalories =
            (IngredientConstants.QuinoaCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_QuinoaQuantity / 100) +
            (IngredientConstants.ChickpeasCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_ChickpeasQuantity / 100) +
            (IngredientConstants.AvocadoCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_AvocadoQuantity / 100) +
            (IngredientConstants.SpinachCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_SpinachQuantity / 100) +
            (IngredientConstants.TomatoCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_TomatoQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.BuddhaBowl_OliveOilQuantity / 100);
        public const float BuddhaBowlProtein =
            (IngredientConstants.QuinoaProteinPer100g * RecipeIngredientConstants.BuddhaBowl_QuinoaQuantity / 100) +
            (IngredientConstants.ChickpeasProteinPer100g * RecipeIngredientConstants.BuddhaBowl_ChickpeasQuantity / 100) +
            (IngredientConstants.AvocadoProteinPer100g * RecipeIngredientConstants.BuddhaBowl_AvocadoQuantity / 100) +
            (IngredientConstants.SpinachProteinPer100g * RecipeIngredientConstants.BuddhaBowl_SpinachQuantity / 100) +
            (IngredientConstants.TomatoProteinPer100g * RecipeIngredientConstants.BuddhaBowl_TomatoQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.BuddhaBowl_OliveOilQuantity / 100);
        public const float BuddhaBowlCarbs =
            (IngredientConstants.QuinoaCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_QuinoaQuantity / 100) +
            (IngredientConstants.ChickpeasCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_ChickpeasQuantity / 100) +
            (IngredientConstants.AvocadoCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_AvocadoQuantity / 100) +
            (IngredientConstants.SpinachCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_SpinachQuantity / 100) +
            (IngredientConstants.TomatoCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_TomatoQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.BuddhaBowl_OliveOilQuantity / 100);
        public const float BuddhaBowlFat =
            (IngredientConstants.QuinoaFatPer100g * RecipeIngredientConstants.BuddhaBowl_QuinoaQuantity / 100) +
            (IngredientConstants.ChickpeasFatPer100g * RecipeIngredientConstants.BuddhaBowl_ChickpeasQuantity / 100) +
            (IngredientConstants.AvocadoFatPer100g * RecipeIngredientConstants.BuddhaBowl_AvocadoQuantity / 100) +
            (IngredientConstants.SpinachFatPer100g * RecipeIngredientConstants.BuddhaBowl_SpinachQuantity / 100) +
            (IngredientConstants.TomatoFatPer100g * RecipeIngredientConstants.BuddhaBowl_TomatoQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.BuddhaBowl_OliveOilQuantity / 100);

        // ---------- Recipe 5: Veggie Omelette ----------
        public const string VeggieOmeletteId = "d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b";
        public const string VeggieOmeletteTitle = "Garden Veggie Omelette";
        public const string VeggieOmeletteInfo =
            "Fluffy eggs filled with bell peppers, tomatoes, spinach, and onions. " +
            "A classic breakfast packed with protein and vitamins.";
        public const int VeggieOmelettePrepTime = 15;
        public const int VeggieOmeletteServings = 1;
        public const Difficulty VeggieOmeletteDifficulty = Difficulty.Easy;
        // Nutritional values calculated from ingredients
        public const float VeggieOmeletteCalories =
            (IngredientConstants.EggsCaloriesPer100g * RecipeIngredientConstants.VeggieOmelette_EggsQuantity / 100) +
            (IngredientConstants.SpinachCaloriesPer100g * RecipeIngredientConstants.VeggieOmelette_SpinachQuantity / 100) +
            (IngredientConstants.TomatoCaloriesPer100g * RecipeIngredientConstants.VeggieOmelette_TomatoQuantity / 100) +
            (IngredientConstants.OnionCaloriesPer100g * RecipeIngredientConstants.VeggieOmelette_OnionQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.VeggieOmelette_OliveOilQuantity / 100);
        public const float VeggieOmeletteProtein =
            (IngredientConstants.EggsProteinPer100g * RecipeIngredientConstants.VeggieOmelette_EggsQuantity / 100) +
            (IngredientConstants.SpinachProteinPer100g * RecipeIngredientConstants.VeggieOmelette_SpinachQuantity / 100) +
            (IngredientConstants.TomatoProteinPer100g * RecipeIngredientConstants.VeggieOmelette_TomatoQuantity / 100) +
            (IngredientConstants.OnionProteinPer100g * RecipeIngredientConstants.VeggieOmelette_OnionQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.VeggieOmelette_OliveOilQuantity / 100);
        public const float VeggieOmeletteCarbs =
            (IngredientConstants.EggsCarbsPer100g * RecipeIngredientConstants.VeggieOmelette_EggsQuantity / 100) +
            (IngredientConstants.SpinachCarbsPer100g * RecipeIngredientConstants.VeggieOmelette_SpinachQuantity / 100) +
            (IngredientConstants.TomatoCarbsPer100g * RecipeIngredientConstants.VeggieOmelette_TomatoQuantity / 100) +
            (IngredientConstants.OnionCarbsPer100g * RecipeIngredientConstants.VeggieOmelette_OnionQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.VeggieOmelette_OliveOilQuantity / 100);
        public const float VeggieOmeletteFat =
            (IngredientConstants.EggsFatPer100g * RecipeIngredientConstants.VeggieOmelette_EggsQuantity / 100) +
            (IngredientConstants.SpinachFatPer100g * RecipeIngredientConstants.VeggieOmelette_SpinachQuantity / 100) +
            (IngredientConstants.TomatoFatPer100g * RecipeIngredientConstants.VeggieOmelette_TomatoQuantity / 100) +
            (IngredientConstants.OnionFatPer100g * RecipeIngredientConstants.VeggieOmelette_OnionQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.VeggieOmelette_OliveOilQuantity / 100);

        // ---------- Recipe 6: Overnight Oats ----------
        public const string OvernightOatsId = "e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c";
        public const string OvernightOatsTitle = "Banana Peanut Butter Overnight Oats";
        public const string OvernightOatsInfo =
            "Creamy oats soaked overnight with banana, peanut butter, and a touch of honey. " +
            "Prep the night before for an effortless healthy breakfast.";
        public const int OvernightOatsPrepTime = 5;
        public const int OvernightOatsServings = 1;
        public const Difficulty OvernightOatsDifficulty = Difficulty.Easy;
        // Nutritional values calculated from ingredients
        public const float OvernightOatsCalories =
            (IngredientConstants.OatsCaloriesPer100g * RecipeIngredientConstants.OvernightOats_OatsQuantity / 100) +
            (IngredientConstants.AlmondMilkCaloriesPer100g * RecipeIngredientConstants.OvernightOats_AlmondMilkQuantity / 100) +
            (IngredientConstants.ChiaSeedsCaloriesPer100g * RecipeIngredientConstants.OvernightOats_ChiaSeedsQuantity / 100) +
            (IngredientConstants.BananaCaloriesPer100g * RecipeIngredientConstants.OvernightOats_BananaQuantity / 100) +
            (IngredientConstants.HoneyCaloriesPer100g * RecipeIngredientConstants.OvernightOats_HoneyQuantity / 100);
        public const float OvernightOatsProtein =
            (IngredientConstants.OatsProteinPer100g * RecipeIngredientConstants.OvernightOats_OatsQuantity / 100) +
            (IngredientConstants.AlmondMilkProteinPer100g * RecipeIngredientConstants.OvernightOats_AlmondMilkQuantity / 100) +
            (IngredientConstants.ChiaSeedsProteinPer100g * RecipeIngredientConstants.OvernightOats_ChiaSeedsQuantity / 100) +
            (IngredientConstants.BananaProteinPer100g * RecipeIngredientConstants.OvernightOats_BananaQuantity / 100) +
            (IngredientConstants.HoneyProteinPer100g * RecipeIngredientConstants.OvernightOats_HoneyQuantity / 100);
        public const float OvernightOatsCarbs =
            (IngredientConstants.OatsCarbsPer100g * RecipeIngredientConstants.OvernightOats_OatsQuantity / 100) +
            (IngredientConstants.AlmondMilkCarbsPer100g * RecipeIngredientConstants.OvernightOats_AlmondMilkQuantity / 100) +
            (IngredientConstants.ChiaSeedsCarbsPer100g * RecipeIngredientConstants.OvernightOats_ChiaSeedsQuantity / 100) +
            (IngredientConstants.BananaCarbsPer100g * RecipeIngredientConstants.OvernightOats_BananaQuantity / 100) +
            (IngredientConstants.HoneyCarbsPer100g * RecipeIngredientConstants.OvernightOats_HoneyQuantity / 100);
        public const float OvernightOatsFat =
            (IngredientConstants.OatsFatPer100g * RecipeIngredientConstants.OvernightOats_OatsQuantity / 100) +
            (IngredientConstants.AlmondMilkFatPer100g * RecipeIngredientConstants.OvernightOats_AlmondMilkQuantity / 100) +
            (IngredientConstants.ChiaSeedsFatPer100g * RecipeIngredientConstants.OvernightOats_ChiaSeedsQuantity / 100) +
            (IngredientConstants.BananaFatPer100g * RecipeIngredientConstants.OvernightOats_BananaQuantity / 100) +
            (IngredientConstants.HoneyFatPer100g * RecipeIngredientConstants.OvernightOats_HoneyQuantity / 100);

        // ---------- Recipe 7: Chicken Broccoli Stir-Fry ----------
        public const string ChickenStirFryId = "f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d";
        public const string ChickenStirFryTitle = "Garlic Chicken & Broccoli Stir-Fry";
        public const string ChickenStirFryInfo =
            "Quick and delicious chicken stir-fry with broccoli, garlic, and ginger in a light sauce. " +
            "Serve over brown rice for a complete meal.";
        public const int ChickenStirFryPrepTime = 20;
        public const int ChickenStirFryServings = 3;
        public const Difficulty ChickenStirFryDifficulty = Difficulty.Medium;
        // Nutritional values calculated from ingredients
        public const float ChickenStirFryCalories =
            (IngredientConstants.ChickenBreastCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_ChickenBreastQuantity / 100) +
            (IngredientConstants.BroccoliCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_BroccoliQuantity / 100) +
            (IngredientConstants.BellPepperCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_BellPepperQuantity / 100) +
            (IngredientConstants.SoySauceCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_SoySauceQuantity / 100) +
            (IngredientConstants.GarlicCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_GarlicQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.ChickenStirFry_OliveOilQuantity / 100);
        public const float ChickenStirFryProtein =
            (IngredientConstants.ChickenBreastProteinPer100g * RecipeIngredientConstants.ChickenStirFry_ChickenBreastQuantity / 100) +
            (IngredientConstants.BroccoliProteinPer100g * RecipeIngredientConstants.ChickenStirFry_BroccoliQuantity / 100) +
            (IngredientConstants.BellPepperProteinPer100g * RecipeIngredientConstants.ChickenStirFry_BellPepperQuantity / 100) +
            (IngredientConstants.SoySauceProteinPer100g * RecipeIngredientConstants.ChickenStirFry_SoySauceQuantity / 100) +
            (IngredientConstants.GarlicProteinPer100g * RecipeIngredientConstants.ChickenStirFry_GarlicQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.ChickenStirFry_OliveOilQuantity / 100);
        public const float ChickenStirFryCarbs =
            (IngredientConstants.ChickenBreastCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_ChickenBreastQuantity / 100) +
            (IngredientConstants.BroccoliCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_BroccoliQuantity / 100) +
            (IngredientConstants.BellPepperCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_BellPepperQuantity / 100) +
            (IngredientConstants.SoySauceCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_SoySauceQuantity / 100) +
            (IngredientConstants.GarlicCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_GarlicQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.ChickenStirFry_OliveOilQuantity / 100);
        public const float ChickenStirFryFat =
            (IngredientConstants.ChickenBreastFatPer100g * RecipeIngredientConstants.ChickenStirFry_ChickenBreastQuantity / 100) +
            (IngredientConstants.BroccoliFatPer100g * RecipeIngredientConstants.ChickenStirFry_BroccoliQuantity / 100) +
            (IngredientConstants.BellPepperFatPer100g * RecipeIngredientConstants.ChickenStirFry_BellPepperQuantity / 100) +
            (IngredientConstants.SoySauceFatPer100g * RecipeIngredientConstants.ChickenStirFry_SoySauceQuantity / 100) +
            (IngredientConstants.GarlicFatPer100g * RecipeIngredientConstants.ChickenStirFry_GarlicQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.ChickenStirFry_OliveOilQuantity / 100);

        // ---------- Recipe 8: Mediterranean Cucumber Salad ----------
        public const string MediterraneanSaladId = "a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e";
        public const string MediterraneanSaladTitle = "Mediterranean Cucumber Salad";
        public const string MediterraneanSaladInfo =
            "Refreshing salad with cucumbers, tomatoes, bell peppers, parsley, and olive oil. " +
            "Light, crisp, and full of Mediterranean flavors.";
        public const int MediterraneanSaladPrepTime = 10;
        public const int MediterraneanSaladServings = 4;
        public const Difficulty MediterraneanSaladDifficulty = Difficulty.Easy;
        // Nutritional values calculated from ingredients
        public const float MediterraneanSaladCalories =
            (IngredientConstants.CucumberCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_CucumberQuantity / 100) +
            (IngredientConstants.TomatoCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_TomatoQuantity / 100) +
            (IngredientConstants.FetaCheeseCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_FetaCheeseQuantity / 100) +
            (IngredientConstants.OnionCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_OnionQuantity / 100) +
            (IngredientConstants.OliveOilCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_OliveOilQuantity / 100) +
            (IngredientConstants.LemonCaloriesPer100g * RecipeIngredientConstants.MediterraneanSalad_LemonQuantity / 100);
        public const float MediterraneanSaladProtein =
            (IngredientConstants.CucumberProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_CucumberQuantity / 100) +
            (IngredientConstants.TomatoProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_TomatoQuantity / 100) +
            (IngredientConstants.FetaCheeseProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_FetaCheeseQuantity / 100) +
            (IngredientConstants.OnionProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_OnionQuantity / 100) +
            (IngredientConstants.OliveOilProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_OliveOilQuantity / 100) +
            (IngredientConstants.LemonProteinPer100g * RecipeIngredientConstants.MediterraneanSalad_LemonQuantity / 100);
        public const float MediterraneanSaladCarbs =
            (IngredientConstants.CucumberCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_CucumberQuantity / 100) +
            (IngredientConstants.TomatoCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_TomatoQuantity / 100) +
            (IngredientConstants.FetaCheeseCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_FetaCheeseQuantity / 100) +
            (IngredientConstants.OnionCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_OnionQuantity / 100) +
            (IngredientConstants.OliveOilCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_OliveOilQuantity / 100) +
            (IngredientConstants.LemonCarbsPer100g * RecipeIngredientConstants.MediterraneanSalad_LemonQuantity / 100);
        public const float MediterraneanSaladFat =
            (IngredientConstants.CucumberFatPer100g * RecipeIngredientConstants.MediterraneanSalad_CucumberQuantity / 100) +
            (IngredientConstants.TomatoFatPer100g * RecipeIngredientConstants.MediterraneanSalad_TomatoQuantity / 100) +
            (IngredientConstants.FetaCheeseFatPer100g * RecipeIngredientConstants.MediterraneanSalad_FetaCheeseQuantity / 100) +
            (IngredientConstants.OnionFatPer100g * RecipeIngredientConstants.MediterraneanSalad_OnionQuantity / 100) +
            (IngredientConstants.OliveOilFatPer100g * RecipeIngredientConstants.MediterraneanSalad_OliveOilQuantity / 100) +
            (IngredientConstants.LemonFatPer100g * RecipeIngredientConstants.MediterraneanSalad_LemonQuantity / 100);

    }
}