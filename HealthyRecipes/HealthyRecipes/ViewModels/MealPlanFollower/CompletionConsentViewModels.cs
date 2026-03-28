using HealthyRecipes.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace HealthyRecipes.Web.ViewModels.MealPlanFollower
{
    /// <summary>
    /// ViewModel for the two-step completion consent flow.
    /// Step 1: Redirect here after user clicks "Mark Complete"
    /// Step 2: Save consents and actually complete the plan
    /// </summary>
    public class CompletionConsentViewModel
    {
        [Required]
        public Guid MealPlanId { get; set; }

        public string MealPlanName { get; set; } = null!;
        public int DaysCount { get; set; }
        public DateTime StartedAt { get; set; }

        // Phase 2: Consent tracking fields
        public MealPlanFollowerStatus Status { get; set; }
        public DateTime? CompletedAt { get; set; }

        [Display(Name = "Display this completed plan on my public profile")]
        public bool ShowOnProfileAsCompleted { get; set; } = false;

        [Display(Name = "Share my meal photos and comments publicly with this plan")]
        public bool ShareJournalPublicly { get; set; } = false;
    }

    /// <summary>
    /// ViewModel for logging a meal (photo + feeling comment).
    /// Used in dedicated LogMeal view (not AJAX modal).
    /// </summary>
    public class LogMealViewModel
    {
        [Required]
        public Guid MealId { get; set; }

        [MaxLength(500, ErrorMessage = "Comment cannot exceed 500 characters")]
        [Display(Name = "How did you feel after this meal?")]
        public string? FeelingComment { get; set; }

        // For file upload (similar to Recipe)
        [Display(Name = "Meal Photo")]
        public IFormFile? PhotoFile { get; set; }

        // For preserving existing photo URL
        public string? PhotoUrl { get; set; }

        public DateTime? ConsumedAt { get; set; }
    }

    /// <summary>
    /// ViewModel for end-of-day reflection.
    /// Used in dedicated LogDayReflection view.
    /// </summary>
    public class LogDayReflectionViewModel
    {
        [Required]
        public Guid MealPlanDayId { get; set; }

        [MaxLength(1000, ErrorMessage = "Reflection cannot exceed 1000 characters")]
        [Display(Name = "How did you feel overall today?")]
        public string? OverallFeeling { get; set; }

        public DateTime? CompletedAt { get; set; }
    }

    /// <summary>
    /// Response DTO for meal logging (if we need AJAX later).
    /// </summary>
    public class MealEntryResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Guid? EntryId { get; set; }
    }

    /// <summary>
    /// Response DTO for day reflection logging (if we need AJAX later).
    /// </summary>
    public class DayEntryResponseDto
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public Guid? EntryId { get; set; }
    }
}