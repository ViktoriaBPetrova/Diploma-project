using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Users;
using HealthyRecipes.Web.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUser _userService;
        private readonly IAllergy _allergyService;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUser userService, IAllergy allergyService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _allergyService = allergyService;
            _userManager = userManager;
        }

        // GET: /User/Profile/{id?}
        public async Task<IActionResult> Profile(Guid? id)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var profileId = id ?? currentUser!.Id;
            var user = await _userService.GetUserByIdAsync(profileId);
            if (user == null) return NotFound();

            var allergies = await _allergyService.GetAllergiesByUserAsync(profileId);

            var vm = new UserProfileViewModel
            {
                Id = user.Id,
                UserName = user.UserName ?? "",
                FirstName = user.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ImageUrl = user.ImageUrl,
                Height = user.Height,
                Weight = user.Weight,
                ProteinGoal = user.ProteinGoal,
                CarbsGoal = user.CarbsGoal,
                FatGoal = user.FatGoal,
                CalorieGoal = user.Calories,
                RecipeCount = user.CreatedRecipes?.Count() ?? 0,
                MealPlanCount = user.CreatedMealPlans?.Count() ?? 0,
                IsCurrentUser = profileId == currentUser!.Id,
                Allergies = allergies.Select(a => new AllergyViewModel
                {
                    IngredientId = a.IngredientId,
                    IngredientName = a.Ingredient?.Name ?? ""
                })
            };

            return View(vm);
        }

        // GET: /User/Edit
        public async Task<IActionResult> Edit()
        {
            var user = await _userManager.GetUserAsync(User);
            var vm = new EditProfileViewModel
            {
                FirstName = user!.FirstName,
                LastName = user.LastName,
                Bio = user.Bio,
                ImageUrl = user.ImageUrl,
                Height = user.Height,
                Weight = user.Weight,
                ProteinGoal = user.ProteinGoal,
                CarbsGoal = user.CarbsGoal,
                FatGoal = user.FatGoal,
                CalorieGoal = user.Calories
            };
            return View(vm);
        }

        // POST: /User/Edit
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditProfileViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userManager.GetUserAsync(User);
            user!.FirstName = vm.FirstName;
            user.LastName = vm.LastName;
            user.Bio = vm.Bio;
            user.ImageUrl = vm.ImageUrl;
            user.Height = vm.Height;
            user.Weight = vm.Weight;
            user.ProteinGoal = vm.ProteinGoal;
            user.CarbsGoal = vm.CarbsGoal;
            user.FatGoal = vm.FatGoal;
            user.Calories = vm.CalorieGoal;

            await _userService.UpdateUserAsync(user);
            return RedirectToAction(nameof(Profile));
        }

        // POST: /User/RemoveAllergy
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveAllergy(Guid ingredientId)
        {
            var user = await _userManager.GetUserAsync(User);
            await _allergyService.RemoveAllergyAsync(user!.Id, ingredientId);
            return RedirectToAction(nameof(Profile));
        }
    }
}
