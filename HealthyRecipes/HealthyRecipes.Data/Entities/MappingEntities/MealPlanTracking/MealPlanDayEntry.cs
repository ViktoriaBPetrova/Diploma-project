using System;

namespace HealthyRecipes.Data.Entities
{
    /// <summary>
    /// Represents a user's end-of-day reflection for a specific meal plan day.
    /// Captures overall feelings and completion timestamp.
    /// </summary>
    public class MealPlanDayEntry
    {
        public MealPlanDayEntry()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public MealPlanDayEntry(Guid userId, Guid mealPlanDayId) : this()
        {
            UserId = userId;
            MealPlanDayId = mealPlanDayId;
        }

        // ---------- Primary Key ----------
        public Guid Id { get; init; }

        // ---------- Relationships ----------
        public Guid MealPlanDayId { get; set; }
        public MealPlanDay MealPlanDay { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        // ---------- Reflection Data ----------
        /// <summary>
        /// User's overall reflection at the end of the day.
        /// "How did you feel today overall?"
        /// Max length: 1000 characters
        /// </summary>
        public string? OverallFeeling { get; set; }

        /// <summary>
        /// When the user marked this day as complete.
        /// Used for adherence tracking and analytics.
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        // ---------- Visibility Control ----------
        /// <summary>
        /// Whether this entry is visible publicly.
        /// Inherited from MealPlanFollower.ShareJournalPublicly on completion.
        /// </summary>
        public bool IsPublic { get; set; } = false;

        // ---------- Soft Delete ----------
        public bool Deleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }

        // ---------- Metadata ----------
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; set; }
    }
}
