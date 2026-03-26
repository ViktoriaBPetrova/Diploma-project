using HealthyRecipes.Services.StoreApis.Models;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.StoreApis
{
    /// <summary>
    /// Mock implementation of store API service
    /// Replace this with real API integrations for Kaufland, Billa, Lidl, etc.
    /// </summary>
    public class MockStoreApiService : IStoreApi
    {
        private readonly ILogger<MockStoreApiService> _logger;
        private readonly Random _random = new Random();

        // Bulgarian stores in Plovdiv
        private readonly List<string> _stores = new()
        {
            "Kaufland",
            "Billa",
            "Lidl",
            "Fantastico",
            "T-Market"
        };

        private readonly Dictionary<string, List<string>> _storeLocations = new()
        {
            { "Kaufland", new() { "Mall Plovdiv", "Trakia", "Kapana" } },
            { "Billa", new() { "Center", "Karshiyaka", "Stolipinovo" } },
            { "Lidl", new() { "Maritsa", "Trakia", "Komatevo" } },
            { "Fantastico", new() { "Grand Mall", "Center", "Karshiyaka" } },
            { "T-Market", new() { "Vazrazhdane", "Center", "Trakia" } }
        };

        public MockStoreApiService(ILogger<MockStoreApiService> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<IEnumerable<StoreProductDto>> CheckAvailabilityAsync(string ingredientName, string? bgName = null, string? brand = null)
        {
            await Task.Delay(100); // Simulate API call delay

            var results = new List<StoreProductDto>();

            foreach (var store in _stores)
            {
                // 80% chance the item is in stock
                bool inStock = _random.Next(100) < 80;
                
                var locations = _storeLocations[store];
                var location = locations[_random.Next(locations.Count)];

                var product = new StoreProductDto
                {
                    StoreName = store,
                    StoreLocation = location,
                    ProductName = ingredientName,
                    Brand = brand ?? GetMockBrand(ingredientName),
                    InStock = inStock,
                    Price = GeneratePrice(ingredientName, store),
                    Currency = "BGN",
                    QuantityInGrams = GetStandardPackageSize(ingredientName),
                    ProductUrl = GenerateMockUrl(store, ingredientName),
                    ImageUrl = GenerateMockImageUrl(ingredientName),
                    LastUpdated = DateTime.UtcNow.AddMinutes(-_random.Next(1, 120)),
                    IsMockData = true
                };

                results.Add(product);
            }

            _logger.LogInformation("Checked availability for {Ingredient} across {Count} stores", 
                ingredientName, results.Count);

            return results.OrderBy(p => p.Price);
        }

        public async Task<StoreProductDto?> GetCheapestOptionAsync(string ingredientName, string? brand = null)
        {
            var products = await CheckAvailabilityAsync(ingredientName, brand);
            return products
                .Where(p => p.InStock)
                .OrderBy(p => p.PricePer100g)
                .FirstOrDefault();
        }

        public async Task<bool> IsInStockAsync(string storeName, string ingredientName, string? brand = null)
        {
            var products = await CheckAvailabilityAsync(ingredientName);
            return products.Any(p => p.StoreName.Equals(storeName, StringComparison.OrdinalIgnoreCase) && p.InStock);
        }

        // Helper methods for realistic mock data
        private decimal GeneratePrice(string ingredient, string store)
        {
            var basePrice = ingredient.ToLower() switch
            {
                var i when i.Contains("chicken") => 8.50m,
                var i when i.Contains("beef") => 12.00m,
                var i when i.Contains("rice") => 3.20m,
                var i when i.Contains("quinoa") => 7.80m,
                var i when i.Contains("pasta") => 2.50m,
                var i when i.Contains("olive oil") => 6.50m,
                var i when i.Contains("tomato") => 2.80m,
                var i when i.Contains("onion") => 1.50m,
                var i when i.Contains("garlic") => 2.20m,
                var i when i.Contains("cheese") => 9.00m,
                var i when i.Contains("milk") => 2.40m,
                var i when i.Contains("egg") => 4.80m,
                var i when i.Contains("bread") => 1.80m,
                var i when i.Contains("potato") => 1.20m,
                var i when i.Contains("carrot") => 1.80m,
                var i when i.Contains("bell pepper") => 3.50m,
                var i when i.Contains("cucumber") => 2.00m,
                var i when i.Contains("lettuce") => 2.50m,
                var i when i.Contains("spinach") => 3.80m,
                var i when i.Contains("broccoli") => 4.20m,
                _ => 4.00m
            };

            // Store-specific pricing (Kaufland and Lidl are typically cheaper)
            var storeMultiplier = store switch
            {
                "Kaufland" => 0.95m,
                "Lidl" => 0.93m,
                "Billa" => 1.05m,
                "Fantastico" => 1.08m,
                "T-Market" => 1.02m,
                _ => 1.00m
            };

            // Add some randomness
            var randomVariation = 1.0m + ((decimal)_random.NextDouble() * 0.2m - 0.1m);

            return Math.Round(basePrice * storeMultiplier * randomVariation, 2);
        }

        private int GetStandardPackageSize(string ingredient)
        {
            return ingredient.ToLower() switch
            {
                var i when i.Contains("chicken") || i.Contains("beef") || i.Contains("meat") => 500,
                var i when i.Contains("rice") || i.Contains("pasta") || i.Contains("quinoa") => 1000,
                var i when i.Contains("oil") => 1000,
                var i when i.Contains("cheese") => 400,
                var i when i.Contains("milk") => 1000,
                var i when i.Contains("egg") => 600, // ~10 eggs
                var i when i.Contains("bread") => 500,
                var i when i.Contains("tomato") || i.Contains("onion") || i.Contains("potato") => 1000,
                var i when i.Contains("pepper") || i.Contains("cucumber") => 500,
                var i when i.Contains("lettuce") || i.Contains("spinach") || i.Contains("broccoli") => 300,
                _ => 500
            };
        }

        private string? GetMockBrand(string ingredient)
        {
            var brands = ingredient.ToLower() switch
            {
                var i when i.Contains("milk") => new[] { "Harmony", "Olympus", "Danone" },
                var i when i.Contains("cheese") => new[] { "Harmony", "Sirene", "Boni" },
                var i when i.Contains("pasta") => new[] { "Barilla", "De Cecco", "Combino" },
                var i when i.Contains("rice") => new[] { "Uncle Ben's", "Boni", "Riso Scotti" },
                var i when i.Contains("oil") => new[] { "Olympia", "Borges", "Monini" },
                var i when i.Contains("bread") => new[] { "Dobrudja", "Hlyab&So", "Baker's" },
                _ => new[] { "Generic", "Store Brand", "Premium" }
            };

            return brands[_random.Next(brands.Length)];
        }

        private string GenerateMockUrl(string store, string ingredient)
        {
            var slug = ingredient.ToLower().Replace(" ", "-");
            return $"https://{store.ToLower()}.bg/products/{slug}";
        }

        private string? GenerateMockImageUrl(string ingredient)
        {
            // In production, this would return actual product images
            return $"/images/products/{ingredient.ToLower().Replace(" ", "-")}.jpg";
        }
    }
}
