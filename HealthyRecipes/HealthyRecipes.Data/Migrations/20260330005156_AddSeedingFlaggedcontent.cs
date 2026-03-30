using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingFlaggedcontent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FlaggedContents",
                columns: new[] { "Id", "AdminNotes", "ContentAuthorId", "ContentId", "ContentPreview", "ContentType", "CreatedAt", "Deleted", "DeletedAt", "Details", "MatchedBannedWords", "Reason", "ReportedByUserId", "Resolution", "ReviewedAt", "ReviewedByAdminId", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f0000000-0000-0000-0000-000000000001"), null, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), new Guid("30000000-0000-0000-0000-000000000001"), "This recipe is spam! Total scam, don't try it! Visit my website for real recipes!", "Comment", new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "Auto-flagged by content filter", "spam, scam", 1, null, null, null, null, 1, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000002"), null, new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), new Guid("30000000-0000-0000-0000-000000000002"), "Check out my website for weight loss pills! www.spam-site.com - Get 50% off today!", "Comment", new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "User posting promotional links in comments", null, 2, new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), null, null, null, 1, new DateTime(2026, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000003"), "Investigating user's comment history for pattern of harassment", new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), new Guid("30000000-0000-0000-0000-000000000003"), "You're such an idiot for not liking this recipe. Stupid people like you shouldn't be commenting on food.", "Comment", new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "Personal attack on another user in comment section", "idiot, stupid", 3, new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), null, null, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), 2, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000005"), "User issued formal warning about posting health misinformation. Comment removed.", new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), new Guid("30000000-0000-0000-0000-000000000004"), "This salmon recipe will cure your diabetes! No need for insulin anymore! I threw away my medication after eating this!", "Comment", new DateTime(2026, 3, 11, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "Dangerous health misinformation that could harm diabetic users", null, 5, new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), 3, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), 3, new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000006"), "False report. Comment is legitimate user feedback expressing enthusiasm. Reporter warned about misuse of flagging system.", new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), new Guid("10000000-0000-0000-0000-000000000009"), "Absolutely love this! The lemon quinoa is the perfect pairing. Made it three times this week.", "Comment", new DateTime(2026, 3, 9, 0, 0, 0, 0, DateTimeKind.Utc), false, null, "This looks like spam to me - too enthusiastic", null, 2, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), 5, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), 4, new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000007"), "Low severity words detected. Reviewing context and tone. May be legitimate negative feedback vs. harassment.", new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), new Guid("30000000-0000-0000-0000-000000000005"), "This recipe is lame and totally sucks. What a waste of time. Not worth trying at all.", "Comment", new DateTime(2026, 3, 14, 12, 0, 0, 0, DateTimeKind.Utc), false, null, "Auto-flagged by content filter for low-severity banned words", "lame, sucks", 1, null, null, null, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), 2, new DateTime(2026, 3, 14, 18, 0, 0, 0, DateTimeKind.Utc) },
                    { new Guid("f0000000-0000-0000-0000-000000000008"), null, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), new Guid("30000000-0000-0000-0000-000000000006"), "Fake news! This is clickbait garbage. Pure spam. I hate it! Don't believe these lies!", "Comment", new DateTime(2026, 3, 14, 22, 0, 0, 0, DateTimeKind.Utc), false, null, "Auto-flagged by content filter - multiple high-severity words detected", "fake, clickbait, spam, hate", 1, null, null, null, null, 1, new DateTime(2026, 3, 14, 22, 0, 0, 0, DateTimeKind.Utc) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000008"));
        }
    }
}
