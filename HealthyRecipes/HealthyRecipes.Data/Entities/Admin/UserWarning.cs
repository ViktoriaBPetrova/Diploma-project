using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Data.Entities.Admin
{
    public class UserWarning
    {
        public UserWarning()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; set; }
        
        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;
        
        public string Reason { get; set; } = string.Empty;
        public WarningType Type { get; set; }
        
        // Link to flagged content if applicable
        public Guid? RelatedFlaggedContentId { get; set; }
        public FlaggedContent? RelatedFlaggedContent { get; set; }
        
        // Admin who issued warning
        public Guid IssuedByAdminId { get; set; }
        public ApplicationUser IssuedByAdmin { get; set; } = null!;
        
        public DateTime CreatedAt { get; init; }
        public DateTime? ExpiresAt { get; set; }

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public bool IsActive { get; set; } = true;
    }

    public enum WarningType
    {
        Informal = 1,    // Friendly reminder
        Formal = 2,      // Official warning
        Final = 3,       // Last warning before ban
        Temporary = 4,   // Temporary restriction
        Permanent = 5    // Account suspended
    }
}
