using HealthyRecipes.Data;
using HealthyRecipes.Services.Ingredients;
using HealthyRecipes.Services.MealPlans;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Web.Areas.Admin.Pages.Ingredients
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IIngredient _ingredientsService;
        private readonly HealthyRecipesDbContext _context;

        public IndexModel(IIngredient ingredientsService, HealthyRecipesDbContext context)
        {
            _ingredientsService = ingredientsService;
            _context = context;
        }

        public List<IngredientViewModel> Ingredients { get; set; } = new();
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        public async Task OnGetAsync()
        {
            var query = _context.Ingredients
                .Include(mp => mp.User)
                .Include(mp => mp.RecipeIngredients)
                .AsQueryable();
            
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                var search = SearchTerm.ToLower();
                query = query.Where(mp => 
                    mp.Name.ToLower().Contains(search) ||
                    (mp.Name != null && mp.Name.ToLower().Contains(search))
                );
            }

            var allingredients = await query.ToListAsync();

            Ingredients = allingredients.Select(mp => new IngredientViewModel
            {
                Id = mp.Id,
                Name = mp.Name,
                Brand = mp.Brand,
                CaloriesPer100g = mp.CaloriesPer100g,
                ProteinPer100g = mp.ProteinPer100g,
                CarbsPer100g = mp.CarbsPer100g,
                FatPer100g = mp.FatPer100g,
                IsDeleted = mp.Deleted
            }).OrderByDescending(mp => mp.CreatedAt).ToList();
        }

        public class IngredientViewModel
        { 
            public Guid Id { get; set; }
            public string Name { get; set; } = "";
            public string? Brand { get; set; }
            public float CaloriesPer100g { get; set; }
            public float ProteinPer100g { get; set; }
            public float CarbsPer100g { get; set; }
            public float FatPer100g { get; set; }
            public bool IsDeleted { get; set; }
            public DateTime CreatedAt { get; set; }
        }
    }
}
