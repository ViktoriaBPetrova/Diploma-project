using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.Ingredients.Models;
using HealthyRecipes.Services.SavedIngredients;
using HealthyRecipes.Web.Models.Ingredient;
using HealthyRecipes.Web.ViewModels.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredient _ingredientService;
        private readonly IAllergy _allergyService;
        private readonly ISavedIngredient _savedIngredientService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IngredientController(IIngredient ingredientService, IAllergy allergyService, ISavedIngredient savedIngredientService, UserManager<ApplicationUser> userManager)
        {
            _ingredientService = ingredientService;
            _savedIngredientService = savedIngredientService;
            _allergyService = allergyService;
            _userManager = userManager;
        }

        // GET: /Ingredient
        public async Task<IActionResult> Index([FromQuery] IngredientFilterViewModel filter)
        {
            try
            {
                Guid? currentUserId = null;
                HashSet<Guid> allergyIds = new();
                HashSet<Guid> savedIds = new();
                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        currentUserId = user?.Id;
                        var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                        var saved = await _savedIngredientService.GetSavedIngredientsByUserAsync(user.Id);
                        savedIds = saved.Select(si => si.IngredientId).ToHashSet();
                        allergyIds = allergies.Select(a => a.IngredientId).ToHashSet();
                    }
                }

                // Map ViewModel to DTO
                var filterDto = new IngredientFilterDto
                {
                    SearchTerm = filter.SearchTerm,
                    MinCalories = filter.MinCalories,
                    MaxCalories = filter.MaxCalories,
                    MinProtein = filter.MinProtein,
                    MaxProtein = filter.MaxProtein,
                    MinCarbs = filter.MinCarbs,
                    MaxCarbs = filter.MaxCarbs,
                    MinFat = filter.MinFat,
                    MaxFat = filter.MaxFat,
                    ExcludeUserAllergies = filter.ExcludeUserAllergies,
                    UserId = currentUserId,
                    SortBy = filter.SortBy,
                    SortOrder = filter.SortOrder
                };

                var (ingredients, totalCount) = await _ingredientService.GetFilteredIngredientsWithApiAsync(filterDto);

                var vm = new IngredientIndexViewModel
                {
                    SearchQuery = filter.SearchTerm,
                    Filter = filter,
                    TotalCount = totalCount,
                    Ingredients = ingredients.Select(i => new IngredientViewModel
                    {
                        Id = i.Id,
                        Name = i.Name,
                        Brand = i.Brand,
                        CaloriesPer100g = i.CaloriesPer100g,
                        ProteinPer100g = i.ProteinPer100g,
                        CarbsPer100g = i.CarbsPer100g,
                        FatPer100g = i.FatPer100g,
                        IsAllergen = allergyIds.Contains(i.Id),
                        IsSaved = savedIds.Contains(i.Id)
                    })
                };

                return View(vm);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while loading ingredients.";

                return View(new IngredientIndexViewModel
                {
                    Filter = filter ?? new IngredientFilterViewModel()
                });
            }
        }

        // GET: /Ingredient/Details/{id}
        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (ingredient == null)
                    return NotFound();

                Guid? currentUserId = null;
                bool isAllergen = false;
                bool isSaved = false;

                if (User.Identity?.IsAuthenticated == true)
                {
                    var user = await _userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        currentUserId = user.Id;
                        isAllergen = await _allergyService.HasAllergyAsync(user.Id, id);
                        isSaved = await _savedIngredientService.IsIngredientSavedAsync(user.Id, id);
                    }
                }

                var vm = new DetailsIngredientViewModel
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Brand = ingredient.Brand,
                    CaloriesPer100g = ingredient.CaloriesPer100g,
                    ProteinPer100g = ingredient.ProteinPer100g,
                    CarbsPer100g = ingredient.CarbsPer100g,
                    FatPer100g = ingredient.FatPer100g,
                    Source = ingredient.Source.ToString(),
                    CreatedAt = ingredient.CreatedAt,
                    UpdatedAt = ingredient.UpdatedAt,
                    CreatedByUserName = ingredient.User?.UserName,
                    IsCurrentUserCreator = currentUserId.HasValue && ingredient.CreatedByUserId == currentUserId.Value,
                    IsAllergen = isAllergen,
                    IsSaved = isSaved,
                    IsDeleted = ingredient.Deleted,
                    RecipeCount = ingredient.RecipeIngredients?.Count() ?? 0,
                    RecipeNames = ingredient.RecipeIngredients?
                        .Where(ri => ri.Recipe != null && !ri.Recipe.Deleted)
                        .Select(ri => ri.Recipe!.Title)
                        .Take(10) ?? new List<string>()
                };

                return View(vm);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while loading the ingredient details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: /Ingredient/Create
        [Authorize]
        public IActionResult Create() => View(new CreateIngredientViewModel());

        // POST: /Ingredient/Create
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIngredientViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userManager.GetUserAsync(User);
            var ingredient = new Ingredient
            {
                Name = vm.Name,
                Brand = vm.Brand,
                CaloriesPer100g = vm.CaloriesPer100g,
                ProteinPer100g = vm.ProteinPer100g,
                CarbsPer100g = vm.CarbsPer100g,
                FatPer100g = vm.FatPer100g,
                CreatedByUserId = user!.Id
            };

            await _ingredientService.CreateIngredientAsync(ingredient);
            TempData["Success"] = "Ingredient created successfully";
            return RedirectToAction(nameof(Details), new { id = ingredient.Id });
        }

        // GET: /Ingredient/Edit/{id}
        [Authorize]
        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (ingredient == null)
                    return NotFound();

                var user = await _userManager.GetUserAsync(User);
                if (ingredient.CreatedByUserId != user!.Id && !User.IsInRole("Admin"))
                    return Forbid();

                var vm = new EditIngredientViewModel
                {
                    Id = ingredient.Id,
                    Name = ingredient.Name,
                    Brand = ingredient.Brand,
                    CaloriesPer100g = ingredient.CaloriesPer100g,
                    ProteinPer100g = ingredient.ProteinPer100g,
                    CarbsPer100g = ingredient.CarbsPer100g,
                    FatPer100g = ingredient.FatPer100g
                };

                return View(vm);
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while loading the ingredient for editing.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Ingredient/Edit/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EditIngredientViewModel vm)
        {
            if (!ModelState.IsValid)
                return View(vm);

            try
            {
                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (ingredient == null)
                    return NotFound();

                var user = await _userManager.GetUserAsync(User);
                if (ingredient.CreatedByUserId != user!.Id && !User.IsInRole("Admin"))
                    return Forbid();

                // Update properties
                ingredient.Name = vm.Name;
                ingredient.Brand = vm.Brand;
                ingredient.CaloriesPer100g = vm.CaloriesPer100g;
                ingredient.ProteinPer100g = vm.ProteinPer100g;
                ingredient.CarbsPer100g = vm.CarbsPer100g;
                ingredient.FatPer100g = vm.FatPer100g;

                await _ingredientService.UpdateIngredientAsync(ingredient);
                TempData["Success"] = "Ingredient updated successfully";
                return RedirectToAction(nameof(Details), new { id });
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while updating the ingredient.";
                return View(vm);
            }
        }

        // POST: /Ingredient/Delete/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
                if (ingredient == null)
                    return NotFound();

                var user = await _userManager.GetUserAsync(User);
                if (ingredient.CreatedByUserId != user!.Id && !User.IsInRole("Admin"))
                    return Forbid();

                await _ingredientService.SoftDeleteIngredientAsync(id);
                TempData["Success"] = "Ingredient deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while deleting the ingredient.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Ingredient/Restore/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Restore(Guid id)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);

                // Only admins can restore deleted ingredients
                if (!User.IsInRole("Admin"))
                    return Forbid();

                var success = await _ingredientService.RestoreIngredientAsync(id);
                if (success)
                {
                    TempData["Success"] = "Ingredient restored successfully";
                    return RedirectToAction(nameof(Details), new { id });
                }
                else
                {
                    TempData["Error"] = "Unable to restore ingredient";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "An error occurred while restoring the ingredient.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: /Ingredient/ToggleAllergy/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleAllergy(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            bool has = await _allergyService.HasAllergyAsync(user!.Id, id);
            if (has)
                await _allergyService.RemoveAllergyAsync(user.Id, id);
            else
                await _allergyService.AddAllergyAsync(user.Id, id);

            return RedirectToAction(nameof(Details), new { id });
        }

        // POST: /Ingredient/ToggleSave/{id}
        [Authorize]
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleSave(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            bool isSaved = await _savedIngredientService.IsIngredientSavedAsync(user!.Id, id);
            if (isSaved)
                await _savedIngredientService.UnsaveIngredientAsync(user.Id, id);
            else
                await _savedIngredientService.SaveIngredientAsync(user.Id, id);

            return RedirectToAction(nameof(Details), new { id });
        }
    }
}