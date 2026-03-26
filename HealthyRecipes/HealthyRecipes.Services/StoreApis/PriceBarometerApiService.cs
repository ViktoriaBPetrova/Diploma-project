using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using HealthyRecipes.Services.StoreApis.Models;

namespace HealthyRecipes.Services.StoreApis
{
    public class PriceBarometerApiService : IStoreApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<PriceBarometerApiService> _logger;
        private readonly string _apiKey;

        public PriceBarometerApiService(
            HttpClient httpClient,
            IConfiguration configuration,
            ILogger<PriceBarometerApiService> logger)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            
            // Configure HttpClient base address
            _httpClient.BaseAddress = new Uri("https://prices.alexandergekov.com");
            
            // Get API key from configuration
            _apiKey = configuration["StoreApis:PriceBarometer:ApiKey"] 
                ?? throw new InvalidOperationException("PriceBarometer API key not configured");
            _logger.LogInformation("API Key loaded: {KeyPreview}",
       string.IsNullOrEmpty(_apiKey) ? "EMPTY!" : _apiKey.Substring(0, Math.Min(5, _apiKey.Length)) + "...");

            _apiKey = _apiKey ?? throw new InvalidOperationException("PriceBarometer API key not configured");
            // Set default request headers
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<IEnumerable<StoreProductDto>> CheckAvailabilityAsync(
            string ingredientName, 
            string? bgName = null,
            string? brand = null)
        {
            var results = new List<StoreProductDto>();
            
            try
            {         
                var searchUrl = $"/api/v1/products?search={Uri.EscapeDataString(bgName)}&only_valid=true&limit=20&api_key={_apiKey}";

                _logger.LogInformation("Searching Price Barometer API for: {Ingredient}", ingredientName);
                
                var response = await _httpClient.GetAsync(searchUrl);
                
                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Price Barometer API returned {StatusCode} for {Ingredient}", 
                        response.StatusCode, ingredientName);
                    return results;
                }
                
                var content = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonSerializer.Deserialize<PriceBarometerResponse>(content, 
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                if (apiResponse?.Data == null || !apiResponse.Data.Any())
                {
                    _logger.LogInformation("No products found for {Ingredient}", ingredientName);
                    return results;
                }
                
                // Convert to our DTOs (take top 10 results)
                foreach (var product in apiResponse.Data.Take(10))
                {
                    // Skip products without price
                    if (!product.PriceLev.HasValue)
                        continue;
                    
                    results.Add(new StoreProductDto
                    {
                        StoreName = MapStoreName(product.Supermarket?.Name),
                        StoreLocation = "Bulgaria",
                        ProductName = product.Name ?? ingredientName,
                        Brand = null, // API doesn't provide brand info
                        InStock = true, // Products in current brochures are typically in stock
                        Price = product.PriceLev.Value,
                        Currency = "BGN",
                        QuantityInGrams = ParseQuantity(product.Quantity),
                        ProductUrl = $"https://prices.alexandergekov.com/products/{product.Id}",
                        ImageUrl = product.ImageUrl,
                        LastUpdated = ParseBrochureDate(product.Brochure?.ValidUntil) ?? DateTime.UtcNow,
                        IsMockData = false
                    });
                }
                
                _logger.LogInformation("Found {Count} products from Price Barometer for {Ingredient}", 
                    results.Count, ingredientName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calling Price Barometer API for {Ingredient}", ingredientName);
            }
            
            return results.OrderBy(p => p.PricePer100g);
        }

        public async Task<StoreProductDto?> GetCheapestOptionAsync(
            string ingredientName, 
            string? brand = null)
        {
            var products = await CheckAvailabilityAsync(ingredientName, brand);
            return products.OrderBy(p => p.PricePer100g).FirstOrDefault();
        }

        public async Task<bool> IsInStockAsync(
            string storeName, 
            string ingredientName, 
            string? brand = null)
        {
            var products = await CheckAvailabilityAsync(ingredientName, brand);
            return products.Any(p => p.StoreName == storeName && p.InStock);
        }

        private string MapStoreName(string? apiStoreName)
        {
            if (string.IsNullOrEmpty(apiStoreName))
                return "Unknown";
            
            return apiStoreName.ToLower() switch
            {
                "lidl" => "Lidl",
                "kaufland" => "Kaufland",
                "billa" => "Billa",
                "fantastico" => "Fantastico",
                _ => apiStoreName
            };
        }

        private int ParseQuantity(string? quantity)
        {
            if (string.IsNullOrEmpty(quantity))
                return 500; // Default 500g
            
            quantity = quantity.ToLower().Trim();
            
            // Extract number
            var numberPart = new string(quantity.TakeWhile(c => char.IsDigit(c) || c == '.' || c == ',').ToArray());
            
            if (string.IsNullOrEmpty(numberPart))
                return 500;
            
            if (!decimal.TryParse(numberPart.Replace(',', '.'), out var value))
                return 500;
            
            // Check for unit
            if (quantity.Contains("kg"))
                return (int)(value * 1000);
            
            if (quantity.Contains("l") || quantity.Contains("л"))
                return (int)(value * 1000); // Assume 1L = 1000g for liquids
            
            if (quantity.Contains("ml") || quantity.Contains("мл"))
                return (int)value;
            
            if (quantity.Contains("g") || quantity.Contains("г"))
                return (int)value;
            
            // Default to grams
            return (int)value;
        }

        private DateTime? ParseBrochureDate(string? dateString)
        {
            if (string.IsNullOrEmpty(dateString))
                return null;
            
            if (DateTime.TryParse(dateString, out var date))
                return date;
            
            return null;
        }

       

    }



    // Response models matching the API spec
    public class PriceBarometerResponse
    {
        [JsonPropertyName("data")]
        public List<PriceBarometerProduct> Data { get; set; } = new();
        
        [JsonPropertyName("meta")]
        public PaginationMeta? Meta { get; set; }
    }

    public class PriceBarometerProduct
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("description")]
        public string? Description { get; set; }
        
        [JsonPropertyName("price_lev")]
        public decimal? PriceLev { get; set; }
        
        [JsonPropertyName("price_eur")]
        public decimal? PriceEur { get; set; }
        
        [JsonPropertyName("old_price_lev")]
        public decimal? OldPriceLev { get; set; }
        
        [JsonPropertyName("discount")]
        public string? Discount { get; set; }
        
        [JsonPropertyName("quantity")]
        public string? Quantity { get; set; }
        
        [JsonPropertyName("category")]
        public string? Category { get; set; }
        
        [JsonPropertyName("image_url")]
        public string? ImageUrl { get; set; }
        
        [JsonPropertyName("brochure")]
        public BrochureInfo? Brochure { get; set; }
        
        [JsonPropertyName("supermarket")]
        public SupermarketInfo? Supermarket { get; set; }
    }

    public class BrochureInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("code")]
        public string? Code { get; set; }
        
        [JsonPropertyName("valid_from")]
        public string? ValidFrom { get; set; }
        
        [JsonPropertyName("valid_until")]
        public string? ValidUntil { get; set; }
    }

    public class SupermarketInfo
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        
        [JsonPropertyName("slug")]
        public string? Slug { get; set; }
        
        [JsonPropertyName("logo")]
        public string? Logo { get; set; }
    }

    public class PaginationMeta
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }
        
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        
        [JsonPropertyName("total")]
        public int Total { get; set; }
        
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }
    }
}
