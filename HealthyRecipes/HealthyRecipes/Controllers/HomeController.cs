using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.RecipeCategories;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.SavedRecipes;
using HealthyRecipes.Web.ViewModels.Recipe;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRecipe _recipeService;
        private readonly ICategory _categoryService;
        private readonly IRecipeCategory _recipeCategoryService;
        private readonly ICommentRating _commentRatingService;
        private readonly ISavedRecipe _savedRecipeService;
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
            IRecipe recipeService,
            ICategory categoryService,
            IRecipeCategory recipeCategoryService,
            ICommentRating commentRatingService,
            ISavedRecipe savedRecipeService,
            UserManager<ApplicationUser> userManager)
        {
            _recipeService = recipeService;
            _categoryService = categoryService;
            _recipeCategoryService = recipeCategoryService;
            _commentRatingService = commentRatingService;
            _savedRecipeService = savedRecipeService;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var allRecipes = await _recipeService.GetAllRecipesAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();

            HashSet<Guid> savedIds = new();
            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var saved = await _savedRecipeService.GetSavedRecipesByUserAsync(user.Id);
                    savedIds = saved.Select(sr => sr.RecipeId).ToHashSet();
                }
            }

            var featured = allRecipes.Take(6).ToList();
            var cards = new List<RecipeCardViewModel>();
            foreach (var r in featured)
            {
                var avg = await _commentRatingService.GetAverageRatingAsync(r.Id);
                var recipeCategories = await _recipeCategoryService.GetCategoriesByRecipeAsync(r.Id);
                cards.Add(new RecipeCardViewModel
                {
                    Id = r.Id,
                    Title = r.Title,
                    Info = r.Info,
                    Calories = r.Calories,
                    Protein = r.Protein,
                    Carbs = r.Carbs,
                    Fat = r.Fat,
                    PrepTime = r.PrepTime,
                    Difficulty = r.Difficulty,
                    ImageUrl = r.ImageUrl,
                    AverageRating = avg,
                    CategoryNames = recipeCategories.Select(rc => rc.Category?.Name ?? "").Where(n => n != ""),
                    IsSaved = savedIds.Contains(r.Id),
                    AuthorName = r.User?.UserName ?? "Unknown"
                });
            }

            ViewBag.FeaturedRecipes = cards;
            ViewBag.Categories = categories.Take(5).Select(c => new CategoryFilterViewModel { Id = c.Id, Name = c.Name });

            return View();
        }

        public IActionResult Privacy() => View();

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() => View();
    }
}
