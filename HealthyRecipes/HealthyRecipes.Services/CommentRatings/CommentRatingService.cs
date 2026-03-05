using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.CommentRatings
{
    public class CommentRatingService : ICommentRating
    {
        private readonly HealthyRecipesDbContext _context;

        public CommentRatingService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new comment/rating or updates an existing one for the user + recipe pair.
        /// </summary>
        public async Task AddOrUpdateCommentRatingAsync(Guid userId, Guid recipeId, Rating rating, string? comment)
        {
            var existing = await _context.CommentRatings
                .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId);

            if (existing != null)
            {
                existing.Deleted = false;
                existing.DeletedAt = null;
                existing.Rating = rating;
                existing.Comment = comment;
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
        }

        public async Task<CommentRating?> GetCommentRatingAsync(Guid userId, Guid recipeId)
        {
            return await _context.CommentRatings
                .Include(cr => cr.User)
                .Include(cr => cr.Recipe)
                .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && !cr.Deleted);
        }

        public async Task<IEnumerable<CommentRating>> GetRatingsByRecipeAsync(Guid recipeId)
        {
            return await _context.CommentRatings
                .Include(cr => cr.User)
                .Where(cr => cr.RecipeId == recipeId && !cr.Deleted)
                .OrderByDescending(cr => cr.CreatedAt)
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentRating>> GetRatingsByUserAsync(Guid userId)
        {
            return await _context.CommentRatings
                .Include(cr => cr.Recipe)
                .Where(cr => cr.UserId == userId && !cr.Deleted)
                .OrderByDescending(cr => cr.CreatedAt)
                .ToListAsync();
        }

        public async Task<double> GetAverageRatingAsync(Guid recipeId)
        {
            var ratings = await _context.CommentRatings
                .Where(cr => cr.RecipeId == recipeId && !cr.Deleted)
                .ToListAsync();

            if (!ratings.Any())
                return 0;

            return ratings.Average(cr => (int)cr.Rating);
        }

        public async Task<bool> RemoveCommentRatingAsync(Guid userId, Guid recipeId)
        {
            var existing = await _context.CommentRatings
                .FirstOrDefaultAsync(cr => cr.UserId == userId && cr.RecipeId == recipeId && !cr.Deleted);

            if (existing == null)
                return false;

            existing.Deleted = true;
            existing.DeletedAt = DateTime.UtcNow;
            existing.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
