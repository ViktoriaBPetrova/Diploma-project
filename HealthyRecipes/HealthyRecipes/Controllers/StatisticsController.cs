using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Statistics;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Web.ViewModels.Statistics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly IRecipeStatistics _recipeStatisticsService;
        private readonly IMealPlanStatistics _mealPlanStatisticsService;
        private readonly IUserStatistics _userStatisticsService;
        private readonly UserManager<ApplicationUser> _userManager;

        public StatisticsController(
            IRecipeStatistics recipeStatisticsService,
            IMealPlanStatistics mealPlanStatisticsService,
            IUserStatistics userStatisticsService,
            UserManager<ApplicationUser> userManager)
        {
            _recipeStatisticsService = recipeStatisticsService;
            _mealPlanStatisticsService = mealPlanStatisticsService;
            _userStatisticsService = userStatisticsService;
            _userManager = userManager;
        }

        // GET: /Statistics/Recipe/{id}
        public async Task<IActionResult> Recipe(Guid id)
        {
            try
            {
                var statsDto = await _recipeStatisticsService.GetRecipeStatisticsAsync(id);
                
                if (statsDto == null)
                {
                    return NotFound();
                }

                var viewModel = new RecipeStatisticsViewModel
                {
                    RecipeId = statsDto.RecipeId,
                    RecipeTitle = statsDto.RecipeTitle,
                    SaveCount = statsDto.SaveCount,
                    CommentCount = statsDto.CommentCount,
                    AverageRating = statsDto.AverageRating,
                    RatingCount = statsDto.RatingCount,
                    MealPlanUsageCount = statsDto.MealPlanUsageCount
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while loading recipe statistics.";
                return RedirectToAction("Details", "Recipe", new { id });
            }
        }

        // GET: /Statistics/MealPlan/{id}
        public async Task<IActionResult> MealPlan(Guid id)
        {
            try
            {
                var statsDto = await _mealPlanStatisticsService.GetMealPlanStatisticsAsync(id);
                
                if (statsDto == null)
                {
                    return NotFound();
                }

                var viewModel = new MealPlanStatisticsViewModel
                {
                    MealPlanId = statsDto.MealPlanId,
                    MealPlanName = statsDto.MealPlanName,
                    SaveCount = statsDto.SaveCount,
                    ActiveFollowerCount = statsDto.ActiveFollowerCount,
                    CompletionRate = statsDto.CompletionRate
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while loading meal plan statistics.";
                return RedirectToAction("Details", "MealPlan", new { id });
            }
        }

        // GET: /Statistics/Dashboard
        public async Task<IActionResult> Dashboard()
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                
                if (user == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                var statsDto = await _userStatisticsService.GetUserStatisticsAsync(user.Id);
                
                if (statsDto == null)
                {
                    TempData["Error"] = "Unable to load user statistics.";
                    return RedirectToAction("Index", "Home");
                }

                var viewModel = new UserStatisticsViewModel
                {
                    UserId = statsDto.UserId,
                    UserName = statsDto.UserName,
                    RecipesCreatedCount = statsDto.RecipesCreatedCount,
                    MealPlansCreatedCount = statsDto.MealPlansCreatedCount,
                    IngredientsCreatedCount = statsDto.IngredientsCreatedCount,
                    CategoriesCreatedCount = statsDto.CategoriesCreatedCount,
                    TotalRecipeSaves = statsDto.TotalRecipeSaves,
                    TotalMealPlanSaves = statsDto.TotalMealPlanSaves,
                    TotalCommentsReceived = statsDto.TotalCommentsReceived,
                    AverageRecipeRating = statsDto.AverageRecipeRating,
                    MostPopularRecipeId = statsDto.MostPopularRecipeId,
                    MostPopularRecipeTitle = statsDto.MostPopularRecipeTitle,
                    MostPopularRecipeSaveCount = statsDto.MostPopularRecipeSaveCount,
                    MostPopularMealPlanId = statsDto.MostPopularMealPlanId,
                    MostPopularMealPlanName = statsDto.MostPopularMealPlanName,
                    MostPopularMealPlanSaveCount = statsDto.MostPopularMealPlanSaveCount
                };

                return View(viewModel);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while loading your dashboard.";
                return RedirectToAction("Index", "Home");
            }
        }

        // API endpoint for partial view - can be used in recipe details page
        // GET: /Statistics/RecipeStatsPartial/{id}
        public async Task<IActionResult> RecipeStatsPartial(Guid id)
        {
            try
            {
                var statsDto = await _recipeStatisticsService.GetRecipeStatisticsAsync(id);
                
                if (statsDto == null)
                {
                    return PartialView("_RecipeStatsPartial", null);
                }

                var viewModel = new RecipeStatisticsViewModel
                {
                    RecipeId = statsDto.RecipeId,
                    RecipeTitle = statsDto.RecipeTitle,
                    SaveCount = statsDto.SaveCount,
                    CommentCount = statsDto.CommentCount,
                    AverageRating = statsDto.AverageRating,
                    RatingCount = statsDto.RatingCount,
                    MealPlanUsageCount = statsDto.MealPlanUsageCount
                };

                return PartialView("_RecipeStatsPartial", viewModel);
            }
            catch (Exception ex)
            {
                return PartialView("_RecipeStatsPartial", null);
            }
        }

        // API endpoint for partial view - can be used in meal plan details page
        // GET: /Statistics/MealPlanStatsPartial/{id}
        public async Task<IActionResult> MealPlanStatsPartial(Guid id)
        {
            try
            {
                var statsDto = await _mealPlanStatisticsService.GetMealPlanStatisticsAsync(id);
                
                if (statsDto == null)
                {
                    return PartialView("_MealPlanStatsPartial", null);
                }

                var viewModel = new MealPlanStatisticsViewModel
                {
                    MealPlanId = statsDto.MealPlanId,
                    MealPlanName = statsDto.MealPlanName,
                    SaveCount = statsDto.SaveCount,
                    ActiveFollowerCount = statsDto.ActiveFollowerCount,
                    CompletionRate = statsDto.CompletionRate
                };

                return PartialView("_MealPlanStatsPartial", viewModel);
            }
            catch (Exception ex)
            {
                return PartialView("_MealPlanStatsPartial", null);
            }
        }
    }
}
