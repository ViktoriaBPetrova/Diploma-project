using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.BannedWords
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IContentFilter _contentFilterService;
        private readonly UserManager<ApplicationUser> _userManager;

        public IndexModel(IContentFilter contentFilterService, UserManager<ApplicationUser> userManager)
        {
            _contentFilterService = contentFilterService;
            _userManager = userManager;
        }

        public BannedWordIndexViewModel ViewModel { get; set; } = new();

        [BindProperty]
        public CreateBannedWordViewModel CreateModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Service returns DTOs
            var words = await _contentFilterService.GetAllBannedWordsAsync();
            
            ViewModel.Words = words.Select(MapDtoToViewModel);
            ViewModel.TotalCount = words.Count();
            ViewModel.ActiveCount = words.Count(w => w.IsActive);
            ViewModel.InactiveCount = words.Count(w => !w.IsActive);

            return Page();
        }

        public async Task<IActionResult> OnPostCreateAsync()
        {
            if (!ModelState.IsValid)
            {
                await OnGetAsync();
                return Page();
            }

            var currentUser = await _userManager.GetUserAsync(User);
            
            await _contentFilterService.AddBannedWordAsync(
                CreateModel.Word,
                CreateModel.Severity,
                currentUser!.Id,
                CreateModel.IsRegexPattern,
                CreateModel.Description);

            TempData["SuccessMessage"] = "Banned word added successfully.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostToggleStatusAsync(Guid id)
        {
            await _contentFilterService.ToggleBannedWordStatusAsync(id);
            TempData["SuccessMessage"] = "Word status updated.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(Guid id)
        {
            await _contentFilterService.DeleteBannedWordAsync(id);
            TempData["SuccessMessage"] = "Banned word deleted.";
            return RedirectToPage();
        }

        // Map DTO (from Services) to ViewModel (for Web)
        private BannedWordItemViewModel MapDtoToViewModel(BannedWordDto dto)
        {
            return new BannedWordItemViewModel
            {
                Id = dto.Id,
                Word = dto.Word,
                Severity = dto.Severity,
                SeverityDisplay = dto.Severity.ToString(),
                SeverityBadgeClass = GetSeverityBadgeClass(dto.Severity),
                IsActive = dto.IsActive,
                IsRegexPattern = dto.IsRegexPattern,
                Description = dto.Description,
                CreatedByUserName = dto.CreatedByUserName,
                CreatedAt = dto.CreatedAt
            };
        }

        private string GetSeverityBadgeClass(WordSeverity severity)
        {
            return severity switch
            {
                WordSeverity.Low => "severity-low",
                WordSeverity.Medium => "severity-medium",
                WordSeverity.High => "severity-high",
                WordSeverity.Critical => "severity-critical",
                _ => "severity-medium"
            };
        }
    }
}
