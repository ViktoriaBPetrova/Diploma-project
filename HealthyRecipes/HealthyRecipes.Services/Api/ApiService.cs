using HealthyRecipes.Services.Api.Models;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace HealthyRecipes.Services.Api
{
    public class ApiService : IApi
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ApiResponse?> GetProductByBarcodeAsync(string barcode)
        {
            try
            {
                _logger.LogInformation("Fetching product by barcode: {Barcode}", barcode);

                var response = await _httpClient.GetAsync(
                    $"api/v2/product/{barcode}.json"
                );

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("API returned status {StatusCode} for barcode {Barcode}",
                        response.StatusCode, barcode);
                    return null;
                }

                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                return result;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP error fetching product by barcode {Barcode}: {Message}",
                    barcode, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error fetching product by barcode {Barcode}", barcode);
                return null;
            }
        }

        public async Task<SearchResponse?> SearchProductsAsync(string searchTerm, int page = 1)
        {
            try
            {
                var fields = "product_name,brands,nutriments,code";
                var endpoint = $"cgi/search.pl?search_terms={Uri.EscapeDataString(searchTerm)}&page={page}&page_size={5}&json=true&fields={fields}";
                var response = await _httpClient.GetAsync(
                    endpoint
                    /*$"cgi/search.pl?search_terms={Uri.EscapeDataString(searchTerm)}&page={page}&json=true"*/
                );

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("API returned status {StatusCode} for search term '{SearchTerm}'. Response: {Reason}",
                        response.StatusCode, searchTerm, response.ReasonPhrase);
                    
                    
                    return null;
                }

                var result = await response.Content.ReadFromJsonAsync<SearchResponse>();
                _logger.LogInformation("Found {Count} products for '{SearchTerm}'",
                    result?.Products?.Count ?? 0, searchTerm);

                return result;
            }
            catch (HttpRequestException ex)
            {
                _logger.LogError(ex, "HTTP error searching products with term '{SearchTerm}': {Message}",
                    searchTerm, ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unexpected error searching products with term '{SearchTerm}'", searchTerm);
                return null;
            }
        }
    }
}