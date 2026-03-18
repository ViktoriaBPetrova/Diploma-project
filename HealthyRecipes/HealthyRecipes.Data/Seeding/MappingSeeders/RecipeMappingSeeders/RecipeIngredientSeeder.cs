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
                            // ========== CHICKEN RICE BOWL ==========
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.ChickenBreastId, seedingDate) { QuantityInGrams = 200 },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.WhiteRiceId, seedingDate) { QuantityInGrams = 100 },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 10 },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.GarlicId, seedingDate) { QuantityInGrams = 5 },
 
                // ========== VEGGIE OMELETTE ==========
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.EggsId, seedingDate) { QuantityInGrams = 150 }, // ~3 eggs
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.SpinachId, seedingDate) { QuantityInGrams = 50 },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.TomatoId, seedingDate) { QuantityInGrams = 80 },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.OnionId, seedingDate) { QuantityInGrams = 40 },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 10 },
 
                // ========== GREEK YOGURT BOWL ==========
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.GreekYogurtId, seedingDate) { QuantityInGrams = 200 },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.BerriesId, seedingDate) { QuantityInGrams = 100 },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.HoneyId, seedingDate) { QuantityInGrams = 15 },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.AlmondsId, seedingDate) { QuantityInGrams = 30 },
 
                // ========== BUDDHA BOWL ==========
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.QuinoaId, seedingDate) { QuantityInGrams = 80 },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.ChickpeasId, seedingDate) { QuantityInGrams = 150 },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.AvocadoId, seedingDate) { QuantityInGrams = 100 },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.SpinachId, seedingDate) { QuantityInGrams = 60 },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.TomatoId, seedingDate) { QuantityInGrams = 80 },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 15 },
 
                // ========== OVERNIGHT OATS ==========
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.OatsId, seedingDate) { QuantityInGrams = 50 },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.AlmondMilkId, seedingDate) { QuantityInGrams = 200 },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.ChiaSeedsId, seedingDate) { QuantityInGrams = 15 },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.BananaId, seedingDate) { QuantityInGrams = 120 },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.HoneyId, seedingDate) { QuantityInGrams = 10 },
 
                // ========== CHICKEN STIR-FRY ==========
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.ChickenBreastId, seedingDate) { QuantityInGrams = 200 },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.BroccoliId, seedingDate) { QuantityInGrams = 150 },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.BellPepperId, seedingDate) { QuantityInGrams = 100 },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.SoySauceId, seedingDate) { QuantityInGrams = 20 },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.GarlicId, seedingDate) { QuantityInGrams = 5 },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 10 },
 
                // ========== GRILLED SALMON WITH QUINOA ==========
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.SalmonId, seedingDate) { QuantityInGrams = 180 },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.QuinoaId, seedingDate) { QuantityInGrams = 80 },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.BroccoliId, seedingDate) { QuantityInGrams = 100 },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.LemonId, seedingDate) { QuantityInGrams = 30 },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 10 },
 
                // ========== MEDITERRANEAN SALAD ==========
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.CucumberId, seedingDate) { QuantityInGrams = 150 },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.TomatoId, seedingDate) { QuantityInGrams = 200 },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.FetaCheeseId, seedingDate) { QuantityInGrams = 50 },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.OnionId, seedingDate) { QuantityInGrams = 40 },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.OliveOilId, seedingDate) { QuantityInGrams = 15 },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.LemonId, seedingDate) { QuantityInGrams = 20 }
            };

            return recipeIngredients;
        }
    }
}
