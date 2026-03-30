using HealthyRecipes.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HealthyRecipes.Services.Recipes;
using HealthyRecipes.Services.Users;

namespace HealthyRecipes.Web.Areas.Admin.Pages
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
        public int TotalRecipes { get; set; }
        public int TotalMealPlans { get; set; }
        public int TotalComments { get; set; }
        public int NewUsersThisWeek { get; set; }
        public int NewRecipesThisWeek { get; set; }

        public async Task OnGetAsync()
        {
            var allUsers = await _userService.GetAllUsersAsync(includeDeleted: true);
            var allRecipes = await _recipeService.GetAllRecipesAsync(includeDeleted: true);
            
            TotalUsers = allUsers.Count();
            TotalRecipes = allRecipes.Count();
            TotalMealPlans = await _context.MealPlans.CountAsync();
            TotalComments = await _context.CommentRatings.CountAsync(cr => !cr.Deleted);

            var weekAgo = DateTime.UtcNow.AddDays(-7);
            NewUsersThisWeek = allUsers.Count(u => u.CreatedAt >= weekAgo);
            NewRecipesThisWeek = allRecipes.Count(r => r.CreatedAt >= weekAgo);
        }
    }
}
