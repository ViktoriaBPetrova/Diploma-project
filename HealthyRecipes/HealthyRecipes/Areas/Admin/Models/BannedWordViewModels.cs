using HealthyRecipes.Data.Entities.Admin;

namespace HealthyRecipes.Web.Areas.Admin.Models
{
    public class BannedWordIndexViewModel
    {
        public IEnumerable<BannedWordItemViewModel> Words { get; set; } = new List<BannedWordItemViewModel>();
        public int TotalCount { get; set; }
        public int ActiveCount { get; set; }
        public int InactiveCount { get; set; }
    }

    public class BannedWordItemViewModel
    {
        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public WordSeverity Severity { get; set; }
        public string SeverityDisplay { get; set; } = string.Empty;
        public string SeverityBadgeClass { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public bool IsRegexPattern { get; set; }
        public string? Description { get; set; }
        public string CreatedByUserName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }

    public class CreateBannedWordViewModel
    {
        public string Word { get; set; } = string.Empty;
        public WordSeverity Severity { get; set; } = WordSeverity.Medium;
        public bool IsRegexPattern { get; set; } = false;
        public string? Description { get; set; }
    }

    public class EditBannedWordViewModel
    {
        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public WordSeverity Severity { get; set; }
        public bool IsRegexPattern { get; set; }
        public string? Description { get; set; }
    }
}
