using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MealPlanConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanMappingSeeders
{
    public class MealPlanCategorySeeder
    {
        public static IEnumerable<MealPlanCategory> GenerateMealPlanCategory()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            IEnumerable<MealPlanCategory> mealPlanCategories = new HashSet<MealPlanCategory>()
            {

                new MealPlanCategory(MealPlanConstants.UserMealPlanId, CategoryConstants.HighProteinId, seedingDate),

            };

            return mealPlanCategories;
        }
    }
}
