using HealthyRecipes.Data;
using HealthyRecipes.Services.MealPlans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Web.Areas.Admin.Pages.MealPlans
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IMealPlan _mealPlanService;
        private readonly HealthyRecipesDbContext _context;

        public IndexModel(IMealPlan mealPlanService, HealthyRecipesDbContext context)
        {
            _mealPlanService = mealPlanService;
            _context = context;
        }

        public List<MealPlanViewModel> MealPlans { get; set; } = new();
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        public async Task OnGetAsync()
        {
            var query = _context.MealPlans
                .Include(mp => mp.User)
                .Include(mp => mp.MealPlanDays)
                .AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                var search = SearchTerm.ToLower();
                query = query.Where(mp => 
                    mp.Name.ToLower().Contains(search) ||
                    (mp.Description != null && mp.Description.ToLower().Contains(search))
                );
            }

            var allMealPlans = await query.ToListAsync();

            MealPlans = allMealPlans.Select(mp => new MealPlanViewModel
            {
                Id = mp.Id,
                Name = mp.Name,
                Description = mp.Description,
                CreatedAt = mp.CreatedAt,
                AuthorName = mp.User?.UserName ?? "Unknown",
                DayCount = mp.MealPlanDays?.Count() ?? 0,
                IsDeleted = mp.Deleted
            }).OrderByDescending(mp => mp.CreatedAt).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _mealPlanService.SoftDeleteAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRestoreAsync(Guid id)
        {
            await _mealPlanService.RestoreMealPlanAsync(id);
            return RedirectToPage();
        }

        public class MealPlanViewModel
        {
            public Guid Id { get; set; }
            public string Name { get; set; } = "";
            public string? Description { get; set; }
            public DateTime CreatedAt { get; set; }
            public string AuthorName { get; set; } = "";
            public int DayCount { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
