using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public class RecipeSeeder
    {
        public static IEnumerable<Recipe> GenerateRecipes()
        {
            DateTime seedingDate = new DateTime(2025, 4, 20);

            IEnumerable<Recipe> recipes = new HashSet<Recipe>()
            {
            new Recipe(
                seedingDate,
                Guid.Parse(RecipeConstants.ChickenRiceBowlId)
                /*RecipeConstants.ChickenRiceBowlCalories,
                RecipeConstants.ChickenRiceBowlFat,
                RecipeConstants.ChickenRiceBowlCarbs,
                RecipeConstants.ChickenRiceBowlProtein*/)
            {
                Info = RecipeConstants.ChickenRiceBowlInfo,
                PrepTime = RecipeConstants.ChickenRiceBowlPrepTime,
                Difficulty = RecipeConstants.ChickenRiceBowlDifficulty,
                UserId = Guid.Parse(UserConstants.UserId)
            }
            };

            return recipes;
        }
    }
}
