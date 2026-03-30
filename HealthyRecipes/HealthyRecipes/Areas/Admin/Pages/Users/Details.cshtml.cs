using HealthyRecipes.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.Users;

namespace HealthyRecipes.Web.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class DetailsModel : PageModel
    {
        private readonly IUser _userService;
        private readonly IRecipe _recipeService;
        private readonly IMealPlan _mealPlanService;
        private readonly UserManager<ApplicationUser> _userManager;

        public DetailsModel(
            IUser userService,
            IRecipe recipeService,
            IMealPlan mealPlanService,
            UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _recipeService = recipeService;
            _mealPlanService = mealPlanService;
            _userManager = userManager;
        }

        public ApplicationUser User { get; set; } = null!;
        public List<string> Roles { get; set; } = new();
        public int RecipeCount { get; set; }
        public int MealPlanCount { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
                return NotFound();

            User = user;
            Roles = (await _userManager.GetRolesAsync(user)).ToList();
            RecipeCount = user.CreatedRecipes?.Count() ?? 0;
            MealPlanCount = user.CreatedMealPlans?.Count() ?? 0;

            return Page();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _userService.SoftDeleteUserAsync(id);
            return RedirectToPage("/Users/Index");
        }

        public async Task<IActionResult> OnPostRestoreAsync(Guid id)
        {
            await _userService.RestoreUserAsync(id);
            return RedirectToPage("/Users/Index");
        }
    }
}
