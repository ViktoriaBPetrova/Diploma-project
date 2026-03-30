using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using HealthyRecipes.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HealthyRecipes.Web.Areas.Admin.Pages.ActivityLogs
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly IActivityLog _activityLogService;

        public IndexModel(IActivityLog activityLogService)
        {
            _activityLogService = activityLogService;
        }

        public ActivityLogIndexViewModel ViewModel { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(
            int page = 1,
            Guid? userId = null,
            ActivityType? activityType = null,
            string? entityType = null,
            LogSeverity? severity = null,
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            const int pageSize = 50;

            // Service returns DTOs
            var (logs, totalCount) = await _activityLogService.GetLogsAsync(
                page,
                pageSize,
                userId,
                activityType,
                entityType,
                severity,
                fromDate,
                toDate);

            // Map DTOs to ViewModels
            ViewModel.Logs = logs.Select(MapDtoToViewModel);
            ViewModel.CurrentPage = page;
            ViewModel.TotalCount = totalCount;
            ViewModel.TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
            ViewModel.Filter = new ActivityLogFilterViewModel
            {
                UserId = userId,
                ActivityType = activityType,
                EntityType = entityType,
                Severity = severity,
                FromDate = fromDate,
                ToDate = toDate
            };

            return Page();
        }

        // Map DTO (from Services) to ViewModel (for Web)
        private ActivityLogItemViewModel MapDtoToViewModel(ActivityLogDto dto)
        {
            return new ActivityLogItemViewModel
            {
                Id = dto.Id,
                UserName = dto.UserName,
                UserEmail = dto.UserEmail,
                ActivityType = dto.ActivityType,
                ActivityTypeDisplay = GetActivityTypeDisplay(dto.ActivityType),
                EntityType = dto.EntityType,
                EntityId = dto.EntityId,
                EntityName = dto.EntityName,
                ChangesSummary = dto.ChangesSummary,
                Severity = dto.Severity,
                SeverityDisplay = dto.Severity.ToString(),
                SeverityBadgeClass = GetSeverityBadgeClass(dto.Severity),
                IpAddress = dto.IpAddress,
                CreatedAt = dto.CreatedAt,
                HasDetails = dto.HasDetails
            };
        }

        private string GetActivityTypeDisplay(ActivityType type)
        {
            return type switch
            {
                ActivityType.Create => "Created",
                ActivityType.Update => "Updated",
                ActivityType.Delete => "Deleted",
                ActivityType.SoftDelete => "Soft Deleted",
                ActivityType.Restore => "Restored",
                ActivityType.Login => "Logged In",
                ActivityType.Logout => "Logged Out",
                ActivityType.FailedLogin => "Failed Login",
                ActivityType.CommentPosted => "Posted Comment",
                ActivityType.CommentEdited => "Edited Comment",
                ActivityType.CommentDeleted => "Deleted Comment",
                ActivityType.RatingGiven => "Gave Rating",
                ActivityType.MealPlanFollowed => "Followed Meal Plan",
                ActivityType.MealPlanUnfollowed => "Unfollowed Meal Plan",
                ActivityType.BannedWordDetected => "Banned Word Detected",
                ActivityType.UserBanned => "User Banned",
                ActivityType.UserUnbanned => "User Unbanned",
                ActivityType.ContentFlagged => "Content Flagged",
                _ => type.ToString()
            };
        }

        private string GetSeverityBadgeClass(LogSeverity severity)
        {
            return severity switch
            {
                LogSeverity.Info => "status-info",
                LogSeverity.Low => "status-low",
                LogSeverity.Medium => "status-medium",
                LogSeverity.High => "status-high",
                LogSeverity.Critical => "status-critical",
                _ => "status-info"
            };
        }
    }
}
