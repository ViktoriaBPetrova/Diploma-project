using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Admin
{
    public class ActivityLogService : IActivityLog
    {
        private readonly HealthyRecipesDbContext _context;

        public ActivityLogService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task LogAsync(
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
            string? userAgent = null)
        {
            var log = new ActivityLog
            {
                UserId = userId,
                ActivityType = activityType,
                EntityType = entityType,
                EntityId = entityId,
                EntityName = entityName,
                OldValue = oldValue,
                NewValue = newValue,
                ChangesSummary = changesSummary,
                Severity = severity,
                IpAddress = ipAddress,
                UserAgent = userAgent
            };

            _context.ActivityLogs.Add(log);
            await _context.SaveChangesAsync();
        }

        public async Task<(IEnumerable<ActivityLogDto> Logs, int TotalCount)> GetLogsAsync(
            int page = 1,
            int pageSize = 50,
            Guid? userId = null,
            ActivityType? activityType = null,
            string? entityType = null,
            LogSeverity? severity = null,
            DateTime? fromDate = null,
            DateTime? toDate = null)
        {
            var query = _context.ActivityLogs
                .Include(a => a.User)
                .AsQueryable();

            // Apply filters
            if (userId.HasValue)
                query = query.Where(a => a.UserId == userId.Value);

            if (activityType.HasValue)
                query = query.Where(a => a.ActivityType == activityType.Value);

            if (!string.IsNullOrEmpty(entityType))
                query = query.Where(a => a.EntityType == entityType);

            if (severity.HasValue)
                query = query.Where(a => a.Severity == severity.Value);

            if (fromDate.HasValue)
                query = query.Where(a => a.CreatedAt >= fromDate.Value);

            if (toDate.HasValue)
                query = query.Where(a => a.CreatedAt <= toDate.Value);

            var totalCount = await query.CountAsync();

            var logs = await query
                .OrderByDescending(a => a.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map entities to DTOs
            var dtos = logs.Select(MapToDto);

            return (dtos, totalCount);
        }

        public async Task<IEnumerable<ActivityLogDto>> GetEntityHistoryAsync(string entityType, Guid entityId)
        {
            var logs = await _context.ActivityLogs
                .Include(a => a.User)
                .Where(a => a.EntityType == entityType && a.EntityId == entityId)
                .OrderByDescending(a => a.CreatedAt)
                .ToListAsync();

            return logs.Select(MapToDto);
        }

        public async Task<IEnumerable<ActivityLogDto>> GetRecentActivityAsync(int count = 10)
        {
            var logs = await _context.ActivityLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedAt)
                .Take(count)
                .ToListAsync();

            return logs.Select(MapToDto);
        }

        public async Task<Dictionary<LogSeverity, int>> GetActivityCountBySeverityAsync(DateTime? fromDate = null)
        {
            var query = _context.ActivityLogs.AsQueryable();

            if (fromDate.HasValue)
                query = query.Where(a => a.CreatedAt >= fromDate.Value);

            return await query
                .GroupBy(a => a.Severity)
                .Select(g => new { Severity = g.Key, Count = g.Count() })
                .ToDictionaryAsync(x => x.Severity, x => x.Count);
        }

        // Private helper: Map entity to DTO
        private ActivityLogDto MapToDto(ActivityLog entity)
        {
            return new ActivityLogDto
            {
                Id = entity.Id,
                UserName = entity.User?.UserName ?? "System",
                UserEmail = entity.User?.Email ?? "N/A",
                ActivityType = entity.ActivityType,
                EntityType = entity.EntityType,
                EntityId = entity.EntityId,
                EntityName = entity.EntityName,
                ChangesSummary = entity.ChangesSummary,
                Severity = entity.Severity,
                IpAddress = entity.IpAddress,
                CreatedAt = entity.CreatedAt,
                HasDetails = !string.IsNullOrEmpty(entity.OldValue) || !string.IsNullOrEmpty(entity.NewValue)
            };
        }
    }
}
