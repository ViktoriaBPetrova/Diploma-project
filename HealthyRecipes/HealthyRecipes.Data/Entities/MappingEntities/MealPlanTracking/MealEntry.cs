using System;

namespace HealthyRecipes.Data.Entities
{
    /// <summary>
    /// Represents a user's journal entry for a specific meal.
    /// Tracks what they ate, how they felt, and includes optional photo.
    /// </summary>
    public class MealEntry
    {
        public MealEntry()
        {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
        }

        public MealEntry(Guid userId, Guid mealId) : this()
        {
            UserId = userId;
            MealId = mealId;
        }

        // ---------- Primary Key ----------
        public Guid Id { get; init; }

        // ---------- Relationships ----------
        public Guid MealId { get; set; }
        public Meal Meal { get; set; } = null!;

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        // ---------- Journal Data ----------
        /// <summary>
        /// User's comment about how they felt after eating this meal.
        /// Max length: 500 characters
        /// </summary>
        public string? FeelingComment { get; set; }

        /// <summary>
        /// Relative path to the uploaded meal photo.
        /// Stored in /uploads/meal-entries/{userId}/{mealEntryId}.jpg
        /// </summary>
        public string? PhotoUrl { get; set; }

        /// <summary>
        /// When the user actually consumed/logged this meal.
        /// Used for tracking adherence vs planned schedule.
        /// </summary>
        public DateTime? ConsumedAt { get; set; }

        // ---------- Visibility Control ----------
        /// <summary>
        /// Whether this entry is visible publicly.
        /// Inherited from MealPlanFollower.ShareJournalPublicly on completion.
        /// Can be toggled individually after initial consent.
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
