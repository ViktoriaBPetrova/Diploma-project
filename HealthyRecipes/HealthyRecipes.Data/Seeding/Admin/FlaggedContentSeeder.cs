using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthyRecipes.Data.Seeding.Admin
{
    public static class FlaggedContentSeeder
    {
        // User IDs (from UserConstants)
        private static readonly Guid UserUserId = Guid.Parse(UserConstants.AdminUserId); // Admin
        private static readonly Guid JohnUserId = Guid.Parse(UserConstants.UserId); // John
        private static readonly Guid EmmaUserId = Guid.Parse(UserConstants.User4Id); // Emma
        private static readonly Guid MikeUserId = Guid.Parse(UserConstants.User3Id); // Mike
        private static readonly Guid SarahUserId = Guid.Parse(UserConstants.User2Id); // Sarah

        public static void SeedFlaggedContent(ModelBuilder builder)
        {
            var baseDate = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc);

            builder.Entity<FlaggedContent>().HasData(
                // 1. Auto-flagged spam comment - Contains "spam" and "scam" (PENDING)
                // Uses REAL SpamComment1Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.SpamComment1Id), // REAL comment
                    ContentPreview = CommentRatingConstants.SpamComment1Text,
                    ContentAuthorId = MikeUserId,
                    Reason = FlagReason.BannedWords,
                    Details = "Auto-flagged by content filter",
                    MatchedBannedWords = "spam, scam",
                    ReportedByUserId = null, // Auto-flagged
                    Status = FlagStatus.Pending,
                    ReviewedByAdminId = null,
                    ReviewedAt = null,
                    AdminNotes = null,
                    Resolution = null,
                    CreatedAt = baseDate.AddDays(-10),
                    UpdatedAt = baseDate.AddDays(-10)
                },

                // 2. User-reported promotional spam (PENDING)
                // Uses REAL SpamComment2Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.SpamComment2Id), // REAL comment
                    ContentPreview = CommentRatingConstants.SpamComment2Text,
                    ContentAuthorId = SarahUserId,
                    Reason = FlagReason.Spam,
                    Details = "User posting promotional links in comments",
                    MatchedBannedWords = null,
                    ReportedByUserId = EmmaUserId,
                    Status = FlagStatus.Pending,
                    ReviewedByAdminId = null,
                    ReviewedAt = null,
                    AdminNotes = null,
                    Resolution = null,
                    CreatedAt = baseDate.AddDays(-8),
                    UpdatedAt = baseDate.AddDays(-8)
                },

                // 3. Harassment comment - Reply to Sarah (UNDER REVIEW)
                // Uses REAL HarassmentComment1Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000003"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.HarassmentComment1Id), // REAL comment
                    ContentPreview = CommentRatingConstants.HarassmentComment1Text,
                    ContentAuthorId = MikeUserId,
                    Reason = FlagReason.Harassment,
                    Details = "Personal attack on another user in comment section",
                    MatchedBannedWords = "idiot, stupid",
                    ReportedByUserId = JohnUserId,
                    Status = FlagStatus.UnderReview,
                    ReviewedByAdminId = UserUserId,
                    ReviewedAt = null,
                    AdminNotes = "Investigating user's comment history for pattern of harassment",
                    Resolution = null,
                    CreatedAt = baseDate.AddDays(-5),
                    UpdatedAt = baseDate.AddDays(-2)
                },
                /*
                // 4. Inappropriate recipe promoting dangerous eating - RESOLVED (Content Removed)
                // Hypothetical recipe that was deleted
                new FlaggedContent
                {
                    Id = Guid.Parse("fc000000-0000-0000-0000-000000000004"),
                    ContentType = "Recipe",
                    ContentId = Guid.Parse("99999999-9999-9999-9999-999999999001"), // Hypothetical deleted recipe
                    ContentPreview = "Extreme Weight Loss Recipe - Eat only 200 calories per day! Lose 10 pounds in 3 days! No exercise needed!",
                    ContentAuthorId = SarahUserId,
                    Reason = FlagReason.InappropriateContent,
                    Details = "Recipe promotes dangerous eating habits and unrealistic weight loss claims",
                    MatchedBannedWords = null,
                    ReportedByUserId = EmmaUserId,
                    Status = FlagStatus.Resolved,
                    ReviewedByAdminId = UserUserId,
                    ReviewedAt = baseDate.AddDays(-3),
                    AdminNotes = "Recipe removed from platform. Promotes unhealthy practices that could lead to eating disorders. User warned.",
                    Resolution = FlagResolution.ContentRemoved,
                    CreatedAt = baseDate.AddDays(-7),
                    UpdatedAt = baseDate.AddDays(-3)
                },
                */
                // 5. Health misinformation - RESOLVED (User Warned)
                // Uses REAL MisinfoComment1Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000005"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.MisinfoComment1Id), // REAL comment
                    ContentPreview = CommentRatingConstants.MisinfoComment1Text,
                    ContentAuthorId = MikeUserId,
                    Reason = FlagReason.Misinformation,
                    Details = "Dangerous health misinformation that could harm diabetic users",
                    MatchedBannedWords = null,
                    ReportedByUserId = JohnUserId,
                    Status = FlagStatus.Resolved,
                    ReviewedByAdminId = UserUserId,
                    ReviewedAt = baseDate.AddDays(-1),
                    AdminNotes = "User issued formal warning about posting health misinformation. Comment removed.",
                    Resolution = FlagResolution.UserWarned,
                    CreatedAt = baseDate.AddDays(-4),
                    UpdatedAt = baseDate.AddDays(-1)
                },

                // 6. False report on legitimate comment - DISMISSED
                // Uses REAL Comment9Id (Sarah's positive review)
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000006"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.Comment9Id), // REAL positive comment
                    ContentPreview = CommentRatingConstants.SarahComment2,
                    ContentAuthorId = SarahUserId,
                    Reason = FlagReason.Spam,
                    Details = "This looks like spam to me - too enthusiastic",
                    MatchedBannedWords = null,
                    ReportedByUserId = MikeUserId,
                    Status = FlagStatus.Dismissed,
                    ReviewedByAdminId = UserUserId,
                    ReviewedAt = baseDate.AddDays(-2),
                    AdminNotes = "False report. Comment is legitimate user feedback expressing enthusiasm. Reporter warned about misuse of flagging system.",
                    Resolution = FlagResolution.NoActionNeeded,
                    CreatedAt = baseDate.AddDays(-6),
                    UpdatedAt = baseDate.AddDays(-2)
                },

                // 7. Mild language - UNDER REVIEW
                // Uses REAL MildNegativeComment1Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000007"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.MildNegativeComment1Id), // REAL comment
                    ContentPreview = CommentRatingConstants.MildNegativeComment1Text,
                    ContentAuthorId = SarahUserId,
                    Reason = FlagReason.BannedWords,
                    Details = "Auto-flagged by content filter for low-severity banned words",
                    MatchedBannedWords = "lame, sucks",
                    ReportedByUserId = null,
                    Status = FlagStatus.UnderReview,
                    ReviewedByAdminId = UserUserId,
                    ReviewedAt = null,
                    AdminNotes = "Low severity words detected. Reviewing context and tone. May be legitimate negative feedback vs. harassment.",
                    Resolution = null,
                    CreatedAt = baseDate.AddHours(-12),
                    UpdatedAt = baseDate.AddHours(-6)
                },

                // 8. Multiple banned words - PENDING
                // Uses REAL ToxicComment1Id
                new FlaggedContent
                {
                    Id = Guid.Parse("f0000000-0000-0000-0000-000000000008"),
                    ContentType = "Comment",
                    ContentId = Guid.Parse(CommentRatingConstants.ToxicComment1Id), // REAL comment
                    ContentPreview = CommentRatingConstants.ToxicComment1Text,
                    ContentAuthorId = MikeUserId,
                    Reason = FlagReason.BannedWords,
                    Details = "Auto-flagged by content filter - multiple high-severity words detected",
                    MatchedBannedWords = "fake, clickbait, spam, hate",
                    ReportedByUserId = null,
                    Status = FlagStatus.Pending,
                    ReviewedByAdminId = null,
                    ReviewedAt = null,
                    AdminNotes = null,
                    Resolution = null,
                    CreatedAt = baseDate.AddHours(-2),
                    UpdatedAt = baseDate.AddHours(-2)
                }


                
            );
        }
    }
}