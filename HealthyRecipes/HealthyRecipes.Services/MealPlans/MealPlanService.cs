using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Services.MealPlans.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.MealPlans
{
    /// <summary>
    /// Service for managing MealPlan entities with nutrition recalculation.
    /// </summary>
    public class MealPlanService : IMealPlan
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<MealPlanService> _logger;

        public MealPlanService(
            HealthyRecipesDbContext context,
            ILogger<MealPlanService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<Guid> CreateMealPlanAsync(MealPlan mealPlan)
        {
            if (mealPlan == null)
                throw new ArgumentNullException(nameof(mealPlan));

            try
            {
                _context.MealPlans.Add(mealPlan);
                await _context.SaveChangesAsync();

                _logger.LogInformation("MealPlan created: {MealPlanName} (ID: {MealPlanId})", 
                    mealPlan.Name, mealPlan.Id);
                return mealPlan.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating meal plan: {MealPlanName}", mealPlan.Name);
                throw;
            }
        }

        public async Task<MealPlan?> GetByIdAsync(Guid id)
        {
            try
            {
                return await _context.MealPlans
                    .Include(m => m.MealPlanDays)
                        .ThenInclude(d => d.Meals)
                            .ThenInclude(meal => meal.RecipeMeals)
                                .ThenInclude(rm => rm.Recipe)
                    .Include(m => m.User)
                    .Include(m => m.SavedMealPlans)
                    .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meal plan with ID: {MealPlanId}", id);
                throw;
            }
        }

        public async Task<IEnumerable<MealPlan>> GetMealPlansByUserAsync(Guid userId)
        {
            try
            {
                return await _context.MealPlans
                    .Include(m => m.MealPlanDays)
                    .Where(m => m.UserId == userId && !m.Deleted)
                    .OrderByDescending(m => m.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving meal plans for user: {UserId}", userId);
                throw;
            }
        }

        public async Task<bool> UpdateMealPlanAsync(MealPlan mealPlan)
        {
            if (mealPlan == null)
                throw new ArgumentNullException(nameof(mealPlan));

            try
            {
                var existing = await _context.MealPlans
                    .FirstOrDefaultAsync(m => m.Id == mealPlan.Id && !m.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("MealPlan with ID {MealPlanId} not found for update", mealPlan.Id);
                    return false;
                }

                existing.Name = mealPlan.Name;
                existing.Description = mealPlan.Description;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("MealPlan {MealPlanId} updated successfully", mealPlan.Id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating meal plan with ID: {MealPlanId}", mealPlan.Id);
                throw;
            }
        }

        public async Task<bool> SoftDeleteAsync(Guid id)
        {
            try
            {
                var existing = await _context.MealPlans
                    .FirstOrDefaultAsync(m => m.Id == id && !m.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("MealPlan with ID {MealPlanId} not found for deletion", id);
                    return false;
                }

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("MealPlan {MealPlanId} soft deleted successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error soft deleting meal plan with ID: {MealPlanId}", id);
                throw;
            }
        }

        public async Task<bool> RestoreMealPlanAsync(Guid id)
        {
            try
            {
                var existing = await _context.MealPlans
                    .FirstOrDefaultAsync(m => m.Id == id && m.Deleted);

                if (existing == null)
                {
                    _logger.LogWarning("Deleted MealPlan with ID {MealPlanId} not found for restoration", id);
                    return false;
                }

                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("MealPlan {MealPlanId} restored successfully", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error restoring meal plan with ID: {MealPlanId}", id);
                throw;
            }
        }

        public async Task RecalculateNutritionalTotalsAsync(Guid mealPlanId)
        {
            try
            {
                var mealPlan = await _context.MealPlans
                    .Include(mp => mp.MealPlanDays)
                    .FirstOrDefaultAsync(mp => mp.Id == mealPlanId && !mp.Deleted);

                if (mealPlan == null)
                {
                    _logger.LogWarning("MealPlan with ID {MealPlanId} not found for nutrition recalculation", mealPlanId);
                    return;
                }

                var activeDays = mealPlan.MealPlanDays.Where(d => !d.Deleted).ToList();

                mealPlan.Calories = activeDays.Sum(d => d.Calories);
                mealPlan.Protein = activeDays.Sum(d => d.Protein);
                mealPlan.Carbs = activeDays.Sum(d => d.Carbs);
                mealPlan.Fat = activeDays.Sum(d => d.Fat);
                mealPlan.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();

                _logger.LogInformation("MealPlan {MealPlanId} nutrition recalculated successfully", mealPlanId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error recalculating nutrition for meal plan: {MealPlanId}", mealPlanId);
                throw;
            }
        }

        public async Task<(List<MealPlan> MealPlans, int TotalCount)> GetFilteredMealPlansAsync(MealPlanFilterDto filter)
        {
            if (filter == null)
                throw new ArgumentNullException(nameof(filter));

            try
            {
                var query = _context.MealPlans
                    .Include(mp => mp.MealPlanDays)
                        .ThenInclude(mpd => mpd.Meals)
                            .ThenInclude(m => m.RecipeMeals)
                                .ThenInclude(rm => rm.Recipe)
                    .Include(mp => mp.MealPlanCategories)
                        .ThenInclude(mpc => mpc.Category)
                    .Include(mp => mp.User)
                    .Where(mp => !mp.Deleted)
                    .AsQueryable();

                // Search term - search in Name and Description
                if (!string.IsNullOrWhiteSpace(filter.SearchTerm))
                {
                    var searchLower = filter.SearchTerm.ToLower();
                    query = query.Where(mp =>
                        mp.Name.ToLower().Contains(searchLower) ||
                        (mp.Description != null && mp.Description.ToLower().Contains(searchLower)));
                }

                // Number of days filter
                if (filter.MinDays.HasValue)
                    query = query.Where(mp => mp.MealPlanDays.Count() >= filter.MinDays.Value);

                if (filter.MaxDays.HasValue)
                    query = query.Where(mp => mp.MealPlanDays.Count() <= filter.MaxDays.Value);

                // Daily macronutrient filters (per day average)
                if (filter.MinCaloriesPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Calories / mp.MealPlanDays.Count()) >= filter.MinCaloriesPerDay.Value);
                }

                if (filter.MaxCaloriesPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Calories / mp.MealPlanDays.Count()) <= filter.MaxCaloriesPerDay.Value);
                }

                if (filter.MinProteinPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Protein / mp.MealPlanDays.Count()) >= filter.MinProteinPerDay.Value);
                }

                if (filter.MaxProteinPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Protein / mp.MealPlanDays.Count()) <= filter.MaxProteinPerDay.Value);
                }

                if (filter.MinCarbsPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Carbs / mp.MealPlanDays.Count()) >= filter.MinCarbsPerDay.Value);
                }

                if (filter.MaxCarbsPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Carbs / mp.MealPlanDays.Count()) <= filter.MaxCarbsPerDay.Value);
                }

                if (filter.MinFatPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Fat / mp.MealPlanDays.Count()) >= filter.MinFatPerDay.Value);
                }

                if (filter.MaxFatPerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.Any() &&
                        (mp.Fat / mp.MealPlanDays.Count()) <= filter.MaxFatPerDay.Value);
                }

                // Max preparation time per day
                if (filter.MaxPreparationTimePerDay.HasValue)
                {
                    query = query.Where(mp => mp.MealPlanDays.All(mpd =>
                        mpd.Meals.Sum(m => m.RecipeMeals.Sum(rm => rm.Recipe.PrepTime ?? 0)) <= filter.MaxPreparationTimePerDay.Value));
                }

                // Categories - meal plan must belong to at least one selected category
                if (filter.CategoryIds?.Any() == true)
                {
                    query = query.Where(mp => mp.MealPlanCategories
                        .Any(mpc => filter.CategoryIds.Contains(mpc.CategoryId) && !mpc.Deleted));
                }

                // Total count before pagination
                var totalCount = await query.CountAsync();

                // Sorting
                query = filter.SortBy?.ToLower() switch
                {
                    "calories" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.Calories)
                        : query.OrderByDescending(mp => mp.Calories),
                    "protein" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.Protein)
                        : query.OrderByDescending(mp => mp.Protein),
                    "carbs" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.Carbs)
                        : query.OrderByDescending(mp => mp.Carbs),
                    "fat" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.Fat)
                        : query.OrderByDescending(mp => mp.Fat),
                    "days" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.MealPlanDays.Count())
                        : query.OrderByDescending(mp => mp.MealPlanDays.Count()),
                    "name" => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.Name)
                        : query.OrderByDescending(mp => mp.Name),
                    _ => filter.SortOrder?.ToLower() == "asc"
                        ? query.OrderBy(mp => mp.CreatedAt)
                        : query.OrderByDescending(mp => mp.CreatedAt)
                };

                // Pagination
                var mealPlans = await query
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToListAsync();

                _logger.LogInformation("Retrieved {Count} meal plans out of {Total} with filters", mealPlans.Count, totalCount);

                return (mealPlans, totalCount);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting filtered meal plans");
                throw;
            }
        }
    }
}
