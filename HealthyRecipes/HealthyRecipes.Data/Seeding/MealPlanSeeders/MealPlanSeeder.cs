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
            // Meal Plan 1: John's Lean Bulk Plan
                new MealPlan(seedingDate, Guid.Parse(MealPlanConstants.UserMealPlanId))
                {
                    Name = MealPlanConstants.UserMealPlanName,
                    Description = MealPlanConstants.UserMealPlanDescription,
                    UserId = Guid.Parse(MealPlanConstants.UserId),
                    Calories = MealPlanConstants.UserMealPlanCalories,
                    Protein = MealPlanConstants.UserMealPlanProtein,
                    Carbs = MealPlanConstants.UserMealPlanCarbs,
                    Fat = MealPlanConstants.UserMealPlanFat
                },

                // Meal Plan 2: Sarah's Plant-Based Week
                new MealPlan(seedingDate, Guid.Parse(MealPlanConstants.SarahMealPlanId))
                {
                    Name = MealPlanConstants.SarahMealPlanName,
                    Description = MealPlanConstants.SarahMealPlanDescription,
                    UserId = Guid.Parse(MealPlanConstants.SarahUserId),
                    Calories = MealPlanConstants.SarahMealPlanCalories,
                    Protein = MealPlanConstants.SarahMealPlanProtein,
                    Carbs = MealPlanConstants.SarahMealPlanCarbs,
                    Fat = MealPlanConstants.SarahMealPlanFat
                },

                // Meal Plan 3: Mike's Marathon Training Plan
                new MealPlan(seedingDate, Guid.Parse(MealPlanConstants.MikeMealPlanId))
                {
                    Name = MealPlanConstants.MikeMealPlanName,
                    Description = MealPlanConstants.MikeMealPlanDescription,
                    UserId = Guid.Parse(MealPlanConstants.MikeUserId),
                    Calories = MealPlanConstants.MikeMealPlanCalories,
                    Protein = MealPlanConstants.MikeMealPlanProtein,
                    Carbs = MealPlanConstants.MikeMealPlanCarbs,
                    Fat = MealPlanConstants.MikeMealPlanFat
                },

                // Meal Plan 4: Emma's Balanced Nutrition Guide
                new MealPlan(seedingDate, Guid.Parse(MealPlanConstants.EmmaMealPlanId))
                {
                    Name = MealPlanConstants.EmmaMealPlanName,
                    Description = MealPlanConstants.EmmaMealPlanDescription,
                    UserId = Guid.Parse(MealPlanConstants.EmmaUserId),
                    Calories = MealPlanConstants.EmmaMealPlanCalories,
                    Protein = MealPlanConstants.EmmaMealPlanProtein,
                    Carbs = MealPlanConstants.EmmaMealPlanCarbs,
                    Fat = MealPlanConstants.EmmaMealPlanFat
                }
            };

            return mealPlans;
        }
    }
}