using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.RecipeIngredients
{
    public class RecipeIngredientService : IRecipeIngredient
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeIngredientService> _logger;

        // Conversion constants (approximate values for typical cooking ingredients)
        private const float GRAMS_PER_TEASPOON = 5f;
        private const float GRAMS_PER_TABLESPOON = 15f;
        private const float GRAMS_PER_CUP = 240f;
        private const float GRAMS_PER_COFFEE_CUP = 150f;
        private const float GRAMS_PER_MILLILITRE = 1f;

        public RecipeIngredientService(HealthyRecipesDbContext context, ILogger<RecipeIngredientService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddIngredientToRecipeAsync(Guid recipeId, Guid ingredientId, float quantity, string unit)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId);

                var normalizedUnit = NormalizeUnit(unit);
                var quantityInGrams = ConvertToGrams(quantity, normalizedUnit);

                if (existing != null)
                {
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.QuantityInGrams = quantityInGrams;
                    existing.OriginalUnit = normalizedUnit;
                    UpdateQuantityFields(existing, quantity, normalizedUnit);
                    existing.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    var newIngredient = new RecipeIngredient
                    {
                        RecipeId = recipeId,
                        IngredientId = ingredientId,
                        QuantityInGrams = quantityInGrams,
                        OriginalUnit = normalizedUnit
                    };
                    UpdateQuantityFields(newIngredient, quantity, normalizedUnit);
                    await _context.RecipeIngredients.AddAsync(newIngredient);
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} added to recipe {RecipeId} with {Quantity} {Unit}",
                    ingredientId, recipeId, quantity, unit);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding ingredient to recipe");
                throw;
            }
        }

        public async Task<bool> UpdateQuantityAsync(Guid recipeId, Guid ingredientId, float quantity, string unit)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

                if (existing == null) return false;

                var normalizedUnit = NormalizeUnit(unit);
                existing.QuantityInGrams = ConvertToGrams(quantity, normalizedUnit);
                existing.OriginalUnit = normalizedUnit;
                UpdateQuantityFields(existing, quantity, normalizedUnit);
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Quantity updated for ingredient {IngredientId} in recipe {RecipeId}", ingredientId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating ingredient quantity");
                throw;
            }
        }

        private void UpdateQuantityFields(RecipeIngredient recipeIngredient, float quantity, string unit)
        {
            // Clear all measurement fields first
            recipeIngredient.QuantityInTeaspoons = null;
            recipeIngredient.QuantityInTablespoons = null;
            recipeIngredient.QuantityInCups = null;
            recipeIngredient.QuantityInCoffeeCups = null;
            recipeIngredient.QuantityInMillilitres = null;

            // Set the original unit value
            switch (unit.ToLower())
            {
                case "teaspoons":
                    recipeIngredient.QuantityInTeaspoons = quantity;
                    break;
                case "tablespoons":
                    recipeIngredient.QuantityInTablespoons = quantity;
                    break;
                case "cups":
                    recipeIngredient.QuantityInCups = quantity;
                    break;
                case "coffeecups":
                    recipeIngredient.QuantityInCoffeeCups = quantity;
                    break;
                case "millilitres":
                    recipeIngredient.QuantityInMillilitres = quantity;
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

        public async Task<bool> RemoveIngredientFromRecipeAsync(Guid recipeId, Guid ingredientId)
        {
            try
            {
                var existing = await _context.RecipeIngredients
                    .FirstOrDefaultAsync(ri => ri.RecipeId == recipeId && ri.IngredientId == ingredientId && !ri.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Ingredient {IngredientId} removed from recipe {RecipeId}", ingredientId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing ingredient from recipe");
                throw;
            }
        }

        public async Task<IEnumerable<RecipeIngredient>> GetIngredientsByRecipeAsync(Guid recipeId)
        {
            try
            {
                return await _context.RecipeIngredients
                    .Include(ri => ri.Ingredient)
                    .Where(ri => ri.RecipeId == recipeId && !ri.Deleted)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ingredients for recipe: {RecipeId}", recipeId);
                throw;
            }
        }
    }
}