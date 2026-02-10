using HealthyRecipes.Services.Api;
using HealthyRecipes.Services.Api.Models;
using Microsoft.AspNetCore.Mvc;
using static HealthyRecipes.Services.Api.ApiService;

namespace HealthyRecipes.Web.Controllers
{
    public class ApiIngredientController : Controller
    {
        
            private readonly ApiService _foodService;

            public ApiIngredientController(ApiService foodService)
            {
                _foodService = foodService;
            }

            public async Task<IActionResult> Product(string barcode)
            {
                if (string.IsNullOrEmpty(barcode))
                {
                    return BadRequest("Barcode is required");
                }

                var result = await _foodService.GetProductByBarcodeAsync(barcode);

                if (result == null || result.Status == 0)
                {
                    return NotFound("Product not found");
                }

                return View(result.Product);
            }

            public async Task<IActionResult> Search(string query)
            {
                if (string.IsNullOrEmpty(query))
                {
                    return View(new SearchResponse { Products = new List<Product>() });
                }

                var results = await _foodService.SearchProductsAsync(query);
                return View(results);
            }
    }
}
