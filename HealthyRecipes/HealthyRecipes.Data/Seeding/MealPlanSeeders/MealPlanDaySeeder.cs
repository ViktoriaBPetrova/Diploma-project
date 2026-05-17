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
                    DayOfWeek = MealPlanDayConstants.JohnDay1DayOfWeek,
                    Calories = MealPlanDayConstants.JohnDay1Calories,
                    Protein = MealPlanDayConstants.JohnDay1Protein,
                    Carbs = MealPlanDayConstants.JohnDay1Carbs,
                    Fat = MealPlanDayConstants.JohnDay1Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay2DayOfWeek,
                    Calories = MealPlanDayConstants.JohnDay2Calories,
                    Protein = MealPlanDayConstants.JohnDay2Protein,
                    Carbs = MealPlanDayConstants.JohnDay2Carbs,
                    Fat = MealPlanDayConstants.JohnDay2Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay3DayOfWeek,
                    Calories = MealPlanDayConstants.JohnDay3Calories,
                    Protein = MealPlanDayConstants.JohnDay3Protein,
                    Carbs = MealPlanDayConstants.JohnDay3Carbs,
                    Fat = MealPlanDayConstants.JohnDay3Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay4DayOfWeek,
                    Calories = MealPlanDayConstants.JohnDay4Calories,
                    Protein = MealPlanDayConstants.JohnDay4Protein,
                    Carbs = MealPlanDayConstants.JohnDay4Carbs,
                    Fat = MealPlanDayConstants.JohnDay4Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.JohnDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.UserMealPlanId),
                    DayNumber = MealPlanDayConstants.JohnDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.JohnDay5DayOfWeek,
                    Calories = MealPlanDayConstants.JohnDay5Calories,
                    Protein = MealPlanDayConstants.JohnDay5Protein,
                    Carbs = MealPlanDayConstants.JohnDay5Carbs,
                    Fat = MealPlanDayConstants.JohnDay5Fat
                },

                // ========== SARAH'S PLANT-BASED WEEK - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay1DayOfWeek,
                    Calories = MealPlanDayConstants.SarahDay1Calories,
                    Protein = MealPlanDayConstants.SarahDay1Protein,
                    Carbs = MealPlanDayConstants.SarahDay1Carbs,
                    Fat = MealPlanDayConstants.SarahDay1Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay2DayOfWeek,
                    Calories = MealPlanDayConstants.SarahDay2Calories,
                    Protein = MealPlanDayConstants.SarahDay2Protein,
                    Carbs = MealPlanDayConstants.SarahDay2Carbs,
                    Fat = MealPlanDayConstants.SarahDay2Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay3DayOfWeek,
                    Calories = MealPlanDayConstants.SarahDay3Calories,
                    Protein = MealPlanDayConstants.SarahDay3Protein,
                    Carbs = MealPlanDayConstants.SarahDay3Carbs,
                    Fat = MealPlanDayConstants.SarahDay3Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay4DayOfWeek,
                    Calories = MealPlanDayConstants.SarahDay4Calories,
                    Protein = MealPlanDayConstants.SarahDay4Protein,
                    Carbs = MealPlanDayConstants.SarahDay4Carbs,
                    Fat = MealPlanDayConstants.SarahDay4Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.SarahDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.SarahMealPlanId),
                    DayNumber = MealPlanDayConstants.SarahDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.SarahDay5DayOfWeek,
                    Calories = MealPlanDayConstants.SarahDay5Calories,
                    Protein = MealPlanDayConstants.SarahDay5Protein,
                    Carbs = MealPlanDayConstants.SarahDay5Carbs,
                    Fat = MealPlanDayConstants.SarahDay5Fat
                },

                // ========== MIKE'S MARATHON TRAINING - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay1DayOfWeek,
                    Calories = MealPlanDayConstants.MikeDay1Calories,
                    Protein = MealPlanDayConstants.MikeDay1Protein,
                    Carbs = MealPlanDayConstants.MikeDay1Carbs,
                    Fat = MealPlanDayConstants.MikeDay1Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay2DayOfWeek,
                    Calories = MealPlanDayConstants.MikeDay2Calories,
                    Protein = MealPlanDayConstants.MikeDay2Protein,
                    Carbs = MealPlanDayConstants.MikeDay2Carbs,
                    Fat = MealPlanDayConstants.MikeDay2Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay3DayOfWeek,
                    Calories = MealPlanDayConstants.MikeDay3Calories,
                    Protein = MealPlanDayConstants.MikeDay3Protein,
                    Carbs = MealPlanDayConstants.MikeDay3Carbs,
                    Fat = MealPlanDayConstants.MikeDay3Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay4DayOfWeek,
                    Calories = MealPlanDayConstants.MikeDay4Calories,
                    Protein = MealPlanDayConstants.MikeDay4Protein,
                    Carbs = MealPlanDayConstants.MikeDay4Carbs,
                    Fat = MealPlanDayConstants.MikeDay4Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.MikeDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.MikeMealPlanId),
                    DayNumber = MealPlanDayConstants.MikeDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.MikeDay5DayOfWeek,
                    Calories = MealPlanDayConstants.MikeDay5Calories,
                    Protein = MealPlanDayConstants.MikeDay5Protein,
                    Carbs = MealPlanDayConstants.MikeDay5Carbs,
                    Fat = MealPlanDayConstants.MikeDay5Fat
                },

                // ========== EMMA'S BALANCED NUTRITION - 5 Days ==========
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay1Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay1DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay1DayOfWeek,
                    Calories = MealPlanDayConstants.EmmaDay1Calories,
                    Protein = MealPlanDayConstants.EmmaDay1Protein,
                    Carbs = MealPlanDayConstants.EmmaDay1Carbs,
                    Fat = MealPlanDayConstants.EmmaDay1Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay2Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay2DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay2DayOfWeek,
                    Calories = MealPlanDayConstants.EmmaDay2Calories,
                    Protein = MealPlanDayConstants.EmmaDay2Protein,
                    Carbs = MealPlanDayConstants.EmmaDay2Carbs,
                    Fat = MealPlanDayConstants.EmmaDay2Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay3Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay3DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay3DayOfWeek,
                    Calories = MealPlanDayConstants.EmmaDay3Calories,
                    Protein = MealPlanDayConstants.EmmaDay3Protein,
                    Carbs = MealPlanDayConstants.EmmaDay3Carbs,
                    Fat = MealPlanDayConstants.EmmaDay3Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay4Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay4DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay4DayOfWeek,
                    Calories = MealPlanDayConstants.EmmaDay4Calories,
                    Protein = MealPlanDayConstants.EmmaDay4Protein,
                    Carbs = MealPlanDayConstants.EmmaDay4Carbs,
                    Fat = MealPlanDayConstants.EmmaDay4Fat
                },
                new MealPlanDay(seedingDate, Guid.Parse(MealPlanDayConstants.EmmaDay5Id))
                {
                    MealPlanId = Guid.Parse(MealPlanConstants.EmmaMealPlanId),
                    DayNumber = MealPlanDayConstants.EmmaDay5DayNumber,
                    DayOfWeek = MealPlanDayConstants.EmmaDay5DayOfWeek,
                    Calories = MealPlanDayConstants.EmmaDay5Calories,
                    Protein = MealPlanDayConstants.EmmaDay5Protein,
                    Carbs = MealPlanDayConstants.EmmaDay5Carbs,
                    Fat = MealPlanDayConstants.EmmaDay5Fat
                },

            };

            return mealPlanDays;
        }
    }
}