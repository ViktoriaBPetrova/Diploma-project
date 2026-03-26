using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.GroceryLists.Models;
using HealthyRecipes.Services.StoreApis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using HealthyRecipes.Services.StoreApis.Models;

namespace HealthyRecipes.Services.GroceryLists
{
    public class GroceryListService : IGroceryList
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly IStoreApi _storeApi;
        private readonly ILogger<GroceryListService> _logger;

        public GroceryListService(
            HealthyRecipesDbContext context, 
            IStoreApi storeApi,
            ILogger<GroceryListService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _storeApi = storeApi ?? throw new ArgumentNullException(nameof(storeApi));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GroceryListDto> GenerateGroceryListForMealPlanAsync(Guid mealPlanId)
        {
            try
            {
                var mealPlan = await _context.MealPlans
                    .Include(mp => mp.MealPlanDays)
                        .ThenInclude(d => d.Meals)
                            .ThenInclude(m => m.RecipeMeals)
                                .ThenInclude(rm => rm.Recipe)
                                    .ThenInclude(r => r.RecipeIngredients)
                                        .ThenInclude(ri => ri.Ingredient)
                    .FirstOrDefaultAsync(mp => mp.Id == mealPlanId && !mp.Deleted);

                if (mealPlan == null)
                {
                    _logger.LogWarning("MealPlan with ID {MealPlanId} not found", mealPlanId);
                    return new GroceryListDto { MealPlanId = mealPlanId, Items = new List<GroceryItemDto>() };
                }

                // Dictionary to aggregate ingredients: Key = IngredientId, Value = Total quantity in grams
                var ingredientAggregation = new Dictionary<Guid, (Ingredient ingredient, float totalGrams)>();

                // Iterate through all days -> meals -> recipes -> ingredients
                foreach (var day in mealPlan.MealPlanDays.Where(d => !d.Deleted))
                {
                    foreach (var meal in day.Meals.Where(m => !m.Deleted))
                    {
                        foreach (var recipeMeal in meal.RecipeMeals.Where(rm => !rm.Deleted && rm.Recipe != null))
                        {
                            foreach (var recipeIngredient in recipeMeal.Recipe.RecipeIngredients.Where(ri => !ri.Deleted))
                            {
                                var ingredientId = recipeIngredient.IngredientId;
                                var quantity = recipeIngredient.QuantityInGrams;

                                if (ingredientAggregation.ContainsKey(ingredientId))
                                {
                                    ingredientAggregation[ingredientId] = (
                                        ingredientAggregation[ingredientId].ingredient,
                                        ingredientAggregation[ingredientId].totalGrams + quantity
                                    );
                                }
                                else
                                {
                                    ingredientAggregation[ingredientId] = (recipeIngredient.Ingredient, quantity);
                                }
                            }
                        }
                    }
                }

                // Convert to GroceryItemDto list and fetch store data
                var groceryItems = new List<GroceryItemDto>();

                foreach (var kvp in ingredientAggregation)
                {
                    var ingredient = kvp.Value.ingredient;
                    var totalGrams = kvp.Value.totalGrams;

                    // Fetch store availability and pricing
                    var storeProducts = await _storeApi.CheckAvailabilityAsync(ingredient.Name, ingredient.BulgarianName, ingredient.Brand);

                    var item = new GroceryItemDto
                    {
                        IngredientId = kvp.Key,
                        IngredientName = ingredient.Name,
                       
                        Brand = ingredient.Brand,
                        QuantityInGrams = totalGrams,
                        Stores = storeProducts.Select(sp => new StoreAvailabilityDto
                        {
                            StoreName = sp.StoreName,
                            StoreLocation = sp.StoreLocation,
                            InStock = sp.InStock,
                            Price = sp.Price,
                            Currency = sp.Currency,
                            ProductUrl = sp.ProductUrl,
                            LastUpdated = sp.LastUpdated,
                            PricePer100g = sp.PricePer100g,
                            PackageQuantityInGrams = sp.QuantityInGrams,
                            ProductName = sp.ProductName,
                            ImageUrl = sp.ImageUrl,
                            StoreLogoUrl = sp.StoreLogoUrl,
                            IsMockData = sp.IsMockData
                        }).OrderBy(s => s.PricePer100g).ToList()
                    };

                    groceryItems.Add(item);
                }

                _logger.LogInformation("Generated grocery list for MealPlan {MealPlanId} with {Count} items", 
                    mealPlanId, groceryItems.Count);

                return new GroceryListDto
                {
                    MealPlanId = mealPlanId,
                    MealPlanName = mealPlan.Name,
                    GeneratedAt = DateTime.UtcNow,
                    Items = groceryItems.OrderBy(item => item.IngredientName).ToList()
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error generating grocery list for MealPlan {MealPlanId}", mealPlanId);
                throw;
            }
        }
    }
}
