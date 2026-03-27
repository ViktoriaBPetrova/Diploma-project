using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.MealPlanDayEntries
{
    public class MealPlanDayEntryService : IMealPlanDayEntry
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealPlanDayEntryService> _logger;

        public MealPlanDayEntryService(
            HealthyRecipesDbContext context,
            ILogger<MealPlanDayEntryService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> UpsertDayEntryAsync(Guid userId, Guid mealPlanDayId, string? overallFeeling)
        {
            try
            {
                var existingEntry = await _context.Set<MealPlanDayEntry>()
                    .FirstOrDefaultAsync(mpde => mpde.UserId == userId 
                                              && mpde.MealPlanDayId == mealPlanDayId 
                                              && !mpde.Deleted);

                if (existingEntry != null)
                {
                    // Update existing
                    existingEntry.OverallFeeling = overallFeeling;
                    existingEntry.CompletedAt = DateTime.UtcNow;
                    existingEntry.UpdatedAt = DateTime.UtcNow;

                    await _context.SaveChangesAsync();
                    _logger.LogInformation("Updated day entry {EntryId} for user {UserId} and day {DayId}", 
                        existingEntry.Id, userId, mealPlanDayId);
                    return existingEntry.Id;
                }
                else
                {
                    // Create new
                    var newEntry = new MealPlanDayEntry(userId, mealPlanDayId)
                    {
                        OverallFeeling = overallFeeling,
                        CompletedAt = DateTime.UtcNow
                    };

                    await _context.Set<MealPlanDayEntry>().AddAsync(newEntry);
                    await _context.SaveChangesAsync();

                    _logger.LogInformation("Created day entry {EntryId} for user {UserId} and day {DayId}", 
                        newEntry.Id, userId, mealPlanDayId);
                    return newEntry.Id;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error upserting day entry for user {UserId} and day {DayId}", userId, mealPlanDayId);
                throw;
            }
        }

        public async Task<MealPlanDayEntry?> GetEntryAsync(Guid userId, Guid mealPlanDayId)
        {
            try
            {
                return await _context.Set<MealPlanDayEntry>()
                    .Include(mpde => mpde.MealPlanDay)
                    .Include(mpde => mpde.User)
                    .FirstOrDefaultAsync(mpde => mpde.UserId == userId 
                                              && mpde.MealPlanDayId == mealPlanDayId 
                                              && !mpde.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting day entry for user {UserId} and day {DayId}", userId, mealPlanDayId);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanDayEntry>> GetEntriesForMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealPlanDayEntry>()
                    .Include(mpde => mpde.MealPlanDay)
                    .Where(mpde => mpde.UserId == userId 
                                && mpde.MealPlanDay.MealPlanId == mealPlanId 
                                && !mpde.Deleted)
                    .OrderBy(mpde => mpde.MealPlanDay.DayNumber)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting day entries for meal plan {MealPlanId} and user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> DeleteEntryAsync(Guid userId, Guid mealPlanDayId)
        {
            try
            {
                var entry = await _context.Set<MealPlanDayEntry>()
                    .FirstOrDefaultAsync(mpde => mpde.UserId == userId 
                                              && mpde.MealPlanDayId == mealPlanDayId 
                                              && !mpde.Deleted);

                if (entry == null)
                    return false;

                entry.Deleted = true;
                entry.DeletedAt = DateTime.UtcNow;
                entry.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Deleted day entry {EntryId}", entry.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting day entry for user {UserId} and day {DayId}", userId, mealPlanDayId);
                throw;
            }
        }

        public async Task<bool> UpdateVisibilityAsync(Guid entryId, bool isPublic)
        {
            try
            {
                var entry = await _context.Set<MealPlanDayEntry>()
                    .FirstOrDefaultAsync(mpde => mpde.Id == entryId && !mpde.Deleted);

                if (entry == null)
                    return false;

                entry.IsPublic = isPublic;
                entry.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Updated visibility for day entry {EntryId} to {IsPublic}", entryId, isPublic);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating visibility for day entry {EntryId}", entryId);
                throw;
            }
        }

        public async Task<int> BulkUpdateVisibilityForMealPlanAsync(Guid userId, Guid mealPlanId, bool isPublic)
        {
            try
            {
                var entries = await _context.Set<MealPlanDayEntry>()
                    .Where(mpde => mpde.UserId == userId 
                                && mpde.MealPlanDay.MealPlanId == mealPlanId 
                                && !mpde.Deleted)
                    .ToListAsync();

                foreach (var entry in entries)
                {
                    entry.IsPublic = isPublic;
                    entry.UpdatedAt = DateTime.UtcNow;
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Bulk updated visibility for {Count} day entries in plan {MealPlanId} to {IsPublic}", 
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
