using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Data.Entities.MappingEntities
{
    public class MealPlanFollower
    {
        public MealPlanFollower()
        {
            StartedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            IsActive = true;
            HasSeenCompletionPrompt = false;
            Status = MealPlanFollowerStatus.Active;
        }

        public MealPlanFollower(Guid userId, Guid mealPlanId, DateTime startedAt) : this()
        {
            UserId = userId;
            MealPlanId = mealPlanId;
            StartedAt = startedAt;
            UpdatedAt = startedAt;
        }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public Guid MealPlanId { get; set; }
        public MealPlan MealPlan { get; set; } = null!;

        // ---------- Tracking Properties ----------
        public DateTime StartedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public bool HasSeenCompletionPrompt { get; set; }
        public bool IsActive { get; set; }
        public MealPlanFollowerStatus Status { get; set; }
        public string? DropoutReason { get; set; }
        public string? PauseReason { get; set; }

        // ---------- Metadata ----------
        public DateTime UpdatedAt { get; set; }
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; } = null!;     
    }
}
