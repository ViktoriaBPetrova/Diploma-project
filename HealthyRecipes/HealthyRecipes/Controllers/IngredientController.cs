using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.Ingredients.Models;
using HealthyRecipes.Services.SavedIngredients;
using HealthyRecipes.Web.ViewModels.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;

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
                        savedIds = saved.Select(si => si.UserId).ToHashSet();
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
            catch (Exception ex)
            {

                TempData["Error"] = "An error occurred while loading ingredients.";

                return View(new IngredientIndexViewModel
                {
                    Filter = filter ?? new IngredientFilterViewModel()
                });
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
            return RedirectToAction(nameof(Index));
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

            return RedirectToAction(nameof(Index));
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

            return RedirectToAction(nameof(Index));
        }
    }
}
