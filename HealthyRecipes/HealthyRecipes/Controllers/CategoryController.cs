using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Categories;
using HealthyRecipes.Web.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace HealthyRecipes.Web.Controllers
{
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
