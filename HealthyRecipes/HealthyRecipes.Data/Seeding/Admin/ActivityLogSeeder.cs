using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Seeding.Constants;
using HealthyRecipes.Data.Seeding.Constants.MappingConstants;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthyRecipes.Data.Seeding.Admin
{
    public static class ActivityLogSeeder
    {
        // User IDs (from UserConstants)
        private static readonly Guid UserUserId = Guid.Parse(UserConstants.AdminUserId); // User (Admin)
        private static readonly Guid JohnUserId = Guid.Parse(UserConstants.UserId); // John
        private static readonly Guid EmmaUserId = Guid.Parse(UserConstants.User4Id); // Emma
        private static readonly Guid MikeUserId = Guid.Parse(UserConstants.User3Id); // Mike
        private static readonly Guid SarahUserId = Guid.Parse(UserConstants.User2Id); // Sarah

        public static void SeedActivityLogs(ModelBuilder builder)
        {
            var baseDate = new DateTime(2026, 3, 1, 0, 0, 0, DateTimeKind.Utc);

            builder.Entity<ActivityLog>().HasData(
                // Recipe creation activities - Using REAL recipe IDs
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000001"),
                    UserId = JohnUserId,
                    ActivityType = ActivityType.Create,
                    EntityType = "Recipe",
                    EntityId = Guid.Parse(RecipeConstants.ChickenRiceBowlId),
                    EntityName = RecipeConstants.ChickenRiceBowlTitle,
                    ChangesSummary = $"Created new recipe: {RecipeConstants.ChickenRiceBowlTitle}",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.10",
                    CreatedAt = new DateTime(2025, 4, 20)
                },
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000002"),
                    UserId = EmmaUserId,
                    ActivityType = ActivityType.Create,
                    EntityType = "Recipe",
                    EntityId = Guid.Parse(RecipeConstants.GrilledSalmonQuinoaId),
                    EntityName = RecipeConstants.GrilledSalmonQuinoaTitle,
                    ChangesSummary = $"Created new recipe: {RecipeConstants.GrilledSalmonQuinoaTitle}",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.11",
                    CreatedAt = new DateTime(2025, 4, 20)
                },

                // Recipe update activity
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000003"),
                    UserId = JohnUserId,
                    ActivityType = ActivityType.Update,
                    EntityType = "Recipe",
                    EntityId = Guid.Parse(RecipeConstants.ChickenRiceBowlId),
                    EntityName = RecipeConstants.ChickenRiceBowlTitle,
                    ChangesSummary = "Updated recipe: Changed prep time from 25 to 30 minutes",
                    Severity = LogSeverity.Low,
                    IpAddress = "192.168.1.10",
                    CreatedAt = new DateTime(2025, 5, 20)
                },

                // Comment posting activities - Using REAL comment IDs
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000004"),
                    UserId = SarahUserId,
                    ActivityType = ActivityType.CommentPosted,
                    EntityType = "Comment",
                    EntityId = Guid.Parse(CommentRatingConstants.Comment9Id), // Sarah's positive comment
                    EntityName = "Comment on Grilled Salmon with Lemon Quinoa",
                    ChangesSummary = $"Posted comment on recipe: {RecipeConstants.GrilledSalmonQuinoaTitle}",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.13",
                    CreatedAt = new DateTime(2025, 12, 18)
                },
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000005"),
                    UserId = MikeUserId,
                    ActivityType = ActivityType.CommentPosted,
                    EntityType = "Comment",
                    EntityId = Guid.Parse(CommentRatingConstants.Comment5Id), // Mike's comment on Chicken Bowl
                    EntityName = "Comment on Healthy Chicken & Rice Bowl",
                    ChangesSummary = $"Posted comment on recipe: {RecipeConstants.ChickenRiceBowlTitle}",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.12",
                    CreatedAt = new DateTime(2025, 12, 18)
                },

                // Banned word detection (High severity) - REAL spam comment
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000006"),
                    UserId = null, // System detection
                    ActivityType = ActivityType.BannedWordDetected,
                    EntityType = "Comment",
                    EntityId = Guid.Parse(CommentRatingConstants.SpamComment1Id), // REAL spam comment
                    EntityName = "Comment flagged for banned words",
                    ChangesSummary = "Banned words detected: spam, scam",
                    Severity = LogSeverity.High,
                    IpAddress = "192.168.1.50",
                    CreatedAt = new DateTime(2025, 12, 18)
                },

                // Content flagged (High severity) - REAL spam comment
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000007"),
                    UserId = null, // System action
                    ActivityType = ActivityType.ContentFlagged,
                    EntityType = "Comment",
                    EntityId = Guid.Parse(CommentRatingConstants.SpamComment1Id), // REAL spam comment
                    EntityName = "Flagged comment for admin review",
                    ChangesSummary = "Content auto-flagged for containing banned words (spam, scam)",
                    Severity = LogSeverity.High,
                    IpAddress = "192.168.1.50",
                    CreatedAt = baseDate.AddDays(-5)
                },

                // User login activities
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000008"),
                    UserId = UserUserId,
                    ActivityType = ActivityType.Login,
                    EntityType = "User",
                    EntityId = UserUserId, // Real user ID
                    EntityName = "user@nutritrack.com",
                    ChangesSummary = "Admin user logged in successfully",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.1",
                    CreatedAt = baseDate.AddDays(-3)
                },

                // Failed login (Medium severity)
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000009"),
                    UserId = null, // Unknown user
                    ActivityType = ActivityType.FailedLogin,
                    EntityType = "User",
                    EntityId = null,
                    EntityName = "unknown@example.com",
                    ChangesSummary = "Failed login attempt - incorrect password",
                    Severity = LogSeverity.Medium,
                    IpAddress = "192.168.1.99",
                    CreatedAt = baseDate.AddDays(-2)
                },

                // Rating given - Using REAL comment/recipe
                new ActivityLog
                {
                    Id = Guid.Parse("a0000000-0000-0000-0000-000000000010"),
                    UserId = SarahUserId,
                    ActivityType = ActivityType.RatingGiven,
                    EntityType = "Recipe",
                    EntityId = Guid.Parse(RecipeConstants.GrilledSalmonQuinoaId),
                    EntityName = RecipeConstants.GrilledSalmonQuinoaTitle,
                    ChangesSummary = "Rated recipe: 5 stars (Delicious)",
                    Severity = LogSeverity.Info,
                    IpAddress = "192.168.1.13",
                    CreatedAt = new DateTime(2025, 12, 18)
                }
            );
        }
    }
}