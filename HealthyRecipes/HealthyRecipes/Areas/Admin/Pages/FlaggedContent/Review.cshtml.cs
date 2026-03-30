using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.FlaggedContent
{
    [Authorize(Roles = "Admin")]
    public class ReviewModel : PageModel
    {
        private readonly IFlaggedContent _flaggedContentService;
        private readonly IUserModeration _userModerationService;
        private readonly UserManager<Data.Entities.ApplicationUser> _userManager;

        public ReviewModel(
            IFlaggedContent flaggedContentService,
            IUserModeration userModerationService,
            UserManager<Data.Entities.ApplicationUser> userManager)
        {
            _flaggedContentService = flaggedContentService;
            _userModerationService = userModerationService;
            _userManager = userManager;
        }

        public FlaggedContentDetailsViewModel ViewModel { get; set; } = new();

        [BindProperty]
        public ResolveFlaggedContentViewModel Input { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            var dto = await _flaggedContentService.GetByIdAsync(id);
            if (dto == null)
                return NotFound();

            var activeWarnings = await _userModerationService.GetActiveWarningCountAsync(dto.ContentAuthorId);

            ViewModel = new FlaggedContentDetailsViewModel
            {
                Id = dto.Id,
                ContentType = dto.ContentType,
                ContentId = dto.ContentId,
                ContentPreview = dto.ContentPreview,
                ContentAuthorId = dto.ContentAuthorId,
                ContentAuthorName = dto.ContentAuthorName,
                ContentAuthorEmail = dto.ContentAuthorEmail,
                Reason = dto.Reason,
                Details = dto.Details,
                MatchedBannedWords = dto.MatchedBannedWords,
                ReportedByUserName = dto.ReportedByUserName,
                Status = dto.Status,
                Resolution = dto.Resolution,
                CreatedAt = dto.CreatedAt,
                AuthorActiveWarnings = activeWarnings
            };

            Input.Id = id;

            return Page();
        }

        public async Task<IActionResult> OnPostResolveAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var admin = await _userManager.GetUserAsync(User);

            await _flaggedContentService.ResolveAsync(
                Input.Id,
                admin!.Id,
                Input.Resolution,
                Input.AdminNotes);

            // Issue warning if requested
            if (Input.IssueWarning && Input.WarningType.HasValue)
            {
                var dto = await _flaggedContentService.GetByIdAsync(Input.Id);
                if (dto != null)
                {
                    // Get author ID - Note: This needs proper implementation
                    // For now using a placeholder - you'll need to add ContentAuthorId to the DTO
                    var authorId = Guid.Empty; // TODO: Get from DTO

                    await _userModerationService.IssueWarningAsync(
                        authorId,
                        admin.Id,
                        Input.WarningType.Value,
                        Input.WarningReason ?? "Related to flagged content",
                        Input.Id);
                }
            }

            TempData["Success"] = "Flagged content resolved successfully";
            return RedirectToPage("/FlaggedContent/Index");
        }

        public async Task<IActionResult> OnPostDismissAsync(Guid id, string? adminNotes)
        {
            var admin = await _userManager.GetUserAsync(User);

            await _flaggedContentService.DismissAsync(id, admin!.Id, adminNotes);

            TempData["Success"] = "Flagged content dismissed";
            return RedirectToPage("/FlaggedContent/Index");
        }
    }
}
