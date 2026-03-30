using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.CommentRatings;
using HealthyRecipes.Services.MealPlans;
using HealthyRecipes.Services.Recipes;
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
        private readonly IRecipe _recipeService;
        private readonly IMealPlan _mealPlanService;
        private readonly ICommentRating _commentService;

        public ReviewModel(
            IFlaggedContent flaggedContentService,
            IUserModeration userModerationService,
            UserManager<Data.Entities.ApplicationUser> userManager,
            IRecipe recipeService,
            IMealPlan mealPlanService,
            ICommentRating commentService)
        {
            _flaggedContentService = flaggedContentService;
            _userModerationService = userModerationService;
            _userManager = userManager;
            _recipeService = recipeService;
            _mealPlanService = mealPlanService;
            _commentService = commentService;
        }

        public FlaggedContentDetailsViewModel ViewModel { get; set; } = new();

        [BindProperty]
        public ResolveFlaggedContentViewModel Input { get; set; } = new();

        // Quick links for sidebar
        public string? ViewInContextUrl { get; set; }

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

            // Build "View in Context" URL
            ViewInContextUrl = await BuildViewInContextUrlAsync(dto.ContentType, dto.ContentId);

            return Page();
        }

        public async Task<IActionResult> OnPostResolveAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            var admin = await _userManager.GetUserAsync(User);
            var dto = await _flaggedContentService.GetByIdAsync(Input.Id);

            if (dto == null)
                return NotFound();

            // PERFORM THE ACTUAL ACTION BASED ON RESOLUTION TYPE
            switch (Input.Resolution)
            {
                case FlagResolution.ContentRemoved:
                    await RemoveContentAsync(dto.ContentType, dto.ContentId);
                    break;

                case FlagResolution.ContentEdited:
                    // Store in TempData so we know to redirect after resolving
                    var redirectUrl = await BuildEditUrlAsync(dto.ContentType, dto.ContentId);
                    if (redirectUrl != null)
                    {
                        TempData["RedirectToEdit"] = redirectUrl;
                    }
                    break;

                case FlagResolution.UserBanned:
                    // TODO: Implement user banning logic if needed
                    // await BanUserAsync(dto.ContentAuthorId);
                    break;
            }

            // Resolve the flag in the database
            await _flaggedContentService.ResolveAsync(
                Input.Id,
                admin!.Id,
                Input.Resolution,
                Input.AdminNotes);

            // Issue warning if requested
            if (Input.IssueWarning && Input.WarningType.HasValue)
            {
                await _userModerationService.IssueWarningAsync(
                    dto.ContentAuthorId,
                    admin.Id,
                    Input.WarningType.Value,
                    Input.WarningReason ?? "Related to flagged content",
                    Input.Id);
            }

            // Check if we need to redirect to edit page
            if (TempData["RedirectToEdit"] is string editUrl)
            {
                TempData["Success"] = "Flagged content marked for editing. Please edit the content below.";
                return Redirect(editUrl);
            }

            TempData["Success"] = GetSuccessMessage(Input.Resolution);
            return RedirectToPage("/FlaggedContent/Index");
        }

        public async Task<IActionResult> OnPostDismissAsync(Guid id, string? adminNotes)
        {
            var admin = await _userManager.GetUserAsync(User);

            await _flaggedContentService.DismissAsync(id, admin!.Id, adminNotes);

            TempData["Success"] = "Flagged content dismissed as false positive";
            return RedirectToPage("/FlaggedContent/Index");
        }

        // ========== CONTENT REMOVAL ACTIONS ==========

        /// <summary>
        /// Soft delete content based on type
        /// </summary>
        private async Task RemoveContentAsync(string contentType, Guid contentId)
        {
            switch (contentType)
            {
                case "Comment":
                    
                        await _commentService.DeleteCommentByAdminAsync(contentId);
                    
                    break;

                case "Recipe":
                    await _recipeService.SoftDeleteRecipeAsync(contentId);
                    break;

                case "MealPlan":
                    await _mealPlanService.SoftDeleteAsync(contentId);
                    break;

                case "MealEntry":
                case "DayReflection":
                case "UserBio":
                    // These typically don't have soft delete - handle if needed
                    break;

                default:
                    // Unknown content type - log or handle
                    break;
            }
        }

        // ========== URL BUILDING HELPERS ==========

        /// <summary>
        /// Build "View in Context" URL - handles Comments specially
        /// </summary>
        private async Task<string?> BuildViewInContextUrlAsync(string contentType, Guid contentId)
        {
            switch (contentType)
            {
                case "Comment":
                    // Get the comment to find its RecipeId
                    var comment = await _commentService.GetCommentRatingByIdAsync(contentId);
                    if (comment != null)
                    {
                        return $"/Recipe/Details/{comment.RecipeId}#comment-{contentId}";
                    }
                    return null;

                case "Recipe":
                    return $"/Recipe/Details/{contentId}";

                case "MealPlan":
                    return $"/MealPlan/Details/{contentId}";

                case "UserBio":
                    // Can't link directly to bio, would need userId
                    return null;

                default:
                    return null;
            }
        }

        /// <summary>
        /// Build edit URL for content type
        /// </summary>
        private async Task<string?> BuildEditUrlAsync(string contentType, Guid contentId)
        {
            switch (contentType)
            {
                case "Comment":
                    // Get the comment to find its RecipeId
                    var comment = await _commentService.GetCommentRatingByIdAsync(contentId);
                    if (comment != null)
                    {
                        // Navigate to recipe details with comment edit mode
                        return $"/Recipe/Details/{comment.RecipeId}#comment-{contentId}";
                    }
                    return null;

                case "Recipe":
                    return $"/Recipe/Edit/{contentId}";

                case "MealPlan":
                    return $"/MealPlan/Edit/{contentId}";

                case "UserBio":
                    // Would need to get userId from the flagged content
                    return "/User/Edit";

                default:
                    return null;
            }
        }

        /// <summary>
        /// Get success message based on resolution
        /// </summary>
        private string GetSuccessMessage(FlagResolution resolution)
        {
            return resolution switch
            {
                FlagResolution.ContentRemoved => "Content has been removed and flag resolved",
                FlagResolution.ContentEdited => "Flag resolved - content marked for editing",
                FlagResolution.UserWarned => "User warned and flag resolved",
                FlagResolution.UserBanned => "User banned and flag resolved",
                FlagResolution.NoActionNeeded => "Flag resolved - no action needed",
                _ => "Flagged content resolved successfully"
            };
        }
    }
}