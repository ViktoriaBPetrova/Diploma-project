using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedingBannedWords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "BannedWords",
                columns: new[] { "Id", "CreatedAt", "CreatedByUserId", "Deleted", "DeletedAt", "Description", "IsActive", "IsRegexPattern", "Severity", "UpdatedAt", "Word" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Spam content", true, false, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "spam" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Scam/fraud content", true, false, 4, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "scam" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Hate speech", true, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "hate" },
                    { new Guid("b0000000-0000-0000-0000-000000000004"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Insult", true, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "idiot" },
                    { new Guid("b0000000-0000-0000-0000-000000000005"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Insult", true, false, 3, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "stupid" },
                    { new Guid("b0000000-0000-0000-0000-000000000006"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Misleading content", true, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "clickbait" },
                    { new Guid("b0000000-0000-0000-0000-000000000007"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Potentially misleading", true, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "fake" },
                    { new Guid("b0000000-0000-0000-0000-000000000008"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Mild insult", true, false, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "dumb" },
                    { new Guid("b0000000-0000-0000-0000-000000000009"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Mildly negative", true, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "lame" },
                    { new Guid("b0000000-0000-0000-0000-000000000010"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Mildly negative language", true, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "sucks" },
                    { new Guid("b0000000-0000-0000-0000-000000000011"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Email addresses (prevent contact info spam)", true, true, 2, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "\\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\\.[A-Z|a-z]{2,}\\b" },
                    { new Guid("b0000000-0000-0000-0000-000000000012"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), false, null, "Inactive test word", false, false, 1, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "test" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "BannedWords",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000012"));
        }
    }
}
