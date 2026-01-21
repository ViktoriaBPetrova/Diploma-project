using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants.MappingConstants
{
    public class RecipeIngredientConstants
    {
        // ---------- Recipe IDs ----------
        public const string ChickenRiceBowlRecipeId = RecipeConstants.ChickenRiceBowlId;

        // ---------- Ingredient IDs ----------
        public const string ChickenBreastIngredientId = IngredientConstants.ChickenBreastId;
        public const string RiceIngredientId = IngredientConstants.WhiteRiceId;
        public const string OliveOilIngredientId = IngredientConstants.OliveOilId;
        public const string GarlicIngredientId = IngredientConstants.GarlicId;

        // ---------- Quantities (grams) ----------
        public const float ChickenBreastQuantity = 200f;
        public const float RiceQuantity = 150f;
        public const float OliveOilQuantity = 10f;
        public const float GarlicQuantity = 5f;
        public const float OnionQuantity = 5f;

    }
}
