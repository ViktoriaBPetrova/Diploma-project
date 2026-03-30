using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Models;

namespace HealthyRecipes.Services.Admin.Interfaces
{
    public interface IContentFilter
    {
        /// <summary>
        /// Check if content contains banned words
        /// </summary>
        Task<ContentFilterResult> CheckContentAsync(string content);

        /// <summary>
        /// Get all banned words
        /// </summary>
        Task<IEnumerable<BannedWordDto>> GetAllBannedWordsAsync();

        /// <summary>
        /// Get active banned words for filtering
        /// </summary>
        Task<IEnumerable<BannedWordDto>> GetActiveBannedWordsAsync();

        /// <summary>
        /// Add a new banned word
        /// </summary>
        Task<Guid> AddBannedWordAsync(string word, WordSeverity severity, Guid adminUserId, bool isRegex = false, string? description = null);

        /// <summary>
        /// Update a banned word
        /// </summary>
        Task UpdateBannedWordAsync(Guid id, string word, WordSeverity severity, bool isRegex = false, string? description = null);

        /// <summary>
        /// Delete a banned word
        /// </summary>
        Task DeleteBannedWordAsync(Guid id);

        /// <summary>
        /// Toggle banned word active status
        /// </summary>
        Task ToggleBannedWordStatusAsync(Guid id);
    }
}
