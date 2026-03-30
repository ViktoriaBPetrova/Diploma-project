using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Admin
{
    public class UserModerationService : IUserModeration
    {
        private readonly HealthyRecipesDbContext _context;
        private const int AUTO_BAN_WARNING_THRESHOLD = 3;

        public UserModerationService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> IssueWarningAsync(
            Guid userId,
            Guid adminUserId,
            WarningType type,
            string reason,
            Guid? relatedFlaggedContentId = null,
            DateTime? expiresAt = null)
        {
            var warning = new UserWarning
            {
                UserId = userId,
                IssuedByAdminId = adminUserId,
                Type = type,
                Reason = reason,
                RelatedFlaggedContentId = relatedFlaggedContentId,
                ExpiresAt = expiresAt
            };

            _context.UserWarnings.Add(warning);
            await _context.SaveChangesAsync();

            return warning.Id;
        }

        public async Task<IEnumerable<UserWarningDto>> GetUserWarningsAsync(Guid userId, bool activeOnly = false)
        {
            var query = _context.UserWarnings
                .Include(w => w.User)
                .Include(w => w.IssuedByAdmin)
                .Include(w => w.RelatedFlaggedContent)
                .Where(w => w.UserId == userId);

            if (activeOnly)
                query = query.Where(w => w.IsActive);

            var warnings = await query
                .OrderByDescending(w => w.CreatedAt)
                .ToListAsync();

            return warnings.Select(MapToDto);
        }

        public async Task<int> GetActiveWarningCountAsync(Guid userId)
        {
            return await _context.UserWarnings
                .CountAsync(w => w.UserId == userId && w.IsActive);
        }

        public async Task DeactivateWarningAsync(Guid warningId)
        {
            var warning = await _context.UserWarnings.FindAsync(warningId);
            if (warning == null) return;

            warning.IsActive = false;
            await _context.SaveChangesAsync();
        }

        public async Task<bool> ShouldAutoBanAsync(Guid userId)
        {
            var activeWarningCount = await GetActiveWarningCountAsync(userId);
            return activeWarningCount >= AUTO_BAN_WARNING_THRESHOLD;
        }

        public async Task<(IEnumerable<UserWarningDto> Warnings, int TotalCount)> GetAllWarningsAsync(
            int page = 1,
            int pageSize = 50,
            WarningType? type = null,
            bool? isActive = null)
        {
            var query = _context.UserWarnings
                .Include(w => w.User)
                .Include(w => w.IssuedByAdmin)
                .Include(w => w.RelatedFlaggedContent)
                .AsQueryable();

            if (type.HasValue)
                query = query.Where(w => w.Type == type.Value);

            if (isActive.HasValue)
                query = query.Where(w => w.IsActive == isActive.Value);

            var totalCount = await query.CountAsync();

            var warnings = await query
                .OrderByDescending(w => w.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map entities to DTOs
            var dtos = warnings.Select(MapToDto);

            return (dtos, totalCount);
        }

        // Private helper: Map entity to DTO
        private UserWarningDto MapToDto(UserWarning entity)
        {
            return new UserWarningDto
            {
                Id = entity.Id,
                Type = entity.Type,
                Reason = entity.Reason,
                IssuedByAdminName = entity.IssuedByAdmin?.UserName ?? "System",
                CreatedAt = entity.CreatedAt,
                ExpiresAt = entity.ExpiresAt,
                IsActive = entity.IsActive,
                RelatedFlaggedContentId = entity.RelatedFlaggedContentId
            };
        }
    }
}
