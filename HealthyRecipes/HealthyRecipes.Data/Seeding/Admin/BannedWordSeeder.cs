using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Seeding.Constants;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthyRecipes.Data.Seeding.Admin
{
    public static class BannedWordSeeder
    {
        private static readonly Guid AdminUserId = Guid.Parse(UserConstants.AdminUserId); // User (Main Admin)

        public static IEnumerable<BannedWord> GenerateBannedWords()
        {
            var seedDate = new DateTime(2025, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            IEnumerable<BannedWord> bannedWords = new List<BannedWord>() { 
                // Critical severity words
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000001"), // Fixed: bw -> b0
                    Word = "spam",
                    Severity = WordSeverity.Critical,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Spam content"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000002"),
                    Word = "scam",
                    Severity = WordSeverity.Critical,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Scam/fraud content"
                },
 
                // High severity words
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000003"),
                    Word = "hate",
                    Severity = WordSeverity.High,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Hate speech"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000004"),
                    Word = "idiot",
                    Severity = WordSeverity.High,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Insult"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000005"),
                    Word = "stupid",
                    Severity = WordSeverity.High,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Insult"
                },
 
                // Medium severity words
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000006"),
                    Word = "clickbait",
                    Severity = WordSeverity.Medium,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Misleading content"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000007"),
                    Word = "fake",
                    Severity = WordSeverity.Medium,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Potentially misleading"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000008"),
                    Word = "dumb",
                    Severity = WordSeverity.Medium,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Mild insult"
                },
 
                // Low severity words
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000009"),
                    Word = "lame",
                    Severity = WordSeverity.Low,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Mildly negative"
                },
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000010"),
                    Word = "sucks",
                    Severity = WordSeverity.Low,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Mildly negative language"
                },
 
                // Regex pattern example - email addresses (for preventing spam)
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000011"),
                    Word = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}\b",
                    Severity = WordSeverity.Medium,
                    IsActive = true,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = true,
                    Description = "Email addresses (prevent contact info spam)"
                },
 
                // Inactive word (for testing)
                new BannedWord
                {
                    Id = Guid.Parse("b0000000-0000-0000-0000-000000000012"),
                    Word = "test",
                    Severity = WordSeverity.Low,
                    IsActive = false,
                    CreatedByUserId = AdminUserId,
                    CreatedAt = seedDate,
                    UpdatedAt = seedDate,
                    IsRegexPattern = false,
                    Description = "Inactive test word"
                }
            };

            return bannedWords;
        }
    }
}
