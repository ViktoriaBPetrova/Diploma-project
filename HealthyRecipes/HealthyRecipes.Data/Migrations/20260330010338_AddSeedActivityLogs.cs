using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedActivityLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ActivityLogs",
                columns: new[] { "Id", "ActivityType", "ChangesSummary", "CreatedAt", "Deleted", "DeletedAt", "EntityId", "EntityName", "EntityType", "IpAddress", "NewValue", "OldValue", "Severity", "UserAgent", "UserId" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), 1, "Created new recipe: Healthy Chicken & Rice Bowl", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), "Healthy Chicken & Rice Bowl", "Recipe", "192.168.1.10", null, null, 1, null, new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), 1, "Created new recipe: Grilled Salmon with Lemon Quinoa", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), "Grilled Salmon with Lemon Quinoa", "Recipe", "192.168.1.11", null, null, 1, null, new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), 2, "Updated recipe: Changed prep time from 25 to 30 minutes", new DateTime(2025, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), "Healthy Chicken & Rice Bowl", "Recipe", "192.168.1.10", null, null, 2, null, new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), 9, "Posted comment on recipe: Grilled Salmon with Lemon Quinoa", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("10000000-0000-0000-0000-000000000009"), "Comment on Grilled Salmon with Lemon Quinoa", "Comment", "192.168.1.13", null, null, 1, null, new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), 9, "Posted comment on recipe: Healthy Chicken & Rice Bowl", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("10000000-0000-0000-0000-000000000005"), "Comment on Healthy Chicken & Rice Bowl", "Comment", "192.168.1.12", null, null, 1, null, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("a0000000-0000-0000-0000-000000000006"), 15, "Banned words detected: spam, scam", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("30000000-0000-0000-0000-000000000001"), "Comment flagged for banned words", "Comment", "192.168.1.50", null, null, 4, null, null },
                    { new Guid("a0000000-0000-0000-0000-000000000007"), 18, "Content auto-flagged for containing banned words (spam, scam)", new DateTime(2026, 2, 24, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new Guid("30000000-0000-0000-0000-000000000001"), "Flagged comment for admin review", "Comment", "192.168.1.50", null, null, 4, null, null },
                    { new Guid("a0000000-0000-0000-0000-000000000008"), 6, "Admin user logged in successfully", new DateTime(2026, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "user@nutritrack.com", "User", "192.168.1.1", null, null, 1, null, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02") },
                    { new Guid("a0000000-0000-0000-0000-000000000009"), 8, "Failed login attempt - incorrect password", new DateTime(2026, 2, 27, 0, 0, 0, 0, DateTimeKind.Utc), false, null, null, "unknown@example.com", "User", "192.168.1.99", null, null, 3, null, null },
                    { new Guid("a0000000-0000-0000-0000-000000000010"), 12, "Rated recipe: 5 stars (Delicious)", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), "Grilled Salmon with Lemon Quinoa", "Recipe", "192.168.1.13", null, null, 1, null, new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000009"));

            migrationBuilder.DeleteData(
                table: "ActivityLogs",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000010"));
        }
    }
}
