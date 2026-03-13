using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.Recipes
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IRecipe _recipeService;

        public IndexModel(IRecipe recipeService)
        {
            _recipeService = recipeService;
        }

        public List<RecipeViewModel> Recipes { get; set; } = new();
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        [BindProperty(SupportsGet = true)]
        public string Status { get; set; } = "all";

        public async Task OnGetAsync()
        {
            var allRecipes = await _recipeService.GetAllRecipesAsync(includeDeleted: true);
            
            // Filter by status
            if (Status == "deleted")
            {
                allRecipes = allRecipes.Where(r => r.Deleted);
            }
            else if (Status == "active")
            {
                allRecipes = allRecipes.Where(r => !r.Deleted);
            }
            
            // Search filter
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                var search = SearchTerm.ToLower();
                allRecipes = allRecipes.Where(r => 
                    r.Title.ToLower().Contains(search) ||
                    (r.Info != null && r.Info.ToLower().Contains(search))
                );
            }

            Recipes = allRecipes.Select(r => new RecipeViewModel
            {
                Id = r.Id,
                Title = r.Title,
                Info = r.Info,
                CreatedAt = r.CreatedAt,
                AuthorName = r.User?.UserName ?? "Unknown",
                Calories = r.Calories,
                PrepTime = r.PrepTime,
                Difficulty = r.Difficulty.ToString(),
                IsDeleted = r.Deleted
            }).OrderByDescending(r => r.CreatedAt).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _recipeService.SoftDeleteRecipeAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRestoreAsync(Guid id)
        {
            await _recipeService.RestoreRecipeAsync(id);
            return RedirectToPage();
        }

        public class RecipeViewModel
        {
            public Guid Id { get; set; }
            public string Title { get; set; } = "";
            public string? Info { get; set; }
            public DateTime CreatedAt { get; set; }
            public string AuthorName { get; set; } = "";
            public float? Calories { get; set; }
            public int? PrepTime { get; set; }
            public string? Difficulty { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
