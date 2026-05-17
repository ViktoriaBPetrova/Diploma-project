namespace HealthyRecipes.Web.ViewModels.MealPlan
{
    public class IngredientMealViewModel
    {
        public Guid IngredientId { get; set; }
        public string IngredientName { get; set; } = null!;
        public float QuantityInGrams { get; set; }
        public float Calories => CaloriesPer100g * QuantityInGrams / 100f;
        public float Protein => ProteinPer100g * QuantityInGrams / 100f;
        public float Carbs => CarbsPer100g * QuantityInGrams / 100f;
        public float Fat => FatPer100g * QuantityInGrams / 100f;
        public float CaloriesPer100g { get; set; }
        public float ProteinPer100g { get; set; }
        public float CarbsPer100g { get; set; }
        public float FatPer100g { get; set; }

        public bool IsAllergen { get; set; }

        // Display the quantity in the original unit if available
        public string? OriginalUnit { get; set; }
        public float? QuantityInTeaspoons { get; set; }
        public float? QuantityInTablespoons { get; set; }
        public float? QuantityInCups { get; set; }
        public float? QuantityInCoffeeCups { get; set; }
        public float? QuantityInMillilitres { get; set; }

        // Helper property to get formatted display quantity
        public string FormattedQuantity
        {
            get
            {
                if (string.IsNullOrEmpty(OriginalUnit))
                    return $"{QuantityInGrams:F1}g";

                return OriginalUnit.ToLower() switch
                {
                    "teaspoons" => $"{QuantityInTeaspoons:F1} tsp",
                    "tablespoons" => $"{QuantityInTablespoons:F1} tbsp",
                    "cups" => $"{QuantityInCups:F2} cups",
                    "coffeecups" => $"{QuantityInCoffeeCups:F2} coffee cups",
                    "millilitres" => $"{QuantityInMillilitres:F0} ml",
                    _ => $"{QuantityInGrams:F1}g"
                };
            }
        }
    }
}
