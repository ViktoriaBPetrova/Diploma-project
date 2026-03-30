using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.FlaggedContent
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IFlaggedContent _flaggedContentService;

        public IndexModel(IFlaggedContent flaggedContentService)
        {
            _flaggedContentService = flaggedContentService;
        }

        public FlaggedContentIndexViewModel ViewModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(
            int page = 1,
            FlagStatus? status = null,
            FlagReason? reason = null,
            string? contentType = null)
        {
            const int pageSize = 50;

            // Service returns DTOs
            var (items, totalCount) = await _flaggedContentService.GetFlaggedContentAsync(
                page,
                pageSize,
                status,
                reason,
                contentType);

            // Get stats
            var pendingCount = await _flaggedContentService.GetPendingCountAsync();

            // Map DTOs to ViewModels
            ViewModel.Items = items.Select(MapDtoToViewModel);
            ViewModel.CurrentPage = page;
            ViewModel.TotalCount = totalCount;
            ViewModel.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewModel.PendingCount = pendingCount;
            ViewModel.Filter = new FlaggedContentFilterViewModel
            {
                Status = status,
                Reason = reason,
                ContentType = contentType
            };

            return Page();
        }

        // Map DTO (from Services) to ViewModel (for Web)
        private FlaggedContentItemViewModel MapDtoToViewModel(FlaggedContentDto dto)
        {
            return new FlaggedContentItemViewModel
            {
                Id = dto.Id,
                ContentType = dto.ContentType,
                ContentId = dto.ContentId,
                ContentPreview = dto.ContentPreview,
                ContentAuthorName = dto.ContentAuthorName,
                ContentAuthorEmail = dto.ContentAuthorEmail,
                Reason = dto.Reason,
                ReasonDisplay = GetReasonDisplay(dto.Reason),
                Details = dto.Details,
                MatchedBannedWords = dto.MatchedBannedWords,
                ReportedByUserName = dto.ReportedByUserName,
                Status = dto.Status,
                StatusDisplay = dto.Status.ToString(),
                StatusBadgeClass = GetStatusBadgeClass(dto.Status),
                CreatedAt = dto.CreatedAt,
                IsAutoFlagged = dto.IsAutoFlagged
            };
        }

        private string GetReasonDisplay(FlagReason reason)
        {
            return reason switch
            {
                FlagReason.BannedWords => "Banned Words",
                FlagReason.Spam => "Spam",
                FlagReason.Harassment => "Harassment",
                FlagReason.InappropriateContent => "Inappropriate Content",
                FlagReason.Misinformation => "Misinformation",
                FlagReason.CopyrightViolation => "Copyright Violation",
                FlagReason.Other => "Other",
                _ => reason.ToString()
            };
        }

        private string GetStatusBadgeClass(FlagStatus status)
        {
            return status switch
            {
                FlagStatus.Pending => "status-pending",
                FlagStatus.UnderReview => "status-review",
                FlagStatus.Resolved => "status-resolved",
                FlagStatus.Dismissed => "status-dismissed",
                _ => "status-pending"
            };
        }
    }
}
