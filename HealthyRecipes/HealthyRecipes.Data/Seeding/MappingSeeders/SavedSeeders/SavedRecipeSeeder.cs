using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.SavedSeeders
{
    public class SavedRecipeSeeder
    {
        public static IEnumerable<SavedRecipe> GenerateSavedRecipe()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            IEnumerable<SavedRecipe> savedRecipes = new List<SavedRecipe>()
            {

                new SavedRecipe(RecipeConstants.ChickenRiceBowlId, UserConstants.UserId, seedingDate),

            };

            return savedRecipes;
        }
    }
}
