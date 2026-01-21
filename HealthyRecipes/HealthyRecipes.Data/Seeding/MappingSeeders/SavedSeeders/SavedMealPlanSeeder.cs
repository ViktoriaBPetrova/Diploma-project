using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.SavedSeeders
{
    public class SavedMealPlanSeeder
    {
        public static IEnumerable<SavedMealPlan> GenerateSavedRecipe()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            IEnumerable<SavedMealPlan> savedMealPlans = new List<SavedMealPlan>()
            {

                new SavedMealPlan(UserConstants.UserId, MealPlanConstants.UserMealPlanId, seedingDate),

            };

            return savedMealPlans;
        }
    }
}
