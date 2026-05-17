using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Services.RecipeMeals;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.IngredientMeals
{
    public class IngredientMealService : IIngredientMeal
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<IngredientMealService> _logger;

        // Conversion constants (approximate values for typical cooking ingredients)
        private const float GRAMS_PER_TEASPOON = 5f;
        private const float GRAMS_PER_TABLESPOON = 15f;
        private const float GRAMS_PER_CUP = 240f;
        private const float GRAMS_PER_COFFEE_CUP = 150f;
        private const float GRAMS_PER_MILLILITRE = 1f;

        public IngredientMealService(HealthyRecipesDbContext context, ILogger<IngredientMealService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task AddIngredientToMealAsync(Guid ingredientId, Guid mealId, float quantity, string unit)
        {
            try
            {
                var existing = await _context.IngredientMeals
                    .FirstOrDefaultAsync(im => im.IngredientId == ingredientId && im.MealId == mealId);

                var normalizedUnit = NormalizeUnit(unit);
                var quantityInGrams = ConvertToGrams(quantity, normalizedUnit);

                if (existing != null)
                {
                    if (existing.Deleted)
                    {
                        existing.Deleted = false;
                        existing.DeletedAt = null;
                        existing.UpdatedAt = DateTime.UtcNow;
                        existing.QuantityInGrams = quantityInGrams;
                        existing.OriginalUnit = normalizedUnit;
                        UpdateQuantityFields(existing, quantity, normalizedUnit);
                        await _context.SaveChangesAsync();
                    }
                    return;
                }
                else
                {
                    var newIngredient = new IngredientMeal
                    {
                        MealId = mealId,
                        IngredientId = ingredientId,
                        QuantityInGrams = quantityInGrams,
                        OriginalUnit = normalizedUnit
                    };
                    UpdateQuantityFields(newIngredient, quantity, normalizedUnit);
                    await _context.IngredientMeals.AddAsync(newIngredient);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} added to meal {MealId} with {Quantity} {Unit}",
                    ingredientId, mealId, quantity, unit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding ingredient to meal");
                throw;
            }
        }

        public async Task<IEnumerable<IngredientMeal>> GetIngredientsByMealAsync(Guid mealId)
        {
            try
            {
                return await _context.IngredientMeals
                    .Include(im => im.Ingredient)
                    .Where(rm => rm.MealId == mealId && !rm.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredient for meal: {MealId}", mealId);
                throw;
            }
        }

        public async Task<bool> RemoveIngredientFromMealAsync(Guid ingredientId, Guid mealId)
        {
            try
            {
                var existing = await _context.IngredientMeals
                    .FirstOrDefaultAsync(im => im.IngredientId == ingredientId && im.MealId == mealId && !im.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} removed from meal {MealId}", ingredientId, mealId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing ingredient from meal");
                throw;
            }
        }

        public async Task<bool> UpdateQuantityAsync(Guid mealId, Guid ingredientId, float quantity, string unit)
        {
            try
            {
                var existing = await _context.IngredientMeals
                    .FirstOrDefaultAsync(im => im.MealId == mealId && im.IngredientId == ingredientId && !im.Deleted);

                if (existing == null) return false;

                var normalizedUnit = NormalizeUnit(unit);
                existing.QuantityInGrams = ConvertToGrams(quantity, normalizedUnit);
                existing.OriginalUnit = normalizedUnit;
                UpdateQuantityFields(existing, quantity, normalizedUnit);
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Quantity updated for ingredient {IngredientId} in meal {MealId}", ingredientId, mealId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient quantity");
                throw;
            }
        }

        private void UpdateQuantityFields(IngredientMeal ingredientMeal, float quantity, string unit)
        {
            // Clear all measurement fields first
            ingredientMeal.QuantityInTeaspoons = null;
            ingredientMeal.QuantityInTablespoons = null;
            ingredientMeal.QuantityInCups = null;
            ingredientMeal.QuantityInCoffeeCups = null;
            ingredientMeal.QuantityInMillilitres = null;

            // Set the original unit value
            switch (unit.ToLower())
            {
                case "teaspoons":
                    ingredientMeal.QuantityInTeaspoons = quantity;
                    break;
                case "tablespoons":
                    ingredientMeal.QuantityInTablespoons = quantity;
                    break;
                case "cups":
                    ingredientMeal.QuantityInCups = quantity;
                    break;
                case "coffeecups":
                    ingredientMeal.QuantityInCoffeeCups = quantity;
                    break;
                case "millilitres":
                    ingredientMeal.QuantityInMillilitres = quantity;
                    break;
            }
        }

        public float ConvertToGrams(float quantity, string unit)
        {
            try
            {
                return unit?.ToLower() switch
                {
                    "teaspoons" or "tsp" => quantity * GRAMS_PER_TEASPOON,
                    "tablespoons" or "tbsp" => quantity * GRAMS_PER_TABLESPOON,
                    "cups" or "cup" => quantity * GRAMS_PER_CUP,
                    "coffeecups" or "coffeecup" => quantity * GRAMS_PER_COFFEE_CUP,
                    "millilitres" or "ml" => quantity * GRAMS_PER_MILLILITRE,
                    "grams" or "g" or _ => quantity
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting {Quantity} {Unit} to grams", quantity, unit);
                return quantity;
            }
        }

        public float ConvertFromGrams(float grams, string unit)
        {
            try
            {
                return unit?.ToLower() switch
                {
                    "teaspoons" or "tsp" => grams / GRAMS_PER_TEASPOON,
                    "tablespoons" or "tbsp" => grams / GRAMS_PER_TABLESPOON,
                    "cups" or "cup" => grams / GRAMS_PER_CUP,
                    "coffeecups" or "coffeecup" => grams / GRAMS_PER_COFFEE_CUP,
                    "millilitres" or "ml" => grams / GRAMS_PER_MILLILITRE,
                    "grams" or "g" or _ => grams
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error converting {Grams}g to {Unit}", grams, unit);
                return grams;
            }
        }

        public string FormatQuantity(float? quantity, string? unit)
        {
            if (!quantity.HasValue)
                return "0g";

            try
            {
                return unit?.ToLower() switch
                {
                    "teaspoons" or "tsp" => $"{quantity.Value:F1} tsp",
                    "tablespoons" or "tbsp" => $"{quantity.Value:F1} tbsp",
                    "cups" or "cup" => $"{quantity.Value:F2} cups",
                    "coffeecups" or "coffeecup" => $"{quantity.Value:F2} coffee cups",
                    "millilitres" or "ml" => $"{quantity.Value:F0} ml",
                    _ => $"{quantity.Value:F1}g"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error formatting quantity {Quantity} {Unit}", quantity, unit);
                return $"{quantity.Value:F1}g";
            }
        }

        private string NormalizeUnit(string unit)
        {
            return unit?.ToLower() switch
            {
                "tsp" or "teaspoon" => "teaspoons",
                "tbsp" or "tablespoon" => "tablespoons",
                "cup" => "cups",
                "coffeecup" or "coffee cup" => "coffeecups",
                "ml" or "millilitre" => "millilitres",
                "g" or "gram" => "grams",
                _ => unit?.ToLower() ?? "grams"
            };
        }
    }
}
