using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.Users
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IUser _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IUser userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }

        public List<UserViewModel> Users { get; set; } = new();
        
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; } = "";

        public async Task OnGetAsync()
        {
            var allUsers = await _userService.GetAllUsersAsync(includeDeleted: true);
            
            if (!string.IsNullOrWhiteSpace(SearchTerm))
            {
                var search = SearchTerm.ToLower();
                allUsers = allUsers.Where(u => 
                    u.UserName!.ToLower().Contains(search) ||
                    u.Email!.ToLower().Contains(search) ||
                    (u.FirstName != null && u.FirstName.ToLower().Contains(search)) ||
                    (u.LastName != null && u.LastName.ToLower().Contains(search))
                );
            }

            Users = allUsers.Select(u => new UserViewModel
            {
                Id = u.Id,
                UserName = u.UserName ?? "",
                Email = u.Email ?? "",
                FirstName = u.FirstName,
                LastName = u.LastName,
                CreatedAt = u.CreatedAt,
                RecipeCount = u.CreatedRecipes?.Count() ?? 0,
                MealPlanCount = u.CreatedMealPlans?.Count() ?? 0,
                IsDeleted = u.Deleted
            }).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _userService.SoftDeleteUserAsync(id);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostRestoreAsync(Guid id)
        {
            await _userService.RestoreUserAsync(id);
            return RedirectToPage();
        }

        public class UserViewModel
        {
            public Guid Id { get; set; }
            public string UserName { get; set; } = "";
            public string Email { get; set; } = "";
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime CreatedAt { get; set; }
            public int RecipeCount { get; set; }
            public int MealPlanCount { get; set; }
            public bool IsDeleted { get; set; }
        }
    }
}
