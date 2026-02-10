using HealthyRecipes.Services.Api;
using HealthyRecipes.Services.Ingredients;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IngredientService _ingredientService;

        public IngredientController(IngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
