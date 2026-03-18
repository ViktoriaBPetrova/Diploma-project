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
            // ========== JOHN'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1BreakfastId)) { Type = MealConstants.JohnDay1BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1LunchId)) { Type = MealConstants.JohnDay1LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1DinnerId)) { Type = MealConstants.JohnDay1DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id) },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2BreakfastId)) { Type = MealConstants.JohnDay2BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2LunchId)) { Type = MealConstants.JohnDay2LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2DinnerId)) { Type = MealConstants.JohnDay2DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id) },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3BreakfastId)) { Type = MealConstants.JohnDay3BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3LunchId)) { Type = MealConstants.JohnDay3LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3DinnerId)) { Type = MealConstants.JohnDay3DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id) },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4BreakfastId)) { Type = MealConstants.JohnDay4BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4LunchId)) { Type = MealConstants.JohnDay4LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4DinnerId)) { Type = MealConstants.JohnDay4DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id) },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5BreakfastId)) { Type = MealConstants.JohnDay5BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5LunchId)) { Type = MealConstants.JohnDay5LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5DinnerId)) { Type = MealConstants.JohnDay5DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id) },

                // ========== SARAH'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1BreakfastId)) { Type = MealConstants.SarahDay1BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1LunchId)) { Type = MealConstants.SarahDay1LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1DinnerId)) { Type = MealConstants.SarahDay1DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id) },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2BreakfastId)) { Type = MealConstants.SarahDay2BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2LunchId)) { Type = MealConstants.SarahDay2LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2DinnerId)) { Type = MealConstants.SarahDay2DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id) },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3BreakfastId)) { Type = MealConstants.SarahDay3BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3LunchId)) { Type = MealConstants.SarahDay3LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3DinnerId)) { Type = MealConstants.SarahDay3DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id) },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4BreakfastId)) { Type = MealConstants.SarahDay4BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4LunchId)) { Type = MealConstants.SarahDay4LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4DinnerId)) { Type = MealConstants.SarahDay4DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id) },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5BreakfastId)) { Type = MealConstants.SarahDay5BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5LunchId)) { Type = MealConstants.SarahDay5LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5DinnerId)) { Type = MealConstants.SarahDay5DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id) },

                // ========== MIKE'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1BreakfastId)) { Type = MealConstants.MikeDay1BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1LunchId)) { Type = MealConstants.MikeDay1LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1DinnerId)) { Type = MealConstants.MikeDay1DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id) },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2BreakfastId)) { Type = MealConstants.MikeDay2BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2LunchId)) { Type = MealConstants.MikeDay2LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2DinnerId)) { Type = MealConstants.MikeDay2DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id) },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3BreakfastId)) { Type = MealConstants.MikeDay3BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3LunchId)) { Type = MealConstants.MikeDay3LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3DinnerId)) { Type = MealConstants.MikeDay3DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id) },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4BreakfastId)) { Type = MealConstants.MikeDay4BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4LunchId)) { Type = MealConstants.MikeDay4LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4DinnerId)) { Type = MealConstants.MikeDay4DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id) },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5BreakfastId)) { Type = MealConstants.MikeDay5BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5LunchId)) { Type = MealConstants.MikeDay5LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5DinnerId)) { Type = MealConstants.MikeDay5DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id) },

                // ========== EMMA'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1BreakfastId)) { Type = MealConstants.EmmaDay1BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1LunchId)) { Type = MealConstants.EmmaDay1LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1DinnerId)) { Type = MealConstants.EmmaDay1DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id) },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2BreakfastId)) { Type = MealConstants.EmmaDay2BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2LunchId)) { Type = MealConstants.EmmaDay2LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2DinnerId)) { Type = MealConstants.EmmaDay2DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id) },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3BreakfastId)) { Type = MealConstants.EmmaDay3BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3LunchId)) { Type = MealConstants.EmmaDay3LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3DinnerId)) { Type = MealConstants.EmmaDay3DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id) },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4BreakfastId)) { Type = MealConstants.EmmaDay4BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4LunchId)) { Type = MealConstants.EmmaDay4LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4DinnerId)) { Type = MealConstants.EmmaDay4DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id) },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5BreakfastId)) { Type = MealConstants.EmmaDay5BreakfastType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5LunchId)) { Type = MealConstants.EmmaDay5LunchType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id) },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5DinnerId)) { Type = MealConstants.EmmaDay5DinnerType, MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id) },
            };

            return meals;
        }
    }
}
