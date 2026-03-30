using HealthyRecipes.Data;
using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Services.Admin.Interfaces;
using HealthyRecipes.Services.Admin.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace HealthyRecipes.Services.Admin
{
    public class ContentFilterService : IContentFilter
    {
        private readonly HealthyRecipesDbContext _context;
        private List<BannedWord>? _cachedBannedWords;
        private DateTime _cacheTime = DateTime.MinValue;
        private readonly TimeSpan _cacheExpiration = TimeSpan.FromMinutes(5);

        public ContentFilterService(HealthyRecipesDbContext context)
        {
            _context = context;
        }

        public async Task<ContentFilterResult> CheckContentAsync(string content)
        {
            if (string.IsNullOrWhiteSpace(content))
                return new ContentFilterResult();

            var bannedWords = await GetCachedBannedWordsAsync();
            var result = new ContentFilterResult();

            var contentLower = content.ToLowerInvariant();

            foreach (var bannedWord in bannedWords)
            {
                bool isMatch = false;

                if (bannedWord.IsRegexPattern)
                {
                    try
                    {
                        isMatch = Regex.IsMatch(contentLower, bannedWord.Word, RegexOptions.IgnoreCase);
                    }
                    catch
                    {
                        // Invalid regex, treat as plain text
                        isMatch = contentLower.Contains(bannedWord.Word.ToLowerInvariant());
                    }
                }
                else
                {
                    // Word boundary matching for whole words
                    var pattern = $@"\b{Regex.Escape(bannedWord.Word.ToLowerInvariant())}\b";
                    isMatch = Regex.IsMatch(contentLower, pattern, RegexOptions.IgnoreCase);
                }

                if (isMatch)
                {
                    result.ContainsBannedWords = true;
                    result.MatchedWords.Add(bannedWord.Word);

                    if (bannedWord.Severity > result.HighestSeverity)
                        result.HighestSeverity = bannedWord.Severity;
                }
            }

            // Set action flags based on severity
            if (result.ContainsBannedWords)
            {
                result.ShouldAutoBlock = result.HighestSeverity >= WordSeverity.High;
                result.ShouldFlagForReview = result.HighestSeverity >= WordSeverity.Medium;
            }

            return result;
        }

        public async Task<IEnumerable<BannedWordDto>> GetAllBannedWordsAsync()
        {
            var words = await _context.BannedWords
                .Include(b => b.CreatedBy)
                .OrderBy(b => b.Word)
                .ToListAsync();

            return words.Select(MapToDto);
        }

        public async Task<IEnumerable<BannedWordDto>> GetActiveBannedWordsAsync()
        {
            var words = await _context.BannedWords
                .Where(b => b.IsActive)
                .OrderBy(b => b.Word)
                .ToListAsync(); ;

            return words.Select(MapToDto);
        }

        public async Task<Guid> AddBannedWordAsync(string word, WordSeverity severity, Guid adminUserId, bool isRegex = false, string? description = null)
        {
            var bannedWord = new BannedWord
            {
                Word = word.Trim(),
                Severity = severity,
                CreatedByUserId = adminUserId,
                IsRegexPattern = isRegex,
                Description = description
            };

            _context.BannedWords.Add(bannedWord);
            await _context.SaveChangesAsync();

            // Invalidate cache
            _cachedBannedWords = null;

            return bannedWord.Id;
        }

        public async Task UpdateBannedWordAsync(Guid id, string word, WordSeverity severity, bool isRegex = false, string? description = null)
        {
            var bannedWord = await _context.BannedWords.FindAsync(id);
            if (bannedWord == null) return;

            bannedWord.Word = word.Trim();
            bannedWord.Severity = severity;
            bannedWord.IsRegexPattern = isRegex;
            bannedWord.Description = description;
            bannedWord.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Invalidate cache
            _cachedBannedWords = null;
        }

        public async Task DeleteBannedWordAsync(Guid id)
        {
            var bannedWord = await _context.BannedWords.FindAsync(id);
            if (bannedWord == null) return;

            _context.BannedWords.Remove(bannedWord);
            await _context.SaveChangesAsync();

            // Invalidate cache
            _cachedBannedWords = null;
        }

        public async Task ToggleBannedWordStatusAsync(Guid id)
        {
            var bannedWord = await _context.BannedWords.FindAsync(id);
            if (bannedWord == null) return;

            bannedWord.IsActive = !bannedWord.IsActive;
            bannedWord.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Invalidate cache
            _cachedBannedWords = null;
        }

        // Cache helper - returns entities for internal filtering
        private async Task<List<BannedWord>> GetCachedBannedWordsAsync()
        {
            if (_cachedBannedWords == null || DateTime.UtcNow - _cacheTime > _cacheExpiration)
            {
                _cachedBannedWords = await _context.BannedWords
                    .Where(b => b.IsActive)
                    .ToListAsync();
                _cacheTime = DateTime.UtcNow;
            }

            return _cachedBannedWords;
        }

        // Private helper: Map entity to DTO
        private BannedWordDto MapToDto(BannedWord entity)
        {
            return new BannedWordDto
            {
                Id = entity.Id,
                Word = entity.Word,
                Severity = entity.Severity,
                IsActive = entity.IsActive,
                IsRegexPattern = entity.IsRegexPattern,
                Description = entity.Description,
                CreatedByUserName = entity.CreatedBy?.UserName ?? "Unknown",
                CreatedAt = entity.CreatedAt
            };
        }
    }
}
