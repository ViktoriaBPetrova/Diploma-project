using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Models;

namespace HealthyRecipes.Services.Admin.Interfaces
{
    public interface IFlaggedContent
    {
        /// <summary>
        /// Flag content for admin review
        /// </summary>
        Task<Guid> FlagContentAsync(
            string contentType,
            Guid contentId,
            string contentPreview,
            Guid contentAuthorId,
            FlagReason reason,
            string? details = null,
            Guid? reportedByUserId = null,
            string? matchedBannedWords = null);

        /// <summary>
        /// Get all flagged content with filtering
        /// </summary>
        Task<(IEnumerable<FlaggedContentDto> Items, int TotalCount)> GetFlaggedContentAsync(
            int page = 1,
            int pageSize = 50,
            FlagStatus? status = null,
            FlagReason? reason = null,
            string? contentType = null);

        /// <summary>
        /// Get pending flagged content count
        /// </summary>
        Task<int> GetPendingCountAsync();

        /// <summary>
        /// Get flagged content by ID
        /// </summary>
        Task<FlaggedContentDto?> GetByIdAsync(Guid id);

        /// <summary>
        /// Review and resolve flagged content
        /// </summary>
        Task ResolveAsync(Guid id, Guid adminUserId, FlagResolution resolution, string? adminNotes = null);

        /// <summary>
        /// Dismiss flagged content
        /// </summary>
        Task DismissAsync(Guid id, Guid adminUserId, string? adminNotes = null);

        /// <summary>
        /// Check if content is already flagged
        /// </summary>
        Task<bool> IsContentFlaggedAsync(string contentType, Guid contentId);
    }
}
