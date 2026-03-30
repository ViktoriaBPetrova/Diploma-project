using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Models;

namespace HealthyRecipes.Services.Admin.Interfaces
{
    public interface IActivityLog
    {
        /// <summary>
        /// Log an activity action
        /// </summary>
        Task LogAsync(
            Guid? userId,
            ActivityType activityType,
            string entityType,
            Guid? entityId,
            string entityName,
            string? oldValue = null,
            string? newValue = null,
            string? changesSummary = null,
            LogSeverity severity = LogSeverity.Info,
            string? ipAddress = null,
            string? userAgent = null);

        /// <summary>
        /// Get activity logs with filtering and pagination
        /// </summary>
        Task<(IEnumerable<ActivityLogDto> Logs, int TotalCount)> GetLogsAsync(
            int page = 1,
            int pageSize = 50,
            Guid? userId = null,
            ActivityType? activityType = null,
            string? entityType = null,
            LogSeverity? severity = null,
            DateTime? fromDate = null,
            DateTime? toDate = null);

        /// <summary>
        /// Get logs for a specific entity
        /// </summary>
        Task<IEnumerable<ActivityLogDto>> GetEntityHistoryAsync(string entityType, Guid entityId);

        /// <summary>
        /// Get recent activity for dashboard
        /// </summary>
        Task<IEnumerable<ActivityLogDto>> GetRecentActivityAsync(int count = 10);

        /// <summary>
        /// Get activity count by severity (for stats)
        /// </summary>
        Task<Dictionary<LogSeverity, int>> GetActivityCountBySeverityAsync(DateTime? fromDate = null);
    }
}
