using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.RecipeMappingSeeders
{
    public class RecipeMealSeeder
    {
        public static IEnumerable<RecipeMeal> GenerateRecipeMeals()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<RecipeMeal> recipeMeals = new List<RecipeMeal>()
            {
                // ========== JOHN'S MEAL PLAN (High Protein Focus) ==========
                // Day 1
                new RecipeMeal(RecipeConstants.VeggieOmeletteId, MealConstants.JohnDay1BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.JohnDay1LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.JohnDay1DinnerId, seedingDate),
                // Day 2
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.JohnDay2BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.JohnDay2LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.JohnDay2DinnerId, seedingDate),
                // Day 3
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.JohnDay3BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.JohnDay3LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.VeggieOmeletteId, MealConstants.JohnDay3DinnerId, seedingDate),
                // Day 4
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.JohnDay4BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.JohnDay4LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.JohnDay4DinnerId, seedingDate),
                // Day 5
                new RecipeMeal(RecipeConstants.VeggieOmeletteId, MealConstants.JohnDay5BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.JohnDay5LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.JohnDay5DinnerId, seedingDate),

                // ========== SARAH'S MEAL PLAN (Plant-Based Focus) ==========
                // Day 1
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.SarahDay1BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.SarahDay1LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.SarahDay1DinnerId, seedingDate),
                // Day 2
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.SarahDay2BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.SarahDay2LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.SarahDay2DinnerId, seedingDate),
                // Day 3
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.SarahDay3BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.SarahDay3LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.SarahDay3DinnerId, seedingDate),
                // Day 4
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.SarahDay4BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.SarahDay4LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.SarahDay4DinnerId, seedingDate),
                // Day 5
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.SarahDay5BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.SarahDay5LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.SarahDay5DinnerId, seedingDate),

                // ========== MIKE'S MEAL PLAN (High Carb/Protein for Marathon Training) ==========
                // Day 1
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.MikeDay1BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.MikeDay1LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.MikeDay1DinnerId, seedingDate),
                // Day 2
                new RecipeMeal(RecipeConstants.VeggieOmeletteId, MealConstants.MikeDay2BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.MikeDay2LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.MikeDay2DinnerId, seedingDate),
                // Day 3
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.MikeDay3BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.MikeDay3LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.MikeDay3DinnerId, seedingDate),
                // Day 4
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.MikeDay4BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.MikeDay4LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.MikeDay4DinnerId, seedingDate),
                // Day 5
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.MikeDay5BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.MikeDay5LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.MikeDay5DinnerId, seedingDate),

                // ========== EMMA'S MEAL PLAN (Balanced Nutrition) ==========
                // Day 1
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.EmmaDay1BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.EmmaDay1LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.EmmaDay1DinnerId, seedingDate),
                // Day 2
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.EmmaDay2BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.EmmaDay2LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.EmmaDay2DinnerId, seedingDate),
                // Day 3
                new RecipeMeal(RecipeConstants.VeggieOmeletteId, MealConstants.EmmaDay3BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.EmmaDay3LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.EmmaDay3DinnerId, seedingDate),
                // Day 4
                new RecipeMeal(RecipeConstants.GreekYogurtBowlId, MealConstants.EmmaDay4BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.ChickenStirFryId, MealConstants.EmmaDay4LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.BuddhaBowlId, MealConstants.EmmaDay4DinnerId, seedingDate),
                // Day 5
                new RecipeMeal(RecipeConstants.OvernightOatsId, MealConstants.EmmaDay5BreakfastId, seedingDate),
                new RecipeMeal(RecipeConstants.GrilledSalmonQuinoaId, MealConstants.EmmaDay5LunchId, seedingDate),
                new RecipeMeal(RecipeConstants.MediterraneanSaladId, MealConstants.EmmaDay5DinnerId, seedingDate),
            };

            return recipeMeals;
        }
    }
}
