using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthyRecipes.Services.Admin
{
    public class FlaggedContentService : IFlaggedContent
    {
        private readonly HealthyRecipesDbContext _context;

        public FlaggedContentService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> FlagContentAsync(
            string contentType,
            Guid contentId,
            string contentPreview,
            Guid contentAuthorId,
            FlagReason reason,
            string? details = null,
            Guid? reportedByUserId = null,
            string? matchedBannedWords = null)
        {
            // Check if already flagged and pending
            var existingFlag = await _context.FlaggedContents
                .FirstOrDefaultAsync(f => f.ContentType == contentType 
                    && f.ContentId == contentId 
                    && f.Status == FlagStatus.Pending);

            if (existingFlag != null)
                return existingFlag.Id;

            var flaggedContent = new FlaggedContent
            {
                ContentType = contentType,
                ContentId = contentId,
                ContentPreview = contentPreview.Length > 500 ? contentPreview.Substring(0, 500) : contentPreview,
                ContentAuthorId = contentAuthorId,
                Reason = reason,
                Details = details,
                ReportedByUserId = reportedByUserId,
                MatchedBannedWords = matchedBannedWords
            };

            _context.FlaggedContents.Add(flaggedContent);
            await _context.SaveChangesAsync();

            return flaggedContent.Id;
        }

        public async Task<(IEnumerable<FlaggedContentDto> Items, int TotalCount)> GetFlaggedContentAsync(
            int page = 1,
            int pageSize = 50,
            FlagStatus? status = null,
            FlagReason? reason = null,
            string? contentType = null)
        {
            var query = _context.FlaggedContents
                .Include(f => f.ContentAuthor)
                .Include(f => f.ReportedBy)
                .Include(f => f.ReviewedByAdmin)
                .AsQueryable();

            if (status.HasValue)
                query = query.Where(f => f.Status == status.Value);

            if (reason.HasValue)
                query = query.Where(f => f.Reason == reason.Value);

            if (!string.IsNullOrEmpty(contentType))
                query = query.Where(f => f.ContentType == contentType);

            var totalCount = await query.CountAsync();

            var items = await query
                .OrderByDescending(f => f.CreatedAt)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            // Map entities to DTOs
            var dtos = items.Select(MapToDto);

            return (dtos, totalCount);
        }

        public async Task<int> GetPendingCountAsync()
        {
            return await _context.FlaggedContents
                .CountAsync(f => f.Status == FlagStatus.Pending);
        }

        public async Task<FlaggedContentDto?> GetByIdAsync(Guid id)
        {
            var entity = await _context.FlaggedContents
                .Include(f => f.ContentAuthor)
                .Include(f => f.ReportedBy)
                .Include(f => f.ReviewedByAdmin)
                .FirstOrDefaultAsync(f => f.Id == id);

            return entity == null ? null : MapToDto(entity);
        }

        public async Task ResolveAsync(Guid id, Guid adminUserId, FlagResolution resolution, string? adminNotes = null)
        {
            var flaggedContent = await _context.FlaggedContents.FindAsync(id);
            if (flaggedContent == null) return;

            flaggedContent.Status = FlagStatus.Resolved;
            flaggedContent.Resolution = resolution;
            flaggedContent.ReviewedByAdminId = adminUserId;
            flaggedContent.ReviewedAt = DateTime.UtcNow;
            flaggedContent.AdminNotes = adminNotes;
            flaggedContent.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task DismissAsync(Guid id, Guid adminUserId, string? adminNotes = null)
        {
            var flaggedContent = await _context.FlaggedContents.FindAsync(id);
            if (flaggedContent == null) return;

            flaggedContent.Status = FlagStatus.Dismissed;
            flaggedContent.ReviewedByAdminId = adminUserId;
            flaggedContent.ReviewedAt = DateTime.UtcNow;
            flaggedContent.AdminNotes = adminNotes;
            flaggedContent.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsContentFlaggedAsync(string contentType, Guid contentId)
        {
            return await _context.FlaggedContents
                .AnyAsync(f => f.ContentType == contentType 
                    && f.ContentId == contentId 
                    && f.Status == FlagStatus.Pending);
        }

        // Private helper: Map entity to DTO
        private FlaggedContentDto MapToDto(FlaggedContent entity)
        {
            return new FlaggedContentDto
            {
                Id = entity.Id,
                ContentType = entity.ContentType,
                ContentId = entity.ContentId,
                ContentPreview = entity.ContentPreview,
                ContentAuthorName = entity.ContentAuthor?.UserName ?? "Unknown",
                ContentAuthorEmail = entity.ContentAuthor?.Email ?? "N/A",
                Reason = entity.Reason,
                Details = entity.Details,
                MatchedBannedWords = entity.MatchedBannedWords,
                ReportedByUserName = entity.ReportedBy?.UserName,
                Status = entity.Status,
                Resolution = entity.Resolution,
                IsAutoFlagged = entity.ReportedByUserId == null
            };
        }
    }
}
