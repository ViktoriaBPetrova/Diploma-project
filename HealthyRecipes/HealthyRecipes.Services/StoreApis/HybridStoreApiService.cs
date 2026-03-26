using HealthyRecipes.Services.StoreApis;
using HealthyRecipes.Services.StoreApis.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.StoreApis
{
    /// <summary>
    /// Hybrid service that tries real API first, falls back to mock data if unavailable
    /// </summary>
    public class HybridStoreApiService : IStoreApi
    {
        private readonly PriceBarometerApiService _realApi;
        private readonly MockStoreApiService _mockApi;
        private readonly ILogger<HybridStoreApiService> _logger;
        private readonly bool _preferRealApi;

        public HybridStoreApiService(
            PriceBarometerApiService realApi,
            MockStoreApiService mockApi,
            ILogger<HybridStoreApiService> logger,
            IConfiguration configuration)
        {
            _realApi = realApi ?? throw new ArgumentNullException(nameof(realApi));
            _mockApi = mockApi ?? throw new ArgumentNullException(nameof(mockApi));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            // Configuration option to prefer real API (default: true)
            _preferRealApi = configuration.GetValue<bool>("StoreApis:PreferRealApi", true);
        }

        public async Task<IEnumerable<StoreProductDto>> CheckAvailabilityAsync(
            string ingredientName, 
            string? bgName = null,
            string? brand = null)
        {
            if (!_preferRealApi)
            {
                _logger.LogInformation("Using mock API (configured preference)");
                return await _mockApi.CheckAvailabilityAsync(ingredientName, brand);
            }

            try
            {
                _logger.LogDebug("Attempting to use real Sofia Supermarkets API");
                var results = await _realApi.CheckAvailabilityAsync(ingredientName, bgName, brand);

                if (results.Any())
                {
                    _logger.LogInformation("Successfully fetched {Count} products from real API", results.Count());
                    return results;
                }

                // No results from real API, fall back to mock
                _logger.LogWarning("Real API returned no results, falling back to mock data");

                var allResults = new List<StoreProductDto>();
                allResults.AddRange(results);
                if (allResults.Count < 5 && allResults.Count > 0)
                {
                    var mockResults = await _mockApi.CheckAvailabilityAsync(ingredientName, brand);

                    // Only add mock stores we don't have real data for
                    foreach (var mockStore in mockResults)
                    {
                        if (!allResults.Any(r => r.StoreName == mockStore.StoreName))
                        {
                            allResults.Add(mockStore);
                        }
                    }
                    return allResults.OrderBy(p => p.PricePer100g);
                }   
                return await _mockApi.CheckAvailabilityAsync(ingredientName, brand);
            }
            catch (HttpRequestException ex)
            {
                _logger.LogWarning(ex, "Real API unavailable, using mock data");
                return await _mockApi.CheckAvailabilityAsync(ingredientName, brand);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error with real API, falling back to mock data");
                return await _mockApi.CheckAvailabilityAsync(ingredientName, brand);
            }
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
            return products.Any(p => 
                p.StoreName.Equals(storeName, StringComparison.OrdinalIgnoreCase) && 
                p.InStock);
        }
    }
}
