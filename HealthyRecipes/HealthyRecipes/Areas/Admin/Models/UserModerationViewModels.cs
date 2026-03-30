using HealthyRecipes.Data.Entities.Admin;

namespace HealthyRecipes.Web.Areas.Admin.Models
{
    public class UserModerationViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime JoinedDate { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime? LockoutEnd { get; set; }

        // Stats
        public int RecipeCount { get; set; }
        public int MealPlanCount { get; set; }
        public int CommentCount { get; set; }
        public int ActiveWarnings { get; set; }
        public int TotalWarnings { get; set; }
        public int FlaggedContentCount { get; set; }

        // Warning history
        public IEnumerable<UserWarningItemViewModel> Warnings { get; set; } = new List<UserWarningItemViewModel>();

        // Flagged content
        public IEnumerable<FlaggedContentItemViewModel> FlaggedContent { get; set; } = new List<FlaggedContentItemViewModel>();
    }

    public class UserWarningItemViewModel
    {
        public Guid Id { get; set; }
        public WarningType Type { get; set; }
        public string TypeDisplay { get; set; } = string.Empty;
        public string Reason { get; set; } = string.Empty;
        public string IssuedByAdminName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public bool IsActive { get; set; }
        public Guid? RelatedFlaggedContentId { get; set; }
    }

    public class IssueWarningViewModel
    {
        public Guid UserId { get; set; }
        public WarningType Type { get; set; } = WarningType.Informal;
        public string Reason { get; set; } = string.Empty;
        public Guid? RelatedFlaggedContentId { get; set; }
        public int? ExpirationDays { get; set; }
    }

    public class UserModerationListViewModel
    {
        public IEnumerable<UserModerationSummaryViewModel> Users { get; set; } = new List<UserModerationSummaryViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 50;
    }

    public class UserModerationSummaryViewModel
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int ActiveWarnings { get; set; }
        public int FlaggedContentCount { get; set; }
        public bool IsLockedOut { get; set; }
        public DateTime JoinedDate { get; set; }
        public DateTime? LastWarningDate { get; set; }
    }
}
