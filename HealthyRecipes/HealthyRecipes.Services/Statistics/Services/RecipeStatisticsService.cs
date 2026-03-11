using HealthyRecipes.Data;
using HealthyRecipes.Data.Enums;
using HealthyRecipes.Services.Statistics.Interfaces;
using HealthyRecipes.Services.Statistics.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.Statistics.Services
{
    public class RecipeStatisticsService : IRecipeStatistics
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<RecipeStatisticsService> _logger;

        public RecipeStatisticsService(
            HealthyRecipesDbContext context, 
            ILogger<RecipeStatisticsService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<RecipeStatisticsDto?> GetRecipeStatisticsAsync(Guid recipeId)
        {
            try
            {
                var recipe = await _context.Recipes
                    .Where(r => r.Id == recipeId && !r.Deleted)
                    .Select(r => new
                    {
                        r.Id,
                        r.Title
                    })
                    .FirstOrDefaultAsync();

                if (recipe == null)
                {
                    _logger.LogWarning("Recipe {RecipeId} not found", recipeId);
                    return null;
                }

                var saveCount = await GetSaveCountAsync(recipeId);
                var averageRating = await GetAverageRatingAsync(recipeId);
                var commentCount = await GetCommentCountAsync(recipeId);
                var mealPlanUsageCount = await GetMealPlanUsageCountAsync(recipeId);

                var ratingCount = await _context.CommentRatings
                    .CountAsync(cr => cr.RecipeId == recipeId && !cr.Deleted);

                return new RecipeStatisticsDto
                {
                    RecipeId = recipe.Id,
                    RecipeTitle = recipe.Title ?? "Untitled Recipe",
                    SaveCount = saveCount,
                    AverageRating = averageRating,
                    CommentCount = commentCount,
                    RatingCount = ratingCount,
                    MealPlanUsageCount = mealPlanUsageCount
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting statistics for recipe {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<int> GetSaveCountAsync(Guid recipeId)
        {
            try
            {
                return await _context.SavedRecipes
                    .CountAsync(sr => sr.RecipeId == recipeId && !sr.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting save count for recipe {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<double> GetAverageRatingAsync(Guid recipeId)
        {
            try
            {
                var ratings = await _context.CommentRatings
                    .Where(cr => cr.RecipeId == recipeId && !cr.Deleted)
                    .Select(cr => (int)cr.Rating)
                    .ToListAsync();

                if (!ratings.Any())
                    return 0;

                return ratings.Average();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting average rating for recipe {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<int> GetCommentCountAsync(Guid recipeId)
        {
            try
            {
                return await _context.CommentRatings
                    .CountAsync(cr => cr.RecipeId == recipeId 
                                     && !cr.Deleted 
                                     && !string.IsNullOrWhiteSpace(cr.Comment));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting comment count for recipe {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<int> GetMealPlanUsageCountAsync(Guid recipeId)
        {
            try
            {
                // Get distinct meal plan IDs that use this recipe
                var mealPlanIds = await _context.RecipeMeals
                    .Where(rm => rm.RecipeId == recipeId && !rm.Deleted)
                    .Join(_context.Meals,
                        rm => rm.MealId,
                        m => m.Id,
                        (rm, m) => m)
                    .Where(m => !m.Deleted)
                    .Join(_context.MealPlanDays,
                        m => m.MealPlanDayId,
                        mpd => mpd.Id,
                        (m, mpd) => mpd)
                    .Where(mpd => !mpd.Deleted)
                    .Select(mpd => mpd.MealPlanId)
                    .Distinct()
                    .ToListAsync();

                // Count only non-deleted meal plans
                return await _context.MealPlans
                    .CountAsync(mp => mealPlanIds.Contains(mp.Id) && !mp.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting meal plan usage count for recipe {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<IEnumerable<Guid>> GetUsersWhoSavedAsync(Guid recipeId)
        {
            try
            {
                return await _context.SavedRecipes
                    .Where(sr => sr.RecipeId == recipeId && !sr.Deleted)
                    .Select(sr => sr.UserId)
                    .Distinct()
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting users who saved recipe {RecipeId}", recipeId);
                throw;
            }
        }
    }
}
