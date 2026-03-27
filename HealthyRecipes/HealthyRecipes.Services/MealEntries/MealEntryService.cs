using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.MealEntries
{
    public class MealEntryService : IMealEntry
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealEntryService> _logger;

        public MealEntryService(
            HealthyRecipesDbContext context,
            ILogger<MealEntryService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> UpsertMealEntryAsync(Guid userId, Guid mealId, string? feelingComment, string? photoUrl)
        {
            try
            {
                var existingEntry = await _context.Set<MealEntry>()
                    .FirstOrDefaultAsync(me => me.UserId == userId && me.MealId == mealId && !me.Deleted);

                if (existingEntry != null)
                {
                    // Update existing
                    existingEntry.FeelingComment = feelingComment;
                    if (!string.IsNullOrEmpty(photoUrl))
                    {
                        existingEntry.PhotoUrl = photoUrl;
                    }
                    existingEntry.ConsumedAt = DateTime.UtcNow;
                    existingEntry.UpdatedAt = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Updated meal entry {EntryId} for user {UserId} and meal {MealId}", 
                        existingEntry.Id, userId, mealId);
                    return existingEntry.Id;
                }
                else
                {
                    // Create new
                    var newEntry = new MealEntry(userId, mealId)
                    {
                        FeelingComment = feelingComment,
                        PhotoUrl = photoUrl,
                        ConsumedAt = DateTime.UtcNow
                    };

                    await _context.Set<MealEntry>().AddAsync(newEntry);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Created meal entry {EntryId} for user {UserId} and meal {MealId}", 
                        newEntry.Id, userId, mealId);
                    return newEntry.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error upserting meal entry for user {UserId} and meal {MealId}", userId, mealId);
                throw;
            }
        }

        public async Task<MealEntry?> GetEntryAsync(Guid userId, Guid mealId)
        {
            try
            {
                return await _context.Set<MealEntry>()
                    .Include(me => me.Meal)
                    .Include(me => me.User)
                    .FirstOrDefaultAsync(me => me.UserId == userId && me.MealId == mealId && !me.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting meal entry for user {UserId} and meal {MealId}", userId, mealId);
                throw;
            }
        }

        public async Task<IEnumerable<MealEntry>> GetEntriesForDayAsync(Guid userId, Guid mealPlanDayId)
        {
            try
            {
                return await _context.Set<MealEntry>()
                    .Include(me => me.Meal)
                    .Where(me => me.UserId == userId 
                              && me.Meal.MealPlanDayId == mealPlanDayId 
                              && !me.Deleted)
                    .OrderBy(me => me.Meal.Type)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting meal entries for day {DayId} and user {UserId}", mealPlanDayId, userId);
                throw;
            }
        }

        public async Task<IEnumerable<MealEntry>> GetEntriesForMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealEntry>()
                    .Include(me => me.Meal)
                        .ThenInclude(m => m.MealPlanDay)
                    .Where(me => me.UserId == userId 
                              && me.Meal.MealPlanDay.MealPlanId == mealPlanId 
                              && !me.Deleted)
                    .OrderBy(me => me.Meal.MealPlanDay.DayNumber)
                        .ThenBy(me => me.Meal.Type)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting meal entries for meal plan {MealPlanId} and user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> DeleteEntryAsync(Guid userId, Guid mealId)
        {
            try
            {
                var entry = await _context.Set<MealEntry>()
                    .FirstOrDefaultAsync(me => me.UserId == userId && me.MealId == mealId && !me.Deleted);

                if (entry == null)
                    return false;

                entry.Deleted = true;
                entry.DeletedAt = DateTime.UtcNow;
                entry.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted meal entry {EntryId}", entry.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting meal entry for user {UserId} and meal {MealId}", userId, mealId);
                throw;
            }
        }

        public async Task<bool> UpdateVisibilityAsync(Guid entryId, bool isPublic)
        {
            try
            {
                var entry = await _context.Set<MealEntry>()
                    .FirstOrDefaultAsync(me => me.Id == entryId && !me.Deleted);

                if (entry == null)
                    return false;

                entry.IsPublic = isPublic;
                entry.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated visibility for meal entry {EntryId} to {IsPublic}", entryId, isPublic);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating visibility for meal entry {EntryId}", entryId);
                throw;
            }
        }

        public async Task<int> BulkUpdateVisibilityForMealPlanAsync(Guid userId, Guid mealPlanId, bool isPublic)
        {
            try
            {
                var entries = await _context.Set<MealEntry>()
                    .Where(me => me.UserId == userId 
                              && me.Meal.MealPlanDay.MealPlanId == mealPlanId 
                              && !me.Deleted)
                    .ToListAsync();

                foreach (var entry in entries)
                {
                    entry.IsPublic = isPublic;
                    entry.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Bulk updated visibility for {Count} meal entries in plan {MealPlanId} to {IsPublic}", 
                    entries.Count, mealPlanId, isPublic);

                return entries.Count;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error bulk updating visibility for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }
    }
}
