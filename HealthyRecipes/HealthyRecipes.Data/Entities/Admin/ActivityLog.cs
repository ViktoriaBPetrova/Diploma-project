using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Data.Entities.Admin
{
    public class ActivityLog
    {
        public ActivityLog()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        
        // Who performed the action
        public Guid? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        
        // What was done
        public ActivityType ActivityType { get; set; }
        public string EntityType { get; set; } = string.Empty; // "Recipe", "MealPlan", "User", etc.
        public Guid? EntityId { get; set; }
        public string EntityName { get; set; } = string.Empty; // Recipe title, user email, etc.
        
        // Details of the change
        public string? OldValue { get; set; } // JSON serialized old state
        public string? NewValue { get; set; } // JSON serialized new state
        public string? ChangesSummary { get; set; } // Human-readable summary
        
        // Metadata
        public LogSeverity Severity { get; set; }
        public string? IpAddress { get; set; }
        public string? UserAgent { get; set; }
        public DateTime CreatedAt { get; init; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }

    public enum ActivityType
    {
        Create = 1,
        Update = 2,
        Delete = 3,
        SoftDelete = 4,
        Restore = 5,
        Login = 6,
        Logout = 7,
        FailedLogin = 8,
        CommentPosted = 9,
        CommentEdited = 10,
        CommentDeleted = 11,
        RatingGiven = 12,
        MealPlanFollowed = 13,
        MealPlanUnfollowed = 14,
        BannedWordDetected = 15,
        UserBanned = 16,
        UserUnbanned = 17,
        ContentFlagged = 18
    }

    public enum LogSeverity
    {
        Info = 1,      // Regular actions (create, view)
        Low = 2,       // Minor edits
        Medium = 3,    // Important changes (delete, major edit)
        High = 4,      // Security events (failed login, banned words)
        Critical = 5   // Severe issues (user banned, content flagged)
    }
}
