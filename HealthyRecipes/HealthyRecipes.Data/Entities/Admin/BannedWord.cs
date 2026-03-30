using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Data.Entities.Admin
{
    public class BannedWord
    {
        public BannedWord()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        public string Word { get; set; } = string.Empty;
        public WordSeverity Severity { get; set; }
        public bool IsActive { get; set; } = true;
        
        // Track who added/modified
        public Guid CreatedByUserId { get; set; }
        public ApplicationUser CreatedBy { get; set; } = null!;
        
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // Optional: pattern matching support
        public bool IsRegexPattern { get; set; } = false;
        public string? Description { get; set; }
    }

    public enum WordSeverity
    {
        Low = 1,      // Mild language, auto-filter
        Medium = 2,   // Inappropriate, flag for review
        High = 3,     // Offensive, auto-block + alert admin
        Critical = 4  // Extreme content, auto-block + log + potential user suspension
    }
}
