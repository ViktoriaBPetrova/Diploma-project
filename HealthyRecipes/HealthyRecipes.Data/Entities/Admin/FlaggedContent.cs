using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Data.Entities.Admin
{
    public class FlaggedContent
    {
        public FlaggedContent()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        
        // What content was flagged
        public string ContentType { get; set; } = string.Empty; // "Comment", "Recipe", "MealPlan"
        public Guid ContentId { get; set; }
        public string ContentPreview { get; set; } = string.Empty; // First 200 chars
        
        // Who created the content
        public Guid ContentAuthorId { get; set; }
        public ApplicationUser ContentAuthor { get; set; } = null!;
        
        // Why it was flagged
        public FlagReason Reason { get; set; }
        public string? Details { get; set; }
        public string? MatchedBannedWords { get; set; } // Comma-separated if auto-flagged
        
        // Who flagged it (null if auto-flagged)
        public Guid? ReportedByUserId { get; set; }
        public ApplicationUser? ReportedBy { get; set; }
        
        // Resolution
        public FlagStatus Status { get; set; } = FlagStatus.Pending;
        public Guid? ReviewedByAdminId { get; set; }
        public ApplicationUser? ReviewedByAdmin { get; set; }
        public DateTime? ReviewedAt { get; set; }
        public string? AdminNotes { get; set; }
        public FlagResolution? Resolution { get; set; }
        //warning to user and then option to warn the repoter if it was false report
        public ICollection<UserWarning> IssuedWarnings { get; set; } = new List<UserWarning>();

        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
    }

    public enum FlagReason
    {
        BannedWords = 1,
        Spam = 2,
        Harassment = 3,
        InappropriateContent = 4,
        Misinformation = 5,
        CopyrightViolation = 6,
        Other = 7
    }

    public enum FlagStatus
    {
        Pending = 1,
        UnderReview = 2,
        Resolved = 3,
        Dismissed = 4
    }

    public enum FlagResolution
    {
        ContentRemoved = 1,
        ContentEdited = 2,
        UserWarned = 3,
        UserBanned = 4,
        NoActionNeeded = 5
    }
}
