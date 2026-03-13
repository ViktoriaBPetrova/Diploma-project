using HealthyRecipes.Data;
using HealthyRecipes.Services.Users;
using HealthyRecipes.Services.Recipes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Web.Areas.Admin.Pages.Reports
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUser _userService;
        private readonly IRecipe _recipeService;
        private readonly HealthyRecipesDbContext _context;

        public IndexModel(
            IUser userService,
            IRecipe recipeService,
            HealthyRecipesDbContext context)
        {
            _userService = userService;
            _recipeService = recipeService;
            _context = context;
        }

        public int TotalUsers { get; set; }
        public int ActiveUsers { get; set; }
        public int DeletedUsers { get; set; }
        public int TotalRecipes { get; set; }
        public int ActiveRecipes { get; set; }
        public int DeletedRecipes { get; set; }
        public int TotalMealPlans { get; set; }
        public int TotalComments { get; set; }
        public Dictionary<string, int> UsersByMonth { get; set; } = new();
        public Dictionary<string, int> RecipesByMonth { get; set; } = new();

        public async Task OnGetAsync()
        {
            var allUsers = (await _userService.GetAllUsersAsync(includeDeleted: true)).ToList();
            var allRecipes = (await _recipeService.GetAllRecipesAsync(includeDeleted: true)).ToList();

            // User stats
            TotalUsers = allUsers.Count;
            ActiveUsers = allUsers.Count(u => !u.Deleted);
            DeletedUsers = allUsers.Count(u => u.Deleted);

            // Recipe stats
            TotalRecipes = allRecipes.Count;
            ActiveRecipes = allRecipes.Count(r => !r.Deleted);
            DeletedRecipes = allRecipes.Count(r => r.Deleted);

            // Meal plan stats
            TotalMealPlans = await _context.MealPlans.CountAsync();

            // Comment stats
            TotalComments = await _context.CommentRatings.CountAsync(cr => !cr.Deleted);

            // Monthly trends (last 6 months)
            var sixMonthsAgo = DateTime.UtcNow.AddMonths(-6);
            
            UsersByMonth = allUsers
                .Where(u => u.CreatedAt >= sixMonthsAgo)
                .GroupBy(u => u.CreatedAt.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());

            RecipesByMonth = allRecipes
                .Where(r => r.CreatedAt >= sixMonthsAgo)
                .GroupBy(r => r.CreatedAt.ToString("yyyy-MM"))
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count());
        }
    }
}
