using HealthyRecipes.Data.Entities.Admin;

namespace HealthyRecipes.Web.Areas.Admin.Models
{
    public class ActivityLogIndexViewModel
    {
        public IEnumerable<ActivityLogItemViewModel> Logs { get; set; } = new List<ActivityLogItemViewModel>();
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 50;

        // Filters
        public ActivityLogFilterViewModel Filter { get; set; } = new();
    }

    public class ActivityLogItemViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public string ActivityTypeDisplay { get; set; } = string.Empty;
        public string EntityType { get; set; } = string.Empty;
        public Guid? EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string? ChangesSummary { get; set; }
        public LogSeverity Severity { get; set; }
        public string SeverityDisplay { get; set; } = string.Empty;
        public string SeverityBadgeClass { get; set; } = string.Empty;
        public string? IpAddress { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool HasDetails { get; set; }
    }

    public class ActivityLogFilterViewModel
    {
        public Guid? UserId { get; set; }
        public ActivityType? ActivityType { get; set; }
        public string? EntityType { get; set; }
        public LogSeverity? Severity { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string? SearchTerm { get; set; }
    }

    public class ActivityLogDetailsViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public ActivityType ActivityType { get; set; }
        public string EntityType { get; set; } = string.Empty;
        public Guid? EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public string? ChangesSummary { get; set; }
        public LogSeverity Severity { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class EntityHistoryViewModel
    {
        public string EntityType { get; set; } = string.Empty;
        public Guid EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty;
        public IEnumerable<ActivityLogItemViewModel> History { get; set; } = new List<ActivityLogItemViewModel>();
    }
}
