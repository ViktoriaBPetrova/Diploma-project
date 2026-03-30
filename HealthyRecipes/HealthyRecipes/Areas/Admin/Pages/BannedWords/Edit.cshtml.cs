using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.BannedWords
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly IContentFilter _contentFilterService;

        public EditModel(IContentFilter contentFilterService)
        {
            _contentFilterService = contentFilterService;
        }

        [BindProperty]
        public EditBannedWordViewModel Input { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var words = await _contentFilterService.GetAllBannedWordsAsync();
            var word = words.FirstOrDefault(w => w.Id == id);

            if (word == null)
                return NotFound();

            Input = new EditBannedWordViewModel
            {
                Id = word.Id,
                Word = word.Word,
                Severity = word.Severity,
                IsRegexPattern = word.IsRegexPattern,
                Description = word.Description
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            await _contentFilterService.UpdateBannedWordAsync(
                Input.Id,
                Input.Word,
                Input.Severity,
                Input.IsRegexPattern,
                Input.Description);

            TempData["Success"] = "Banned word updated successfully";
            return RedirectToPage("/BannedWords/Index");
        }
    }
}
