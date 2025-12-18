using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MealPlanSeeders
{
    public class MealPlanDaySeeder
    {
        public static IEnumerable<MealPlanDay> GenerateMealPlanDays()
        {
            // Single seeding date reused for all meal plan days
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<MealPlanDay> mealPlanDays = new List<MealPlanDay>()
            {
            new MealPlanDay(
                seedingDate,
                Guid.Parse(MealPlanDayConstants.MondayMealPlanDayId)
                /*MealPlanDayConstants.MondayCalories,
                MealPlanDayConstants.MondayFat,
                MealPlanDayConstants.MondayCarbs,
                MealPlanDayConstants.MondayProtein*/
            )
            {
                MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                DayNumber = MealPlanDayConstants.MondayDayNumber,
                DayOfWeek = MealPlanDayConstants.MondayDayOfWeek
            }
            };

            return mealPlanDays;
        }
    }
}
