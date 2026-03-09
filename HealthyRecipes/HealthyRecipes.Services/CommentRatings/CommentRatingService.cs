using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HealthyRecipes.Services.CommentRatings
{
    public class CommentRatingService : ICommentRating
    {
        private readonly HealthyRecipesDbContext _context;
        private readonly ILogger<CommentRatingService> _logger;

        public CommentRatingService(HealthyRecipesDbContext context, ILogger<CommentRatingService> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task AddOrUpdateCommentRatingAsync(Guid userId, Guid recipeId, Rating rating, string? comment)
        {
            try
            {
                var existing = await _context.CommentRatings
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId);

                if (existing != null)
                {
                    existing.Rating = rating;
                    existing.Comment = comment;
                    existing.Deleted = false;
                    existing.DeletedAt = null;
                    existing.UpdatedAt = DateTime.UtcNow;
                }
                else
                {
                    _context.CommentRatings.Add(new CommentRating
                    {
                        UserId = userId,
                        RecipeId = recipeId,
                        Rating = rating,
                        Comment = comment
                    });
                }

                await _context.SaveChangesAsync();
                _logger.LogInformation("Comment/rating added for user {UserId} on recipe {RecipeId}", userId, recipeId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding/updating comment rating");
                throw;
            }
        }

        public async Task<CommentRating?> GetCommentRatingAsync(Guid userId, Guid recipeId)
        {
            try
            {
                return await _context.CommentRatings
                    .Include(cr => cr.User)
                    .Include(cr => cr.Recipe)
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && !cr.Deleted);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving comment rating");
                throw;
            }
        }

        public async Task<IEnumerable<CommentRating>> GetRatingsByRecipeAsync(Guid recipeId)
        {
            try
            {
                return await _context.CommentRatings
                    .Include(cr => cr.User)
                    .Where(cr => cr.RecipeId == recipeId && !cr.Deleted)
                    .OrderByDescending(cr => cr.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ratings for recipe: {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<IEnumerable<CommentRating>> GetRatingsByUserAsync(Guid userId)
        {
            try
            {
                return await _context.CommentRatings
                    .Include(cr => cr.Recipe)
                    .Where(cr => cr.UserId == userId && !cr.Deleted)
                    .OrderByDescending(cr => cr.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving ratings for user: {UserId}", userId);
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

                return ratings.Any() ? ratings.Average() : 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error calculating average rating for recipe: {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<bool> RemoveCommentRatingAsync(Guid userId, Guid recipeId)
        {
            try
            {
                var existing = await _context.CommentRatings
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && !cr.Deleted);

                if (existing == null) return false;

                existing.Deleted = true;
                existing.DeletedAt = DateTime.UtcNow;
                existing.UpdatedAt = DateTime.UtcNow;
                await _context.SaveChangesAsync();
                _logger.LogInformation("Comment/rating removed for user {UserId} on recipe {RecipeId}", userId, recipeId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error removing comment rating");
                throw;
            }
        }
    }
}
