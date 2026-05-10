using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public class RecipeSeeder
    {
        public static IEnumerable<Recipe> GenerateRecipes()
        {
            DateTime seedingDate = new DateTime(2025, 4, 20);

            IEnumerable<Recipe> recipes = new HashSet<Recipe>()
            {

                // Recipe 1: Chicken & Rice Bowl - by John Doe (Regular User)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.ChickenRiceBowlId))
                {
                    Title = RecipeConstants.ChickenRiceBowlTitle,
                    Info = RecipeConstants.ChickenRiceBowlInfo,
                    PrepTime = RecipeConstants.ChickenRiceBowlPrepTime,
                    Servings = RecipeConstants.ChickenRiceBowlServings,
                    Difficulty = RecipeConstants.ChickenRiceBowlDifficulty,
                    Calories = RecipeConstants.ChickenRiceBowlCalories,
                    Protein = RecipeConstants.ChickenRiceBowlProtein,
                    Carbs = RecipeConstants.ChickenRiceBowlCarbs,
                    Fat = RecipeConstants.ChickenRiceBowlFat,
                    UserId = Guid.Parse(UserConstants.UserId)
                },
                // Recipe 5: Veggie Omelette - by John Doe (Regular User)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.VeggieOmeletteId))
                {
                    Title = RecipeConstants.VeggieOmeletteTitle,
                    Info = RecipeConstants.VeggieOmeletteInfo,
                    PrepTime = RecipeConstants.VeggieOmelettePrepTime,
                    Servings = RecipeConstants.VeggieOmeletteServings,
                    Difficulty = RecipeConstants.VeggieOmeletteDifficulty,
                    Calories = RecipeConstants.VeggieOmeletteCalories,
                    Protein = RecipeConstants.VeggieOmeletteProtein,
                    Carbs = RecipeConstants.VeggieOmeletteCarbs,
                    Fat = RecipeConstants.VeggieOmeletteFat,
                    UserId = Guid.Parse(UserConstants.UserId)
                },
                // Recipe 2: Grilled Salmon with Quinoa - by Emma Davis (Nutritionist)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.GrilledSalmonQuinoaId))
                {
                    Title = RecipeConstants.GrilledSalmonQuinoaTitle,
                    Info = RecipeConstants.GrilledSalmonQuinoaInfo,
                    PrepTime = RecipeConstants.GrilledSalmonQuinoaPrepTime,
                    Servings = RecipeConstants.GrilledSalmonQuinoaServings,
                    Difficulty = RecipeConstants.GrilledSalmonQuinoaDifficulty,
                    Calories = RecipeConstants.GrilledSalmonQuinoaCalories,
                    Protein = RecipeConstants.GrilledSalmonQuinoaProtein,
                    Carbs = RecipeConstants.GrilledSalmonQuinoaCarbs,
                    Fat = RecipeConstants.GrilledSalmonQuinoaFat,
                    UserId = Guid.Parse(UserConstants.User4Id)
                },
                // Recipe 8: Mediterranean Salad - by Emma Davis (Nutritionist)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.MediterraneanSaladId))
                {
                    Title = RecipeConstants.MediterraneanSaladTitle,
                    Info = RecipeConstants.MediterraneanSaladInfo,
                    PrepTime = RecipeConstants.MediterraneanSaladPrepTime,
                    Servings = RecipeConstants.MediterraneanSaladServings,
                    Difficulty = RecipeConstants.MediterraneanSaladDifficulty,
                    Calories = RecipeConstants.MediterraneanSaladCalories,
                    Protein = RecipeConstants.MediterraneanSaladProtein,
                    Carbs = RecipeConstants.MediterraneanSaladCarbs,
                    Fat = RecipeConstants.MediterraneanSaladFat,
                    UserId = Guid.Parse(UserConstants.User4Id)
                },
                // Recipe 3: Greek Yogurt Breakfast Bowl - by Sarah Johnson (Yoga instructor)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.GreekYogurtBowlId))
                {
                    Title = RecipeConstants.GreekYogurtBowlTitle,
                    Info = RecipeConstants.GreekYogurtBowlInfo,
                    PrepTime = RecipeConstants.GreekYogurtBowlPrepTime,
                    Servings = RecipeConstants.GreekYogurtBowlServings,
                    Difficulty = RecipeConstants.GreekYogurtBowlDifficulty,
                    Calories = RecipeConstants.GreekYogurtBowlCalories,
                    Protein = RecipeConstants.GreekYogurtBowlProtein,
                    Carbs = RecipeConstants.GreekYogurtBowlCarbs,
                    Fat = RecipeConstants.GreekYogurtBowlFat,
                    UserId = Guid.Parse(UserConstants.User2Id)
                },

                // Recipe 4: Buddha Bowl - by Sarah Johnson (Yoga instructor, plant-based)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.BuddhaBowlId))
                {
                    Title = RecipeConstants.BuddhaBowlTitle,
                    Info = RecipeConstants.BuddhaBowlInfo,
                    PrepTime = RecipeConstants.BuddhaBowlPrepTime,
                    Servings = RecipeConstants.BuddhaBowlServings,
                    Difficulty = RecipeConstants.BuddhaBowlDifficulty,
                    Calories = RecipeConstants.BuddhaBowlCalories,
                    Protein = RecipeConstants.BuddhaBowlProtein,
                    Carbs = RecipeConstants.BuddhaBowlCarbs,
                    Fat = RecipeConstants.BuddhaBowlFat,
                    UserId = Guid.Parse(UserConstants.User2Id)
                },

                // Recipe 6: Overnight Oats - by Mike Williams (Marathon runner)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.OvernightOatsId))
                {
                    Title = RecipeConstants.OvernightOatsTitle,
                    Info = RecipeConstants.OvernightOatsInfo,
                    PrepTime = RecipeConstants.OvernightOatsPrepTime,
                    Servings = RecipeConstants.OvernightOatsServings,
                    Difficulty = RecipeConstants.OvernightOatsDifficulty,
                    Calories = RecipeConstants.OvernightOatsCalories,
                    Protein = RecipeConstants.OvernightOatsProtein,
                    Carbs = RecipeConstants.OvernightOatsCarbs,
                    Fat = RecipeConstants.OvernightOatsFat,
                    UserId = Guid.Parse(UserConstants.User3Id)
                },

                // Recipe 7: Chicken Stir-Fry - by Mike Williams (Marathon runner, high protein)
                new Recipe(seedingDate, Guid.Parse(RecipeConstants.ChickenStirFryId))
                {
                    Title = RecipeConstants.ChickenStirFryTitle,
                    Info = RecipeConstants.ChickenStirFryInfo,
                    PrepTime = RecipeConstants.ChickenStirFryPrepTime,
                    Servings = RecipeConstants.ChickenStirFryServings,
                    Difficulty = RecipeConstants.ChickenStirFryDifficulty,
                    Calories = RecipeConstants.ChickenStirFryCalories,
                    Protein = RecipeConstants.ChickenStirFryProtein,
                    Carbs = RecipeConstants.ChickenStirFryCarbs,
                    Fat = RecipeConstants.ChickenStirFryFat,
                    UserId = Guid.Parse(UserConstants.User3Id)
                },
            };

            return recipes;
        }
    }
}