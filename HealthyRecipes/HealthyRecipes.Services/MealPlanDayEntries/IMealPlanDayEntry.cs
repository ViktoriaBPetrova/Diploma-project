using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.MealPlanDayEntries
{
    public interface IMealPlanDayEntry
    {
        /// <summary>
        /// Create or update a day entry (upsert pattern).
        /// If entry exists for this user+day, updates it; otherwise creates new.
        /// </summary>
        Task<Guid> UpsertDayEntryAsync(Guid userId, Guid mealPlanDayId, string? overallFeeling);

        /// <summary>
        /// Get a user's entry for a specific meal plan day.
        /// </summary>
        Task<MealPlanDayEntry?> GetEntryAsync(Guid userId, Guid mealPlanDayId);

        /// <summary>
        /// Get all day entries for a meal plan.
        /// </summary>
        Task<IEnumerable<MealPlanDayEntry>> GetEntriesForMealPlanAsync(Guid userId, Guid mealPlanId);

        /// <summary>
        /// Delete a day entry (soft delete).
        /// </summary>
        Task<bool> DeleteEntryAsync(Guid userId, Guid mealPlanDayId);

        /// <summary>
        /// Update visibility for a specific day entry.
        /// </summary>
        Task<bool> UpdateVisibilityAsync(Guid entryId, bool isPublic);

        /// <summary>
        /// Bulk update visibility for all day entries in a meal plan.
        /// Called when user changes consent after completion.
        /// </summary>
        Task<int> BulkUpdateVisibilityForMealPlanAsync(Guid userId, Guid mealPlanId, bool isPublic);
    }
}
