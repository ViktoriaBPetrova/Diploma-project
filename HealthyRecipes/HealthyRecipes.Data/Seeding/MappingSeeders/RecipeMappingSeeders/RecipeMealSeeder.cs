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
            new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.BreakfastId, seedingDate),
            new RecipeMeal(RecipeConstants.ChickenRiceBowlId, MealConstants.LunchId, seedingDate),

            
        };

            return recipeMeals;
        }
    }
}
