using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanFollowerSeeders
{
    public static class MealPlanFollowerSeeder
    {
        public static IEnumerable<MealPlanFollower> GenerateMealPlanFollowers()
        {
            DateTime seedingDate = new DateTime(2025, 4, 20);

            IEnumerable<MealPlanFollower> mealPlanFollowers = new List<MealPlanFollower>()
            {
                // User actively following UserMealPlan
                new MealPlanFollower(
                    Guid.Parse(UserConstants.UserId),
                    Guid.Parse(MealPlanConstants.UserMealPlanId),
                    seedingDate
                )
                {
                    IsActive = true,
                    Status = MealPlanFollowerStatus.Active
                },
            };

            return mealPlanFollowers;
        }
    }
}
