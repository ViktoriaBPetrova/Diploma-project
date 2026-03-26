using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace HealthyRecipes.Services.MealPlanFollowers
{
    public class MealPlanFollowerService : IMealPlanFollower
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealPlanFollowerService> _logger;

        public MealPlanFollowerService(
            HealthyRecipesDbContext context,
            ILogger<MealPlanFollowerService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<bool> StartFollowingAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                // PHASE 1: Check if user already has an active plan
                var existingActive = await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.IsActive
                                             && mpf.Status == MealPlanFollowerStatus.Active
                                             && !mpf.Deleted);

                if (existingActive != null && existingActive.MealPlanId != mealPlanId)
                {
                    _logger.LogWarning("User {UserId} already has active plan {MealPlanId} - cannot start new plan {NewPlanId}", 
                        userId, existingActive.MealPlanId, mealPlanId);
                    return false; // User can only follow one plan at a time
                }

                // Check if already actively following this specific plan
                var activeFollow = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.MealPlanId == mealPlanId
                                             && mpf.IsActive
                                             && !mpf.Deleted);

                if (activeFollow != null)
                {
                    _logger.LogWarning("User {UserId} is already following meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                // Get meal plan to calculate expected completion date
                var mealPlan = await _context.MealPlans
                    .Include(mp => mp.MealPlanDays)
                    .FirstOrDefaultAsync(mp => mp.Id == mealPlanId && !mp.Deleted);

                if (mealPlan == null)
                {
                    _logger.LogWarning("Meal plan {MealPlanId} not found", mealPlanId);
                    return false;
                }

                var durationDays = mealPlan.MealPlanDays.Count(d => !d.Deleted);

                // Check if there's a previous follow (dropped or completed) that can be reactivated
                var previousFollow = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.MealPlanId == mealPlanId
                                             && !mpf.IsActive
                                             && !mpf.Deleted);

                if (previousFollow != null)
                {
                    // Reactivate the existing relationship
                    previousFollow.IsActive = true;
                    previousFollow.Status = MealPlanFollowerStatus.Active;
                    previousFollow.DropoutReason = null;
                    previousFollow.PauseReason = null;
                    previousFollow.StartedAt = DateTime.UtcNow; // Reset start date
                    previousFollow.ExpectedCompletionDate = DateTime.UtcNow.AddDays(durationDays);
                    previousFollow.HasSeenCompletionPrompt = false;
                    previousFollow.UpdatedAt = DateTime.UtcNow;

                    _logger.LogInformation("User {UserId} reactivated meal plan {MealPlanId}", userId, mealPlanId);
                }
                else
                {
                    // Create new follow relationship
                    var follower = new MealPlanFollower
                    {
                        UserId = userId,
                        MealPlanId = mealPlanId,
                        IsActive = true,
                        Status = MealPlanFollowerStatus.Active,
                        StartedAt = DateTime.UtcNow,
                        ExpectedCompletionDate = DateTime.UtcNow.AddDays(durationDays),
                        HasSeenCompletionPrompt = false,
                        UpdatedAt = DateTime.UtcNow
                    };

                    await _context.Set<MealPlanFollower>().AddAsync(follower);
                    _logger.LogInformation("User {UserId} started following meal plan {MealPlanId} (expected completion: {Date})", 
                        userId, mealPlanId, follower.ExpectedCompletionDate);
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error starting to follow meal plan {MealPlanId} for user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> CompleteMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                var follower = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.MealPlanId == mealPlanId
                                             && mpf.IsActive
                                             && !mpf.Deleted);

                if (follower == null)
                {
                    _logger.LogWarning("User {UserId} is not actively following meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                follower.Status = MealPlanFollowerStatus.Completed;
                follower.IsActive = false;
                follower.CompletedAt = DateTime.UtcNow;
                follower.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} completed meal plan {MealPlanId}", userId, mealPlanId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error completing meal plan {MealPlanId} for user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> DropMealPlanAsync(Guid userId, Guid mealPlanId, string? reason = null)
        {
            try
            {
                var follower = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.MealPlanId == mealPlanId
                                             && mpf.IsActive
                                             && !mpf.Deleted);

                if (follower == null)
                {
                    _logger.LogWarning("User {UserId} is not actively following meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                follower.Status = MealPlanFollowerStatus.Dropped;
                follower.IsActive = false;
                follower.DropoutReason = reason;
                follower.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} dropped meal plan {MealPlanId} with reason: {Reason}", userId, mealPlanId, reason);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error dropping meal plan {MealPlanId} for user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> PauseMealPlanAsync(Guid userId, Guid mealPlanId, string? reason = null)
        {
            try
            {
                var follower = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId
                                             && mpf.MealPlanId == mealPlanId
                                             && !mpf.Deleted);

                if (follower == null)
                {
                    _logger.LogWarning("User {UserId} is not following meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                if (follower.Status != MealPlanFollowerStatus.Active)
                {
                    _logger.LogWarning("Cannot pause meal plan {MealPlanId} for user {UserId} - not active", mealPlanId, userId);
                    return false;
                }

                follower.Status = MealPlanFollowerStatus.Paused;
                follower.IsActive = false;
                follower.PauseReason = reason; 
                follower.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} paused meal plan {MealPlanId}", userId, mealPlanId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error pausing meal plan {MealPlanId} for user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> ResumeMealPlanAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                // PHASE 1: Check if user already has a different active plan
                var existingActive = await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId 
                                             && mpf.IsActive 
                                             && mpf.Status == MealPlanFollowerStatus.Active
                                             && !mpf.Deleted);

                if (existingActive != null && existingActive.MealPlanId != mealPlanId)
                {
                    _logger.LogWarning("User {UserId} already has active plan {MealPlanId} - cannot resume {PausedPlanId}", 
                        userId, existingActive.MealPlanId, mealPlanId);
                    return false;
                }

                var follower = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId && mpf.MealPlanId == mealPlanId && !mpf.Deleted);

                if (follower == null)
                {
                    _logger.LogWarning("User {UserId} is not following meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                if (follower.Status != MealPlanFollowerStatus.Paused)
                {
                    _logger.LogWarning("Cannot resume meal plan {MealPlanId} for user {UserId} - not paused", mealPlanId, userId);
                    return false;
                }

                follower.Status = MealPlanFollowerStatus.Active;
                follower.IsActive = true;
                follower.PauseReason = null;
                follower.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("User {UserId} resumed meal plan {MealPlanId}", userId, mealPlanId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error resuming meal plan {MealPlanId} for user {UserId}", mealPlanId, userId);
                throw;
            }
        }

        public async Task<bool> IsFollowingAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .AnyAsync(mpf => mpf.UserId == userId && mpf.MealPlanId == mealPlanId && !mpf.Deleted && mpf.IsActive);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error checking if user {UserId} is following meal plan {MealPlanId}", userId, mealPlanId);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanFollower>> GetAllFollowingPlansAsync(Guid userId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.User)
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                    .Where(mpf => mpf.UserId == userId && !mpf.Deleted)
                    .OrderByDescending(mpf => mpf.StartedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting all following plans for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanFollower>> GetPlanFollowersAsync(Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.User)
                    .Include(mpf => mpf.MealPlan)
                    .Where(mpf => mpf.MealPlanId == mealPlanId && !mpf.Deleted)
                    .OrderByDescending(mpf => mpf.UpdatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting followers for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<MealPlanFollower?> GetFollowerDetailsAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.User)
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                            .ThenInclude(mpd => mpd.Meals)
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId && mpf.MealPlanId == mealPlanId && !mpf.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting follower details for user {UserId} and meal plan {MealPlanId}", userId, mealPlanId);
                throw;
            }
        }

        public async Task<int> GetFollowerCountAsync(Guid mealPlanId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .CountAsync(mpf => mpf.MealPlanId == mealPlanId && !mpf.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting follower count for meal plan {MealPlanId}", mealPlanId);
                throw;
            }
        }

        // ========== PHASE 1: NEW METHODS ==========

        public async Task<MealPlanFollower?> GetActivePlanAsync(Guid userId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.User)
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId 
                                             && mpf.IsActive 
                                             && mpf.Status == MealPlanFollowerStatus.Active
                                             && !mpf.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active plan for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanFollower>> GetActiveFollowingPlansAsync(Guid userId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.User)
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                    .Where(mpf => mpf.UserId == userId 
                               && mpf.Status == MealPlanFollowerStatus.Active
                               && !mpf.Deleted)
                    .OrderByDescending(mpf => mpf.StartedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting active following plans for user {UserId}", userId);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlanFollower>> GetPausedFollowingPlansAsync(Guid userId)
        {
            try
            {
                return await _context.Set<MealPlanFollower>()
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.User)
                    .Include(mpf => mpf.MealPlan)
                        .ThenInclude(mp => mp.MealPlanDays)
                    .Where(mpf => mpf.UserId == userId 
                               && mpf.Status == MealPlanFollowerStatus.Paused
                               && !mpf.Deleted)
                    .OrderByDescending(mpf => mpf.UpdatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting paused following plans for user {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> MarkCompletionPromptSeenAsync(Guid userId, Guid mealPlanId)
        {
            try
            {
                var follower = await _context.Set<MealPlanFollower>()
                    .FirstOrDefaultAsync(mpf => mpf.UserId == userId 
                                             && mpf.MealPlanId == mealPlanId 
                                             && !mpf.Deleted);

                if (follower == null)
                {
                    _logger.LogWarning("Follower not found for user {UserId} and meal plan {MealPlanId}", userId, mealPlanId);
                    return false;
                }

                follower.HasSeenCompletionPrompt = true;
                follower.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Marked completion prompt as seen for user {UserId} and meal plan {MealPlanId}", userId, mealPlanId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error marking completion prompt as seen for user {UserId} and meal plan {MealPlanId}", userId, mealPlanId);
                throw;
            }
        }
    }
}
