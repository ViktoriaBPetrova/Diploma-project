using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MealPlanSeeders
{
    public class MealSeeder
    {
        
        public static IEnumerable<Meal> GenerateMeals()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<Meal> meals = new List<Meal>()
            {
            new Meal(seedingDate, Guid.Parse(MealConstants.BreakfastId)
                     /*MealConstants.BreakfastCalories, MealConstants.BreakfastFat,
                     MealConstants.BreakfastCarbs, MealConstants.BreakfastProtein*/)
            {
                Type = MealConstants.BreakfastType,
                MealPlanDayId = Guid.Parse(MealPlanDayConstants.MondayMealPlanDayId),
            },

            new Meal(seedingDate, Guid.Parse(MealConstants.LunchId)
                     /*MealConstants.LunchCalories, MealConstants.LunchFat,
                     MealConstants.LunchCarbs, MealConstants.LunchProtein*/)
            {
                Type = MealConstants.LunchType,
                MealPlanDayId = Guid.Parse(MealPlanDayConstants.MondayMealPlanDayId),
            }
            };

            return meals;
        }
    }
}
