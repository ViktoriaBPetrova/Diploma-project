using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeedingDates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444411"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 8, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444412"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 12, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444421"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 27, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111111"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111112"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111113"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111121"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 7, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111122"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 13, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111131"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 8, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111133"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111141"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111142"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111151"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 22, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 8, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111152"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 22, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111153"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 22, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222211"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 6, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222212"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222221"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 6, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 6, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 6, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111111"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 8, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 8, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111112"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111121"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 27, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d1444444-1444-4d14-8d14-144444444411"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d1444444-1444-4d14-8d14-144444444412"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 27, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 21, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111111"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111112"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 19, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 19, 20, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111113"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 19, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111114"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111115"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 20, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3222222-3222-4d32-8d32-322222222211"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 20, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 21, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3222222-3222-4d32-8d32-322222222212"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d4111111-4111-4d41-8d41-411111111111"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 26, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 20, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d4111111-4111-4d41-8d41-411111111112"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 27, 20, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 20, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 27, 20, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                columns: new[] { "CompletedAt", "ConsentGivenAt", "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                columns: new[] { "ConsentGivenAt", "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                columns: new[] { "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                columns: new[] { "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2026, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2026, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444411"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444412"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 12, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e1444444-1444-4e14-8e14-144444444421"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 19, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111111"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 11, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111112"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111113"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111121"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 7, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111122"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 13, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111131"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 8, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111133"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111141"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111142"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111151"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 7, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111152"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e2111111-2111-4e21-8e21-211111111153"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 19, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222211"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 6, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222212"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 12, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e3222222-3222-4e32-8e32-322222222221"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 6, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 6, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 6, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111111"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111112"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealEntries",
                keyColumn: "Id",
                keyValue: new Guid("e4111111-4111-4e41-8e41-411111111121"),
                columns: new[] { "ConsumedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d1444444-1444-4d14-8d14-144444444411"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d1444444-1444-4d14-8d14-144444444412"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111111"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111112"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111113"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111114"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d2111111-2111-4d21-8d21-211111111115"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3222222-3222-4d32-8d32-322222222211"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d3222222-3222-4d32-8d32-322222222212"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d4111111-4111-4d41-8d41-411111111111"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanDayEntries",
                keyColumn: "Id",
                keyValue: new Guid("d4111111-4111-4d41-8d41-411111111112"),
                columns: new[] { "CompletedAt", "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                columns: new[] { "CompletedAt", "ConsentGivenAt", "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                columns: new[] { "ConsentGivenAt", "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 14, 1, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                columns: new[] { "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                columns: new[] { "ExpectedCompletionDate", "StartedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
