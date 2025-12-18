using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Seeding.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding
{
    public class IngredientSeeder
    {
        public static ICollection<Ingredient> GenerateIngredients()
        {
            DateTime seedingDate = new DateTime(2025, 12, 18);

            ICollection<Ingredient> ingredients = new List<Ingredient>()
            {
            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.ChickenBreastId),
                IngredientConstants.ChickenBreastCaloriesPer100g,
                IngredientConstants.ChickenBreastFatPer100g,
                IngredientConstants.ChickenBreastCarbsPer100g,
                IngredientConstants.ChickenBreastProteinPer100g)
            {
                Name = IngredientConstants.ChickenBreastName,
                Brand = IngredientConstants.ChickenBreastBrand,
                Source = IngredientConstants.ChickenBreastSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.WhiteRiceId),
                IngredientConstants.WhiteRiceCaloriesPer100g,
                IngredientConstants.WhiteRiceFatPer100g,
                IngredientConstants.WhiteRiceCarbsPer100g,
                IngredientConstants.WhiteRiceProteinPer100g)
            {
                Name = IngredientConstants.WhiteRiceName,
                Brand = IngredientConstants.WhiteRiceBrand,
                Source = IngredientConstants.WhiteRiceSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.OliveOilId),
                IngredientConstants.OliveOilCaloriesPer100g,
                IngredientConstants.OliveOilFatPer100g,
                IngredientConstants.OliveOilCarbsPer100g,
                IngredientConstants.OliveOilProteinPer100g)
            {
                Name = IngredientConstants.OliveOilName,
                Brand = IngredientConstants.OliveOilBrand,
                Source = IngredientConstants.OliveOilSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.OnionId),
                IngredientConstants.OnionCaloriesPer100g,
                IngredientConstants.OnionFatPer100g,
                IngredientConstants.OnionCarbsPer100g,
                IngredientConstants.OnionProteinPer100g)
            {
                Name = IngredientConstants.OnionName,
                Brand = IngredientConstants.OnionBrand,
                Source = IngredientConstants.OnionSource
            },

            new Ingredient(
                seedingDate,
                Guid.Parse(IngredientConstants.GarlicId),
                IngredientConstants.GarlicCaloriesPer100g,
                IngredientConstants.GarlicFatPer100g,
                IngredientConstants.GarlicCarbsPer100g,
                IngredientConstants.GarlicProteinPer100g)
            {
                Name = IngredientConstants.GarlicName,
                Brand = IngredientConstants.GarlicBrand,
                Source = IngredientConstants.GarlicSource
            }
            };

            return ingredients;
        }
    }
}
