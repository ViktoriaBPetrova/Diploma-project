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
             // ========== JOHN'S LEAN BULK PLAN - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay1DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay2DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay3DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay4DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay5DayOfWeek
                },

                // ========== SARAH'S PLANT-BASED WEEK - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay1DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay2DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay3DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay4DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay5DayOfWeek
                },

                // ========== MIKE'S MARATHON TRAINING - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay1DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay2DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay3DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay4DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay5DayOfWeek
                },

                // ========== EMMA'S BALANCED NUTRITION - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay1DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay2DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay3DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay4DayOfWeek
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay5DayOfWeek
                },

            };

            return mealPlanDays;
        }
    }
}
