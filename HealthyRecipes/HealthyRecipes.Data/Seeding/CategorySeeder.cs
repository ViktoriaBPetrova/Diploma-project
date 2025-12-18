using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public class CategorySeeder
    {
        public static IEnumerable<Category> GenerateCategories()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            IEnumerable<Category> categories = new List<Category>()
            {
            new Category(
                seedingDate,
                Guid.Parse(CategoryConstants.MainDishId),
                CategoryConstants.MainDishName
            ),

            new Category(
                seedingDate,
                Guid.Parse(CategoryConstants.HealthyId),
                CategoryConstants.HealthyName
            ),

            new Category(
                seedingDate,
                Guid.Parse(CategoryConstants.HighProteinId),
                CategoryConstants.HighProteinName
            ),

            new Category(
                seedingDate,
                Guid.Parse(CategoryConstants.EasyQuickId),
                CategoryConstants.EasyQuickName
            ),

            new Category(
                seedingDate,
                Guid.Parse(CategoryConstants.MealPrepId),
                CategoryConstants.MealPrepName
            )
            };

            return categories;
        }
    }
}
