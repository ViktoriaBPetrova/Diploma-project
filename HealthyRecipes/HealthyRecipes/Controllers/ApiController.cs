using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.SavedRecipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    [Route("Api")]
    public class ApiController : Controller
    {

        private readonly IRecipe _recipeService;
        private readonly ISavedRecipe _savedRecipeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public ApiController(
            IRecipe recipeService,
            ISavedRecipe savedRecipeService,
            UserManager<ApplicationUser> userManager)
        {
            _recipeService = recipeService;
            _savedRecipeService = savedRecipeService;
            _userManager = userManager;
        }

        // GET: /Api/SearchRecipes?query=chicken&filter=mine
        [HttpGet("SearchRecipes")]
        public async Task<IActionResult> SearchRecipes([FromQuery] string query, [FromQuery] string filter = "all")
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Unauthorized();

            IEnumerable<Data.Entities.Recipe> recipes;

            switch (filter?.ToLower())
            {
                case "mine":
                    // Get only user's own recipes
                    recipes = await _recipeService.GetRecipesByUserAsync(user.Id);
                    break;

                case "saved":
                    // Get only saved recipes
                    var savedRecipes = await _savedRecipeService.GetSavedRecipesByUserAsync(user.Id);
                    recipes = savedRecipes.Select(sr => sr.Recipe).Where(r => r != null)!;
                    break;

                default: // "all"
                         // Get all recipes
                    recipes = await _recipeService.SearchRecipesAsync(query ?? "");
                    break;
            }

            // Apply search filter if query provided
            if (!string.IsNullOrWhiteSpace(query) && filter?.ToLower() != "all")
            {
                var searchLower = query.ToLower();
                recipes = recipes.Where(r => r.Info.ToLower().Contains(searchLower));
            }

            var results = recipes
                .Take(10)
                .Select(r => new
                {
                    id = r.Id,
                    name = r.Title,
                    calories = Math.Round(r.Calories, 0),
                    protein = Math.Round(r.Protein, 1),
                    carbs = Math.Round(r.Carbs, 1),
                    fat = Math.Round(r.Fat, 1)
                });

            return Ok(results);
        }

    }
}
