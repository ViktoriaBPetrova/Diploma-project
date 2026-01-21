using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.MappingSeeders.RecipeMappingSeeders
{
    public class RecipeIngredientSeeder
    {
        public static IEnumerable<RecipeIngredient> GenerateRecipeIngredients()
        {
            // Single seeding date for all mappings
            DateTime seedingDate = new DateTime(2025, 12, 18);

            List<RecipeIngredient> recipeIngredients = new List<RecipeIngredient>()
            {
            new RecipeIngredient(
                RecipeConstants.ChickenRiceBowlId,
                IngredientConstants.ChickenBreastId,
                seedingDate
            )
            {
                QuantityInGrams = RecipeIngredientConstants.ChickenBreastQuantity
            },

            new RecipeIngredient(
                RecipeConstants.ChickenRiceBowlId,
                IngredientConstants.WhiteRiceId,
                seedingDate
            )
            {
                QuantityInGrams = RecipeIngredientConstants.RiceQuantity
            },

            new RecipeIngredient(
                RecipeConstants.ChickenRiceBowlId,
                IngredientConstants.OliveOilId,
                seedingDate
            )
            {
                QuantityInGrams = RecipeIngredientConstants.OliveOilQuantity
            },

            new RecipeIngredient(
                RecipeConstants.ChickenRiceBowlId,
                IngredientConstants.GarlicId,
                seedingDate
            )
            {
                QuantityInGrams = RecipeIngredientConstants.GarlicQuantity
            }
            };

            return recipeIngredients;
        }
    }
}
