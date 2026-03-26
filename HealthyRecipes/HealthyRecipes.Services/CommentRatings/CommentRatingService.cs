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
                // Find existing top-level comment/rating (no parent)
                var existing = await _context.CommentRatings
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && cr.ParentCommentId == null);

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
                        Id = Guid.NewGuid(),
                        UserId = userId,
                        RecipeId = recipeId,
                        Rating = rating,
                        Comment = comment,
                        ParentCommentId = null
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
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && cr.ParentCommentId == null && !cr.Deleted);
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
                    .Where(cr => cr.RecipeId == recipeId && cr.ParentCommentId == null && !cr.Deleted)
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
                    .Where(cr => cr.UserId == userId && cr.ParentCommentId == null && !cr.Deleted)
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
                    .Where(cr => cr.RecipeId == recipeId && cr.ParentCommentId == null && cr.Rating.HasValue && !cr.Deleted)
                    .Select(cr => (int)cr.Rating!.Value)
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
                    .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && cr.ParentCommentId == null && !cr.Deleted);

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

        // NEW METHODS FOR THREADED COMMENTS

        public async Task<Guid> AddReplyAsync(Guid parentCommentId, Guid userId, string content)
        {
            try
            {
                var parent = await _context.CommentRatings
                    .Include(cr => cr.Recipe)
                    .FirstOrDefaultAsync(cr => cr.Id == parentCommentId && !cr.Deleted);

                if (parent == null)
                    throw new InvalidOperationException("Parent comment not found");

                var reply = new CommentRating
                {
                    Id = Guid.NewGuid(),
                    RecipeId = parent.RecipeId,
                    UserId = userId,
                    Comment = content,
                    Rating = null, // Replies don't have ratings
                    ParentCommentId = parentCommentId
                };

                _context.CommentRatings.Add(reply);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Reply {ReplyId} added by user {UserId} to comment {ParentId}", reply.Id, userId, parentCommentId);
                return reply.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding reply");
                throw;
            }
        }

        public async Task<bool> UpdateCommentAsync(Guid commentId, Guid userId, string content)
        {
            try
            {
                var comment = await _context.CommentRatings
                    .FirstOrDefaultAsync(cr => cr.Id == commentId && cr.UserId == userId && !cr.Deleted);

                if (comment == null)
                    return false;

                comment.Comment = content;
                comment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Comment {CommentId} updated by user {UserId}", commentId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating comment");
                throw;
            }
        }

        public async Task<bool> DeleteCommentAsync(Guid commentId, Guid userId)
        {
            try
            {
                var comment = await _context.CommentRatings
                    .FirstOrDefaultAsync(cr => cr.Id == commentId && cr.UserId == userId && !cr.Deleted);

                if (comment == null)
                    return false;

                comment.Deleted = true;
                comment.DeletedAt = DateTime.UtcNow;
                comment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Comment {CommentId} deleted by user {UserId}", commentId, userId);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting comment");
                throw;
            }
        }

        public async Task<IEnumerable<CommentRating>> GetTopLevelCommentsWithRepliesAsync(Guid recipeId)
        {
            try
            {
                return await _context.CommentRatings
                    .Include(cr => cr.User)
                    .Include(cr => cr.Replies.Where(r => !r.Deleted))
                        .ThenInclude(r => r.User)
                    .Include(cr => cr.Replies.Where(r => !r.Deleted))
                        .ThenInclude(r => r.Replies.Where(rr => !rr.Deleted))
                            .ThenInclude(rr => rr.User)
                    .Where(cr => cr.RecipeId == recipeId && cr.ParentCommentId == null && !cr.Deleted)
                    .OrderByDescending(cr => cr.IsPinned)
                    .ThenByDescending(cr => cr.CreatedAt)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving threaded comments for recipe: {RecipeId}", recipeId);
                throw;
            }
        }

        public async Task<bool> TogglePinAsync(Guid commentId, Guid recipeOwnerId)
        {
            try
            {
                var comment = await _context.CommentRatings
                    .Include(cr => cr.Recipe)
                    .FirstOrDefaultAsync(cr => cr.Id == commentId && !cr.Deleted && cr.ParentCommentId == null);

                if (comment == null || comment.Recipe.UserId != recipeOwnerId)
                    return false;

                comment.IsPinned = !comment.IsPinned;
                comment.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                _logger.LogInformation("Comment {CommentId} pin toggled. IsPinned: {IsPinned}", commentId, comment.IsPinned);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error toggling pin");
                throw;
            }
        }

        public async Task<int> GetTotalCommentCountAsync(Guid recipeId)
        {
            try
            {
                return await _context.CommentRatings
                    .Where(cr => cr.RecipeId == recipeId && !cr.Deleted)
                    .CountAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error counting comments for recipe: {RecipeId}", recipeId);
                throw;
            }
        }
    }
}
