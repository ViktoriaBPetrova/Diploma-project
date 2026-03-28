using HealthyRecipes.Data.Entities;

namespace HealthyRecipes.Services.MealEntries
{
    public interface IMealEntry
    {
        /// <summary>
        /// Create or update a meal entry (upsert pattern).
        /// If entry exists for this user+meal, updates it; otherwise creates new.
        /// </summary>
        Task<Guid> UpsertMealEntryAsync(Guid userId, Guid mealId, string? feelingComment, string? photoUrl);

        /// <summary>
        /// Get a user's entry for a specific meal.
        /// </summary>
        Task<MealEntry?> GetEntryAsync(Guid userId, Guid mealId);

        /// <summary>
        /// Get all entries for a specific meal plan day (all meals in that day).
        /// </summary>
        Task<IEnumerable<MealEntry>> GetEntriesForDayAsync(Guid userId, Guid mealPlanDayId);

        /// <summary>
        /// Get all entries for a meal plan (all days, all meals).
        /// </summary>
        Task<IEnumerable<MealEntry>> GetEntriesForMealPlanAsync(Guid userId, Guid mealPlanId);

        /// <summary>
        /// Delete a meal entry (soft delete).
        /// </summary>
        Task<bool> DeleteEntryAsync(Guid userId, Guid mealId);

        /// <summary>
        /// Update visibility for a specific entry.
        /// </summary>
        Task<bool> UpdateVisibilityAsync(Guid entryId, bool isPublic);

        /// <summary>
        /// Bulk update visibility for all entries in a meal plan.
        /// Called when user changes consent after completion.
        /// </summary>
        Task<int> BulkUpdateVisibilityForMealPlanAsync(Guid userId, Guid mealPlanId, bool isPublic);

        /// <summary>
        /// Gets all meal entries for a list of meal IDs (for loading today's logged meals).
        /// </summary>
        Task<IEnumerable<MealEntry>> GetEntriesForMealsAsync(Guid userId, IEnumerable<Guid> mealIds);
    }
}
