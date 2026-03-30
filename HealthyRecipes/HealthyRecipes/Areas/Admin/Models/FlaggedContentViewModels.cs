using HealthyRecipes.Data.Entities.Admin;

namespace HealthyRecipes.Web.Areas.Admin.Models
{
    public class FlaggedContentIndexViewModel
    {
        public IEnumerable<FlaggedContentItemViewModel> Items { get; set; } = new List<FlaggedContentItemViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 50;

        // Stats
        public int PendingCount { get; set; }
        public int UnderReviewCount { get; set; }
        public int ResolvedCount { get; set; }

        // Filters
        public FlaggedContentFilterViewModel Filter { get; set; } = new();
    }

    public class FlaggedContentItemViewModel
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; } = string.Empty;
        public string ContentAuthorName { get; set; } = string.Empty;
        public string ContentAuthorEmail { get; set; } = string.Empty;
        public FlagReason Reason { get; set; }
        public string ReasonDisplay { get; set; } = string.Empty;
        public string? Details { get; set; }
        public string? MatchedBannedWords { get; set; }
        public string? ReportedByUserName { get; set; }
        public FlagStatus Status { get; set; }
        public string StatusDisplay { get; set; } = string.Empty;
        public string StatusBadgeClass { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsAutoFlagged { get; set; }
    }

    public class FlaggedContentFilterViewModel
    {
        public FlagStatus? Status { get; set; }
        public FlagReason? Reason { get; set; }
        public string? ContentType { get; set; }
    }

    public class FlaggedContentDetailsViewModel
    {
        public Guid Id { get; set; }
        public string ContentType { get; set; } = string.Empty;
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; } = string.Empty;
        public string ContentAuthorName { get; set; } = string.Empty;
        public string ContentAuthorEmail { get; set; } = string.Empty;
        public Guid ContentAuthorId { get; set; }
        public FlagReason Reason { get; set; }
        public string? Details { get; set; }
        public string? MatchedBannedWords { get; set; }
        public string? ReportedByUserName { get; set; }
        public FlagStatus Status { get; set; }
        public FlagResolution? Resolution { get; set; }
        public string? ReviewedByAdminName { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? AdminNotes { get; set; }
        public DateTime CreatedAt { get; set; }

        // Author warning history
        public int AuthorActiveWarnings { get; set; }
        public int AuthorTotalFlags { get; set; }
    }

    public class ResolveFlaggedContentViewModel
    {
        public Guid Id { get; set; }
        public FlagResolution Resolution { get; set; }
        public string? AdminNotes { get; set; }
        public bool IssueWarning { get; set; }
        public WarningType? WarningType { get; set; }
        public string? WarningReason { get; set; }
    }
}
