using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Enums;

namespace HealthyRecipes.Services.CommentRatings
{
    public interface ICommentRating
    {
        Task AddOrUpdateCommentRatingAsync(Guid userId, Guid recipeId, Rating rating, string? comment);
        Task<CommentRating?> GetCommentRatingAsync(Guid userId, Guid recipeId);
        Task<IEnumerable<CommentRating>> GetRatingsByRecipeAsync(Guid recipeId);
        Task<IEnumerable<CommentRating>> GetRatingsByUserAsync(Guid userId);
        Task<double> GetAverageRatingAsync(Guid recipeId);
        Task<bool> RemoveCommentRatingAsync(Guid userId, Guid recipeId);

        // New methods for threaded comments
        Task<Guid> AddReplyAsync(Guid parentCommentId, Guid userId, string content);
        Task<bool> UpdateCommentAsync(Guid commentId, Guid userId, string content);
        Task<bool> DeleteCommentAsync(Guid commentId, Guid userId);
        Task<IEnumerable<CommentRating>> GetTopLevelCommentsWithRepliesAsync(Guid recipeId);
        Task<bool> TogglePinAsync(Guid commentId, Guid recipeOwnerId);
        Task<int> GetTotalCommentCountAsync(Guid recipeId);
    }
}
