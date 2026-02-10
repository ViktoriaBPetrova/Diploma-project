using HealthyRecipes.Services.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Services.Api
{
    public class ApiService : IApi
    {
            private readonly HttpClient _httpClient;

            public ApiService(HttpClient httpClient)
            {
                _httpClient = httpClient;
                
            }

            public async Task<ApiResponse> GetProductByBarcodeAsync(string barcode)
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<ApiResponse>(
                        $"api/v2/product/{barcode}.json"
                    );
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    // Handle error
                    Console.WriteLine($"Error fetching product: {ex.Message}");
                    return null;
                }
            }

            public async Task<SearchResponse> SearchProductsAsync(string searchTerm, int page = 1)
            {
                try
                {
                    var response = await _httpClient.GetFromJsonAsync<SearchResponse>(
                        $"cgi/search.pl?search_terms={Uri.EscapeDataString(searchTerm)}&page={page}&json=true"
                    );
                    return response;
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error searching products: {ex.Message}");
                    return null;
                }
            }
        

        public class SearchResponse
        {
            public int Count { get; set; }
            public int Page { get; set; }
            public List<Product> Products { get; set; }
        }
    }
}
