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
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1BreakfastId))
                {
                    Type = MealConstants.JohnDay1BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id),
                    Calories = MealConstants.JohnDay1BreakfastCalories,
                    Protein = MealConstants.JohnDay1BreakfastProtein,
                    Carbs = MealConstants.JohnDay1BreakfastCarbs,
                    Fat = MealConstants.JohnDay1BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1LunchId))
                {
                    Type = MealConstants.JohnDay1LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id),
                    Calories = MealConstants.JohnDay1LunchCalories,
                    Protein = MealConstants.JohnDay1LunchProtein,
                    Carbs = MealConstants.JohnDay1LunchCarbs,
                    Fat = MealConstants.JohnDay1LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay1DinnerId))
                {
                    Type = MealConstants.JohnDay1DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay1Id),
                    Calories = MealConstants.JohnDay1DinnerCalories,
                    Protein = MealConstants.JohnDay1DinnerProtein,
                    Carbs = MealConstants.JohnDay1DinnerCarbs,
                    Fat = MealConstants.JohnDay1DinnerFat
                },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2BreakfastId))
                {
                    Type = MealConstants.JohnDay2BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id),
                    Calories = MealConstants.JohnDay2BreakfastCalories,
                    Protein = MealConstants.JohnDay2BreakfastProtein,
                    Carbs = MealConstants.JohnDay2BreakfastCarbs,
                    Fat = MealConstants.JohnDay2BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2LunchId))
                {
                    Type = MealConstants.JohnDay2LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id),
                    Calories = MealConstants.JohnDay2LunchCalories,
                    Protein = MealConstants.JohnDay2LunchProtein,
                    Carbs = MealConstants.JohnDay2LunchCarbs,
                    Fat = MealConstants.JohnDay2LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay2DinnerId))
                {
                    Type = MealConstants.JohnDay2DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay2Id),
                    Calories = MealConstants.JohnDay2DinnerCalories,
                    Protein = MealConstants.JohnDay2DinnerProtein,
                    Carbs = MealConstants.JohnDay2DinnerCarbs,
                    Fat = MealConstants.JohnDay2DinnerFat
                },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3BreakfastId))
                {
                    Type = MealConstants.JohnDay3BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id),
                    Calories = MealConstants.JohnDay3BreakfastCalories,
                    Protein = MealConstants.JohnDay3BreakfastProtein,
                    Carbs = MealConstants.JohnDay3BreakfastCarbs,
                    Fat = MealConstants.JohnDay3BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3LunchId))
                {
                    Type = MealConstants.JohnDay3LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id),
                    Calories = MealConstants.JohnDay3LunchCalories,
                    Protein = MealConstants.JohnDay3LunchProtein,
                    Carbs = MealConstants.JohnDay3LunchCarbs,
                    Fat = MealConstants.JohnDay3LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay3DinnerId))
                {
                    Type = MealConstants.JohnDay3DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay3Id),
                    Calories = MealConstants.JohnDay3DinnerCalories,
                    Protein = MealConstants.JohnDay3DinnerProtein,
                    Carbs = MealConstants.JohnDay3DinnerCarbs,
                    Fat = MealConstants.JohnDay3DinnerFat
                },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4BreakfastId))
                {
                    Type = MealConstants.JohnDay4BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id),
                    Calories = MealConstants.JohnDay4BreakfastCalories,
                    Protein = MealConstants.JohnDay4BreakfastProtein,
                    Carbs = MealConstants.JohnDay4BreakfastCarbs,
                    Fat = MealConstants.JohnDay4BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4LunchId))
                {
                    Type = MealConstants.JohnDay4LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id),
                    Calories = MealConstants.JohnDay4LunchCalories,
                    Protein = MealConstants.JohnDay4LunchProtein,
                    Carbs = MealConstants.JohnDay4LunchCarbs,
                    Fat = MealConstants.JohnDay4LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay4DinnerId))
                {
                    Type = MealConstants.JohnDay4DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay4Id),
                    Calories = MealConstants.JohnDay4DinnerCalories,
                    Protein = MealConstants.JohnDay4DinnerProtein,
                    Carbs = MealConstants.JohnDay4DinnerCarbs,
                    Fat = MealConstants.JohnDay4DinnerFat
                },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5BreakfastId))
                {
                    Type = MealConstants.JohnDay5BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id),
                    Calories = MealConstants.JohnDay5BreakfastCalories,
                    Protein = MealConstants.JohnDay5BreakfastProtein,
                    Carbs = MealConstants.JohnDay5BreakfastCarbs,
                    Fat = MealConstants.JohnDay5BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5LunchId))
                {
                    Type = MealConstants.JohnDay5LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id),
                    Calories = MealConstants.JohnDay5LunchCalories,
                    Protein = MealConstants.JohnDay5LunchProtein,
                    Carbs = MealConstants.JohnDay5LunchCarbs,
                    Fat = MealConstants.JohnDay5LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.JohnDay5DinnerId))
                {
                    Type = MealConstants.JohnDay5DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.JohnDay5Id),
                    Calories = MealConstants.JohnDay5DinnerCalories,
                    Protein = MealConstants.JohnDay5DinnerProtein,
                    Carbs = MealConstants.JohnDay5DinnerCarbs,
                    Fat = MealConstants.JohnDay5DinnerFat
                },

                // ========== SARAH'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1BreakfastId))
                {
                    Type = MealConstants.SarahDay1BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id),
                    Calories = MealConstants.SarahDay1BreakfastCalories,
                    Protein = MealConstants.SarahDay1BreakfastProtein,
                    Carbs = MealConstants.SarahDay1BreakfastCarbs,
                    Fat = MealConstants.SarahDay1BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1LunchId))
                {
                    Type = MealConstants.SarahDay1LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id),
                    Calories = MealConstants.SarahDay1LunchCalories,
                    Protein = MealConstants.SarahDay1LunchProtein,
                    Carbs = MealConstants.SarahDay1LunchCarbs,
                    Fat = MealConstants.SarahDay1LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay1DinnerId))
                {
                    Type = MealConstants.SarahDay1DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay1Id),
                    Calories = MealConstants.SarahDay1DinnerCalories,
                    Protein = MealConstants.SarahDay1DinnerProtein,
                    Carbs = MealConstants.SarahDay1DinnerCarbs,
                    Fat = MealConstants.SarahDay1DinnerFat
                },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2BreakfastId))
                {
                    Type = MealConstants.SarahDay2BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id),
                    Calories = MealConstants.SarahDay2BreakfastCalories,
                    Protein = MealConstants.SarahDay2BreakfastProtein,
                    Carbs = MealConstants.SarahDay2BreakfastCarbs,
                    Fat = MealConstants.SarahDay2BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2LunchId))
                {
                    Type = MealConstants.SarahDay2LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id),
                    Calories = MealConstants.SarahDay2LunchCalories,
                    Protein = MealConstants.SarahDay2LunchProtein,
                    Carbs = MealConstants.SarahDay2LunchCarbs,
                    Fat = MealConstants.SarahDay2LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay2DinnerId))
                {
                    Type = MealConstants.SarahDay2DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay2Id),
                    Calories = MealConstants.SarahDay2DinnerCalories,
                    Protein = MealConstants.SarahDay2DinnerProtein,
                    Carbs = MealConstants.SarahDay2DinnerCarbs,
                    Fat = MealConstants.SarahDay2DinnerFat
                },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3BreakfastId))
                {
                    Type = MealConstants.SarahDay3BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id),
                    Calories = MealConstants.SarahDay3BreakfastCalories,
                    Protein = MealConstants.SarahDay3BreakfastProtein,
                    Carbs = MealConstants.SarahDay3BreakfastCarbs,
                    Fat = MealConstants.SarahDay3BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3LunchId))
                {
                    Type = MealConstants.SarahDay3LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id),
                    Calories = MealConstants.SarahDay3LunchCalories,
                    Protein = MealConstants.SarahDay3LunchProtein,
                    Carbs = MealConstants.SarahDay3LunchCarbs,
                    Fat = MealConstants.SarahDay3LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay3DinnerId))
                {
                    Type = MealConstants.SarahDay3DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay3Id),
                    Calories = MealConstants.SarahDay3DinnerCalories,
                    Protein = MealConstants.SarahDay3DinnerProtein,
                    Carbs = MealConstants.SarahDay3DinnerCarbs,
                    Fat = MealConstants.SarahDay3DinnerFat
                },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4BreakfastId))
                {
                    Type = MealConstants.SarahDay4BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id),
                    Calories = MealConstants.SarahDay4BreakfastCalories,
                    Protein = MealConstants.SarahDay4BreakfastProtein,
                    Carbs = MealConstants.SarahDay4BreakfastCarbs,
                    Fat = MealConstants.SarahDay4BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4LunchId))
                {
                    Type = MealConstants.SarahDay4LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id),
                    Calories = MealConstants.SarahDay4LunchCalories,
                    Protein = MealConstants.SarahDay4LunchProtein,
                    Carbs = MealConstants.SarahDay4LunchCarbs,
                    Fat = MealConstants.SarahDay4LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay4DinnerId))
                {
                    Type = MealConstants.SarahDay4DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay4Id),
                    Calories = MealConstants.SarahDay4DinnerCalories,
                    Protein = MealConstants.SarahDay4DinnerProtein,
                    Carbs = MealConstants.SarahDay4DinnerCarbs,
                    Fat = MealConstants.SarahDay4DinnerFat
                },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5BreakfastId))
                {
                    Type = MealConstants.SarahDay5BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id),
                    Calories = MealConstants.SarahDay5BreakfastCalories,
                    Protein = MealConstants.SarahDay5BreakfastProtein,
                    Carbs = MealConstants.SarahDay5BreakfastCarbs,
                    Fat = MealConstants.SarahDay5BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5LunchId))
                {
                    Type = MealConstants.SarahDay5LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id),
                    Calories = MealConstants.SarahDay5LunchCalories,
                    Protein = MealConstants.SarahDay5LunchProtein,
                    Carbs = MealConstants.SarahDay5LunchCarbs,
                    Fat = MealConstants.SarahDay5LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.SarahDay5DinnerId))
                {
                    Type = MealConstants.SarahDay5DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.SarahDay5Id),
                    Calories = MealConstants.SarahDay5DinnerCalories,
                    Protein = MealConstants.SarahDay5DinnerProtein,
                    Carbs = MealConstants.SarahDay5DinnerCarbs,
                    Fat = MealConstants.SarahDay5DinnerFat
                },

                // ========== MIKE'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1BreakfastId))
                {
                    Type = MealConstants.MikeDay1BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id),
                    Calories = MealConstants.MikeDay1BreakfastCalories,
                    Protein = MealConstants.MikeDay1BreakfastProtein,
                    Carbs = MealConstants.MikeDay1BreakfastCarbs,
                    Fat = MealConstants.MikeDay1BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1LunchId))
                {
                    Type = MealConstants.MikeDay1LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id),
                    Calories = MealConstants.MikeDay1LunchCalories,
                    Protein = MealConstants.MikeDay1LunchProtein,
                    Carbs = MealConstants.MikeDay1LunchCarbs,
                    Fat = MealConstants.MikeDay1LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay1DinnerId))
                {
                    Type = MealConstants.MikeDay1DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay1Id),
                    Calories = MealConstants.MikeDay1DinnerCalories,
                    Protein = MealConstants.MikeDay1DinnerProtein,
                    Carbs = MealConstants.MikeDay1DinnerCarbs,
                    Fat = MealConstants.MikeDay1DinnerFat
                },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2BreakfastId))
                {
                    Type = MealConstants.MikeDay2BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id),
                    Calories = MealConstants.MikeDay2BreakfastCalories,
                    Protein = MealConstants.MikeDay2BreakfastProtein,
                    Carbs = MealConstants.MikeDay2BreakfastCarbs,
                    Fat = MealConstants.MikeDay2BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2LunchId))
                {
                    Type = MealConstants.MikeDay2LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id),
                    Calories = MealConstants.MikeDay2LunchCalories,
                    Protein = MealConstants.MikeDay2LunchProtein,
                    Carbs = MealConstants.MikeDay2LunchCarbs,
                    Fat = MealConstants.MikeDay2LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay2DinnerId))
                {
                    Type = MealConstants.MikeDay2DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay2Id),
                    Calories = MealConstants.MikeDay2DinnerCalories,
                    Protein = MealConstants.MikeDay2DinnerProtein,
                    Carbs = MealConstants.MikeDay2DinnerCarbs,
                    Fat = MealConstants.MikeDay2DinnerFat
                },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3BreakfastId))
                {
                    Type = MealConstants.MikeDay3BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id),
                    Calories = MealConstants.MikeDay3BreakfastCalories,
                    Protein = MealConstants.MikeDay3BreakfastProtein,
                    Carbs = MealConstants.MikeDay3BreakfastCarbs,
                    Fat = MealConstants.MikeDay3BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3LunchId))
                {
                    Type = MealConstants.MikeDay3LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id),
                    Calories = MealConstants.MikeDay3LunchCalories,
                    Protein = MealConstants.MikeDay3LunchProtein,
                    Carbs = MealConstants.MikeDay3LunchCarbs,
                    Fat = MealConstants.MikeDay3LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay3DinnerId))
                {
                    Type = MealConstants.MikeDay3DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay3Id),
                    Calories = MealConstants.MikeDay3DinnerCalories,
                    Protein = MealConstants.MikeDay3DinnerProtein,
                    Carbs = MealConstants.MikeDay3DinnerCarbs,
                    Fat = MealConstants.MikeDay3DinnerFat
                },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4BreakfastId))
                {
                    Type = MealConstants.MikeDay4BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id),
                    Calories = MealConstants.MikeDay4BreakfastCalories,
                    Protein = MealConstants.MikeDay4BreakfastProtein,
                    Carbs = MealConstants.MikeDay4BreakfastCarbs,
                    Fat = MealConstants.MikeDay4BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4LunchId))
                {
                    Type = MealConstants.MikeDay4LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id),
                    Calories = MealConstants.MikeDay4LunchCalories,
                    Protein = MealConstants.MikeDay4LunchProtein,
                    Carbs = MealConstants.MikeDay4LunchCarbs,
                    Fat = MealConstants.MikeDay4LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay4DinnerId))
                {
                    Type = MealConstants.MikeDay4DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay4Id),
                    Calories = MealConstants.MikeDay4DinnerCalories,
                    Protein = MealConstants.MikeDay4DinnerProtein,
                    Carbs = MealConstants.MikeDay4DinnerCarbs,
                    Fat = MealConstants.MikeDay4DinnerFat
                },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5BreakfastId))
                {
                    Type = MealConstants.MikeDay5BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id),
                    Calories = MealConstants.MikeDay5BreakfastCalories,
                    Protein = MealConstants.MikeDay5BreakfastProtein,
                    Carbs = MealConstants.MikeDay5BreakfastCarbs,
                    Fat = MealConstants.MikeDay5BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5LunchId))
                {
                    Type = MealConstants.MikeDay5LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id),
                    Calories = MealConstants.MikeDay5LunchCalories,
                    Protein = MealConstants.MikeDay5LunchProtein,
                    Carbs = MealConstants.MikeDay5LunchCarbs,
                    Fat = MealConstants.MikeDay5LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.MikeDay5DinnerId))
                {
                    Type = MealConstants.MikeDay5DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.MikeDay5Id),
                    Calories = MealConstants.MikeDay5DinnerCalories,
                    Protein = MealConstants.MikeDay5DinnerProtein,
                    Carbs = MealConstants.MikeDay5DinnerCarbs,
                    Fat = MealConstants.MikeDay5DinnerFat
                },

                // ========== EMMA'S MEAL PLAN ==========
                // Day 1
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1BreakfastId))
                {
                    Type = MealConstants.EmmaDay1BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id),
                    Calories = MealConstants.EmmaDay1BreakfastCalories,
                    Protein = MealConstants.EmmaDay1BreakfastProtein,
                    Carbs = MealConstants.EmmaDay1BreakfastCarbs,
                    Fat = MealConstants.EmmaDay1BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1LunchId))
                {
                    Type = MealConstants.EmmaDay1LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id),
                    Calories = MealConstants.EmmaDay1LunchCalories,
                    Protein = MealConstants.EmmaDay1LunchProtein,
                    Carbs = MealConstants.EmmaDay1LunchCarbs,
                    Fat = MealConstants.EmmaDay1LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay1DinnerId))
                {
                    Type = MealConstants.EmmaDay1DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay1Id),
                    Calories = MealConstants.EmmaDay1DinnerCalories,
                    Protein = MealConstants.EmmaDay1DinnerProtein,
                    Carbs = MealConstants.EmmaDay1DinnerCarbs,
                    Fat = MealConstants.EmmaDay1DinnerFat
                },
                // Day 2
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2BreakfastId))
                {
                    Type = MealConstants.EmmaDay2BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id),
                    Calories = MealConstants.EmmaDay2BreakfastCalories,
                    Protein = MealConstants.EmmaDay2BreakfastProtein,
                    Carbs = MealConstants.EmmaDay2BreakfastCarbs,
                    Fat = MealConstants.EmmaDay2BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2LunchId))
                {
                    Type = MealConstants.EmmaDay2LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id),
                    Calories = MealConstants.EmmaDay2LunchCalories,
                    Protein = MealConstants.EmmaDay2LunchProtein,
                    Carbs = MealConstants.EmmaDay2LunchCarbs,
                    Fat = MealConstants.EmmaDay2LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay2DinnerId))
                {
                    Type = MealConstants.EmmaDay2DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay2Id),
                    Calories = MealConstants.EmmaDay2DinnerCalories,
                    Protein = MealConstants.EmmaDay2DinnerProtein,
                    Carbs = MealConstants.EmmaDay2DinnerCarbs,
                    Fat = MealConstants.EmmaDay2DinnerFat
                },
                // Day 3
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3BreakfastId))
                {
                    Type = MealConstants.EmmaDay3BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id),
                    Calories = MealConstants.EmmaDay3BreakfastCalories,
                    Protein = MealConstants.EmmaDay3BreakfastProtein,
                    Carbs = MealConstants.EmmaDay3BreakfastCarbs,
                    Fat = MealConstants.EmmaDay3BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3LunchId))
                {
                    Type = MealConstants.EmmaDay3LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id),
                    Calories = MealConstants.EmmaDay3LunchCalories,
                    Protein = MealConstants.EmmaDay3LunchProtein,
                    Carbs = MealConstants.EmmaDay3LunchCarbs,
                    Fat = MealConstants.EmmaDay3LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay3DinnerId))
                {
                    Type = MealConstants.EmmaDay3DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay3Id),
                    Calories = MealConstants.EmmaDay3DinnerCalories,
                    Protein = MealConstants.EmmaDay3DinnerProtein,
                    Carbs = MealConstants.EmmaDay3DinnerCarbs,
                    Fat = MealConstants.EmmaDay3DinnerFat
                },
                // Day 4
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4BreakfastId))
                {
                    Type = MealConstants.EmmaDay4BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id),
                    Calories = MealConstants.EmmaDay4BreakfastCalories,
                    Protein = MealConstants.EmmaDay4BreakfastProtein,
                    Carbs = MealConstants.EmmaDay4BreakfastCarbs,
                    Fat = MealConstants.EmmaDay4BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4LunchId))
                {
                    Type = MealConstants.EmmaDay4LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id),
                    Calories = MealConstants.EmmaDay4LunchCalories,
                    Protein = MealConstants.EmmaDay4LunchProtein,
                    Carbs = MealConstants.EmmaDay4LunchCarbs,
                    Fat = MealConstants.EmmaDay4LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay4DinnerId))
                {
                    Type = MealConstants.EmmaDay4DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay4Id),
                    Calories = MealConstants.EmmaDay4DinnerCalories,
                    Protein = MealConstants.EmmaDay4DinnerProtein,
                    Carbs = MealConstants.EmmaDay4DinnerCarbs,
                    Fat = MealConstants.EmmaDay4DinnerFat
                },
                // Day 5
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5BreakfastId))
                {
                    Type = MealConstants.EmmaDay5BreakfastType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id),
                    Calories = MealConstants.EmmaDay5BreakfastCalories,
                    Protein = MealConstants.EmmaDay5BreakfastProtein,
                    Carbs = MealConstants.EmmaDay5BreakfastCarbs,
                    Fat = MealConstants.EmmaDay5BreakfastFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5LunchId))
                {
                    Type = MealConstants.EmmaDay5LunchType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id),
                    Calories = MealConstants.EmmaDay5LunchCalories,
                    Protein = MealConstants.EmmaDay5LunchProtein,
                    Carbs = MealConstants.EmmaDay5LunchCarbs,
                    Fat = MealConstants.EmmaDay5LunchFat
                },
                new Meal(seedingDate, Guid.Parse(MealConstants.EmmaDay5DinnerId))
                {
                    Type = MealConstants.EmmaDay5DinnerType,
                    MealPlanDayId = Guid.Parse(MealPlanDayConstants.EmmaDay5Id),
                    Calories = MealConstants.EmmaDay5DinnerCalories,
                    Protein = MealConstants.EmmaDay5DinnerProtein,
                    Carbs = MealConstants.EmmaDay5DinnerCarbs,
                    Fat = MealConstants.EmmaDay5DinnerFat
                },
            };

            return meals;
        }
    }
}