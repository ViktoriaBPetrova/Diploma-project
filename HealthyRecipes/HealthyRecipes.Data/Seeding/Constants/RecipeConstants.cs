using HealthyRecipes.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Seeding.Constants
{
    public class RecipeConstants
    {
        // ---------- Chicken & Rice Bowl ----------
        public const string ChickenRiceBowlId = "f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101";

        public const string ChickenRiceBowlInfo =
            "A healthy and high-protein chicken and rice bowl with sautéed onion and garlic. " +
            "Perfect for meal prep and quick lunches.";

        /*
        // Total nutritional values (calculated for the whole recipe)
        public const float ChickenRiceBowlCalories = 650f;
        public const float ChickenRiceBowlProtein = 48f;
        public const float ChickenRiceBowlCarbs = 62f;
        public const float ChickenRiceBowlFat = 18f;*/

        public const int ChickenRiceBowlPrepTime = 30;
        public const Difficulty ChickenRiceBowlDifficulty = Difficulty.Easy;

    }
}
