using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants
{
    public class IngredientConstants
    {

        // ---------- Chicken Breast ----------
        public const string ChickenBreastName = "Chicken Breast";
        public const string ChickenBreastBrand = null; // not store-branded
        public const string ChickenBreastId = "a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10";

        public const float ChickenBreastCaloriesPer100g = 120f;
        public const float ChickenBreastProteinPer100g = 22.5f;
        public const float ChickenBreastCarbsPer100g = 0f;
        public const float ChickenBreastFatPer100g = 2.6f;

        public const Source ChickenBreastSource = Source.Global;

        // ---------- White Rice(uncooked) ----------
        public const string WhiteRiceName = "White Rice";
        public const string WhiteRiceBrand = null;
        public const string WhiteRiceId = "c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01";

        public const float WhiteRiceCaloriesPer100g = 365f;
        public const float WhiteRiceProteinPer100g = 7.1f;
        public const float WhiteRiceCarbsPer100g = 80.0f;
        public const float WhiteRiceFatPer100g = 0.7f;

        public const Source WhiteRiceSource = Source.Global;


        // ---------- Olive Oil ----------
        public const string OliveOilName = "Olive Oil";
        public const string OliveOilBrand = null;
        public const string OliveOilId = "f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2";

        public const float OliveOilCaloriesPer100g = 884f;
        public const float OliveOilProteinPer100g = 0f;
        public const float OliveOilCarbsPer100g = 0f;
        public const float OliveOilFatPer100g = 100f;

        public const Source OliveOilSource = Source.Global;


        // ---------- Onion ----------
        public const string OnionName = "Onion";
        public const string OnionBrand = null;
        public const string OnionId = "7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa";

        public const float OnionCaloriesPer100g = 40f;
        public const float OnionProteinPer100g = 1.1f;
        public const float OnionCarbsPer100g = 9.3f;
        public const float OnionFatPer100g = 0.1f;

        public const Source OnionSource = Source.Global;


        // ---------- Garlic ----------
        public const string GarlicName = "Garlic";
        public const string GarlicBrand = null;
        public const string GarlicId = "b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55";

        public const float GarlicCaloriesPer100g = 149f;
        public const float GarlicProteinPer100g = 6.4f;
        public const float GarlicCarbsPer100g = 33.1f;
        public const float GarlicFatPer100g = 0.5f;

        public const Source GarlicSource = Source.Global;
    }
}
