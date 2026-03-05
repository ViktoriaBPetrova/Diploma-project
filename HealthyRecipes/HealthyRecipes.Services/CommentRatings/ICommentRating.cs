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
    }
}
