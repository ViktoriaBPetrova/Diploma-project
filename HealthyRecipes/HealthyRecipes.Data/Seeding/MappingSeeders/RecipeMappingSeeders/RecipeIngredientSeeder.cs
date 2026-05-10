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
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.ChickenBreastId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenRiceBowl_ChickenBreastQuantity },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.WhiteRiceId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenRiceBowl_RiceQuantity },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenRiceBowl_OliveOilQuantity },
                new RecipeIngredient(RecipeConstants.ChickenRiceBowlId, IngredientConstants.GarlicId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenRiceBowl_GarlicQuantity },
 
                // ========== VEGGIE OMELETTE ==========
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.EggsId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.VeggieOmelette_EggsQuantity },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.SpinachId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.VeggieOmelette_SpinachQuantity },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.TomatoId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.VeggieOmelette_TomatoQuantity },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.OnionId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.VeggieOmelette_OnionQuantity },
                new RecipeIngredient(RecipeConstants.VeggieOmeletteId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.VeggieOmelette_OliveOilQuantity },
 
                // ========== GREEK YOGURT BOWL ==========
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.GreekYogurtId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GreekYogurtBowl_GreekYogurtQuantity },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.BerriesId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GreekYogurtBowl_BerriesQuantity },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.HoneyId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GreekYogurtBowl_HoneyQuantity },
                new RecipeIngredient(RecipeConstants.GreekYogurtBowlId, IngredientConstants.AlmondsId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GreekYogurtBowl_AlmondsQuantity },
 
                // ========== BUDDHA BOWL ==========
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.QuinoaId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_QuinoaQuantity },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.ChickpeasId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_ChickpeasQuantity },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.AvocadoId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_AvocadoQuantity },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.SpinachId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_SpinachQuantity },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.TomatoId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_TomatoQuantity },
                new RecipeIngredient(RecipeConstants.BuddhaBowlId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.BuddhaBowl_OliveOilQuantity },
 
                // ========== OVERNIGHT OATS ==========
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.OatsId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.OvernightOats_OatsQuantity },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.AlmondMilkId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.OvernightOats_AlmondMilkQuantity },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.ChiaSeedsId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.OvernightOats_ChiaSeedsQuantity },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.BananaId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.OvernightOats_BananaQuantity },
                new RecipeIngredient(RecipeConstants.OvernightOatsId, IngredientConstants.HoneyId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.OvernightOats_HoneyQuantity },
 
                // ========== CHICKEN STIR-FRY ==========
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.ChickenBreastId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_ChickenBreastQuantity },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.BroccoliId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_BroccoliQuantity },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.BellPepperId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_BellPepperQuantity },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.SoySauceId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_SoySauceQuantity },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.GarlicId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_GarlicQuantity },
                new RecipeIngredient(RecipeConstants.ChickenStirFryId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.ChickenStirFry_OliveOilQuantity },
 
                // ========== GRILLED SALMON WITH QUINOA ==========
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.SalmonId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GrilledSalmonQuinoa_SalmonQuantity },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.QuinoaId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GrilledSalmonQuinoa_QuinoaQuantity },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.BroccoliId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GrilledSalmonQuinoa_BroccoliQuantity },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.LemonId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GrilledSalmonQuinoa_LemonQuantity },
                new RecipeIngredient(RecipeConstants.GrilledSalmonQuinoaId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.GrilledSalmonQuinoa_OliveOilQuantity },
 
                // ========== MEDITERRANEAN SALAD ==========
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.CucumberId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_CucumberQuantity },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.TomatoId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_TomatoQuantity },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.FetaCheeseId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_FetaCheeseQuantity },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.OnionId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_OnionQuantity },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.OliveOilId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_OliveOilQuantity },
                new RecipeIngredient(RecipeConstants.MediterraneanSaladId, IngredientConstants.LemonId, seedingDate)
                    { QuantityInGrams = RecipeIngredientConstants.MediterraneanSalad_LemonQuantity }
            };

            return recipeIngredients;
        }
    }
}