using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Allergies;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Web.Models.Category;
using HealthyRecipes.Web.Models.Ingredient;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HealthyRecipes.Web.Controllers
{
    public class IngredientController : Controller
    {
        private readonly IIngredient _ingredientService;
        private readonly IAllergy _allergyService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IngredientController(IIngredient ingredientService, IAllergy allergyService, UserManager<ApplicationUser> userManager)
        {
            _ingredientService = ingredientService;
            _allergyService = allergyService;
            _userManager = userManager;
        }

        // GET: /Ingredient
        public async Task<IActionResult> Index(string? search)
        {
            var all = await _ingredientService.GetAllIngredientsAsync();
            if (!string.IsNullOrWhiteSpace(search))
                all = all.Where(i => i.Name.Contains(search, StringComparison.OrdinalIgnoreCase));

            HashSet<Guid> allergyIds = new();
            if (User.Identity?.IsAuthenticated == true)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    var allergies = await _allergyService.GetAllergiesByUserAsync(user.Id);
                    allergyIds = allergies.Select(a => a.IngredientId).ToHashSet();
                }
            }

            var vm = new IngredientIndexViewModel
            {
                SearchQuery = search,
                UserAllergyIds = allergyIds,
                Ingredients = all.Select(i => new IngredientViewModel
                {
                    Id = i.Id,
                    Name = i.Name,
                    Brand = i.Brand,
                    CaloriesPer100g = i.CaloriesPer100g,
                    ProteinPer100g = i.ProteinPer100g,
                    CarbsPer100g = i.CarbsPer100g,
                    FatPer100g = i.FatPer100g,
                    IsAllergen = allergyIds.Contains(i.Id)
                })
            };

            return View(vm);
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
    }

    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategory _categoryService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CategoryController(ICategory categoryService, UserManager<ApplicationUser> userManager)
        {
            _categoryService = categoryService;
            _userManager = userManager;
        }

        // GET: /Category
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            var vm = new CategoryIndexViewModel
            {
                Categories = categories.Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name,
                    RecipeCount = c.RecipeCategories?.Count() ?? 0
                })
            };
            return View(vm);
        }

        // GET: /Category/Create
        public IActionResult Create() => View(new CreateCategoryViewModel());

        // POST: /Category/Create
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateCategoryViewModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            var user = await _userManager.GetUserAsync(User);
            var category = new Category { Name = vm.Name, CreatedBy = user!.Id };
            await _categoryService.CreateCategoryAsync(category);
            return RedirectToAction(nameof(Index));
        }

        // POST: /Category/Delete/{id}
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _categoryService.SoftDeleteCategoryAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
