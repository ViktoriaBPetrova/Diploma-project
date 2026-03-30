using HealthyRecipes.Data.Entities.Admin;
using HealthyRecipes.Data.Seeding.Constants;
using Microsoft.EntityFrameworkCore;
using System;

namespace HealthyRecipes.Data.Seeding.Admin
{
    public static class UserWarningSeeder
    {
        // User IDs
        private static readonly Guid UserUserId = Guid.Parse(UserConstants.AdminUserId); // User (Admin)
        private static readonly Guid MikeUserId = Guid.Parse(UserConstants.User3Id); // Mike
        private static readonly Guid SarahUserId = Guid.Parse(UserConstants.User2Id); // Sarah

        // Flagged Content IDs (from FlaggedContentSeeder)
        private static readonly Guid FlaggedContent3 = Guid.Parse("f0000000-0000-0000-0000-000000000003");
        private static readonly Guid FlaggedContent5 = Guid.Parse("f0000000-0000-0000-0000-000000000005");

        public static void SeedUserWarnings(ModelBuilder builder)
        {
            var baseDate = new DateTime(2026, 3, 15, 0, 0, 0, DateTimeKind.Utc);

            builder.Entity<UserWarning>().HasData(
                // 1. Informal warning to Mike for first offense (active)
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000001"),
                    UserId = MikeUserId,
                    Reason = "Used inappropriate language in comments. Please keep discussions respectful.",
                    Type = WarningType.Informal,
                    RelatedFlaggedContentId = Guid.Parse("f0000000-0000-0000-0000-000000000001"),
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-9),
                    ExpiresAt = baseDate.AddDays(21), // 30 days from issue
                    IsActive = true
                },

                // 2. Formal warning to Mike for harassment (active)
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000002"),
                    UserId = MikeUserId,
                    Reason = "Posted harassing comments targeting another user. This is your second warning. Further violations may result in account suspension.",
                    Type = WarningType.Formal,
                    RelatedFlaggedContentId = FlaggedContent3,
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-2),
                    ExpiresAt = baseDate.AddDays(58), // 60 days from issue
                    IsActive = true
                },

                // 3. Final warning to Mike for misinformation (active)
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000003"),
                    UserId = MikeUserId,
                    Reason = "Posted dangerous health misinformation. This is your FINAL WARNING. Any further violations will result in permanent account suspension.",
                    Type = WarningType.Final,
                    RelatedFlaggedContentId = FlaggedContent5,
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-1),
                    ExpiresAt = baseDate.AddDays(89), // 90 days from issue
                    IsActive = true
                },

                // 4. Informal warning to Sarah for spam (active)
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000004"),
                    UserId = SarahUserId,
                    Reason = "Posted promotional content/links in comments. Please avoid self-promotion in the community.",
                    Type = WarningType.Informal,
                    RelatedFlaggedContentId = Guid.Parse("f0000000-0000-0000-0000-000000000002"),
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-7),
                    ExpiresAt = baseDate.AddDays(23), // 30 days from issue
                    IsActive = true
                },

                // 6. Warning for false reporting (active)
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000006"),
                    UserId = MikeUserId,
                    Reason = "Misuse of content flagging system. False reports waste moderator time and may result in loss of reporting privileges.",
                    Type = WarningType.Informal,
                    RelatedFlaggedContentId = Guid.Parse("f0000000-0000-0000-0000-000000000006"),
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-2),
                    ExpiresAt = baseDate.AddDays(28), // 30 days from issue
                    IsActive = true
                }

                /*
                // 7. Temporary suspension example (active) - for severe cases
                new UserWarning
                {
                    Id = Guid.Parse("c0000000-0000-0000-0000-000000000007"),
                    UserId = Guid.Parse("00000000-0000-0000-0000-000000000888"), // Hypothetical user
                    Reason = "Multiple community guideline violations. Account temporarily suspended for 7 days.",
                    Type = WarningType.Temporary,
                    RelatedFlaggedContentId = null,
                    IssuedByAdminId = UserUserId,
                    CreatedAt = baseDate.AddDays(-5),
                    ExpiresAt = baseDate.AddDays(2), // 7-day suspension
                    IsActive = true
                }*/
            );
        }
    }
}
