using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.RecipeMappingSeeders
{
    public class RecipeCategorySeeder
    {
        public static IEnumerable<RecipeCategory> GenerateRecipeCategory()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            IEnumerable<RecipeCategory> recipeCategories = new HashSet<RecipeCategory>()
            {
                
                new RecipeCategory(RecipeConstants.ChickenRiceBowlId, CategoryConstants.HighProteinId, seedingDate),
                
            };

            return recipeCategories;
        }
    }
}
