using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MealPlanSeeders
{
    public class MealPlanSeeder
    {
        public static IEnumerable<MealPlan> GenerateMealPlans()
        {
            
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<MealPlan> mealPlans = new List<MealPlan>()
        {
            new MealPlan(
                seedingDate,
                Guid.Parse(MealPlanConstants.UserMealPlanId)
                /*MealPlanConstants.UserMealPlanCalories,
                MealPlanConstants.UserMealPlanFat,
                MealPlanConstants.UserMealPlanCarbs,
                MealPlanConstants.UserMealPlanProtein*/
            )
            {
                Name = MealPlanConstants.UserMealPlanName,
                Description = MealPlanConstants.UserMealPlanDescription,
                UserId = Guid.Parse(MealPlanConstants.UserId)
            }
            };

            return mealPlans;
        }
    }
}
