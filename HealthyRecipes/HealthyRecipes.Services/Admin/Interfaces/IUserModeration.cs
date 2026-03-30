using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Models;

namespace HealthyRecipes.Services.Admin.Interfaces
{
    public interface IUserModeration
    {
        /// <summary>
        /// Issue a warning to a user
        /// </summary>
        Task<Guid> IssueWarningAsync(
            Guid userId,
            Guid adminUserId,
            WarningType type,
            string reason,
            Guid? relatedFlaggedContentId = null,
            DateTime? expiresAt = null);

        /// <summary>
        /// Get all warnings for a user
        /// </summary>
        Task<IEnumerable<UserWarningDto>> GetUserWarningsAsync(Guid userId, bool activeOnly = false);

        /// <summary>
        /// Get active warning count for a user
        /// </summary>
        Task<int> GetActiveWarningCountAsync(Guid userId);

        /// <summary>
        /// Deactivate a warning
        /// </summary>
        Task DeactivateWarningAsync(Guid warningId);

        /// <summary>
        /// Check if user should be auto-banned based on warning count
        /// </summary>
        Task<bool> ShouldAutoBanAsync(Guid userId);

        /// <summary>
        /// Get all warnings with filtering
        /// </summary>
        Task<(IEnumerable<UserWarningDto> Warnings, int TotalCount)> GetAllWarningsAsync(
            int page = 1,
            int pageSize = 50,
            WarningType? type = null,
            bool? isActive = null);
    }
}
