using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedUserWarnings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserWarnings",
                columns: new[] { "Id", "CreatedAt", "Deleted", "DeletedAt", "ExpiresAt", "IsActive", "IssuedByAdminId", "Reason", "RelatedFlaggedContentId", "Type", "UserId" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), new DateTime(2026, 3, 6, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new DateTime(2026, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "Used inappropriate language in comments. Please keep discussions respectful.", new Guid("f0000000-0000-0000-0000-000000000001"), 1, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new DateTime(2026, 5, 12, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "Posted harassing comments targeting another user. This is your second warning. Further violations may result in account suspension.", new Guid("f0000000-0000-0000-0000-000000000003"), 2, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), new DateTime(2026, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new DateTime(2026, 6, 12, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "Posted dangerous health misinformation. This is your FINAL WARNING. Any further violations will result in permanent account suspension.", new Guid("f0000000-0000-0000-0000-000000000005"), 3, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), new DateTime(2026, 3, 8, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new DateTime(2026, 4, 7, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "Posted promotional content/links in comments. Please avoid self-promotion in the community.", new Guid("f0000000-0000-0000-0000-000000000002"), 1, new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("c0000000-0000-0000-0000-000000000006"), new DateTime(2026, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), false, null, new DateTime(2026, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), true, new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), "Misuse of content flagging system. False reports waste moderator time and may result in loss of reporting privileges.", new Guid("f0000000-0000-0000-0000-000000000006"), 1, new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserWarnings",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "UserWarnings",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "UserWarnings",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "UserWarnings",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "UserWarnings",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000006"));
        }
    }
}
