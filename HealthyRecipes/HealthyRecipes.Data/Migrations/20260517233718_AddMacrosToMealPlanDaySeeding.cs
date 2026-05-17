using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMacrosToMealPlanDaySeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1895.55f, 164.495f, 79.645f, 124.64f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1567.9001f, 177.055f, 42.684998f, 117.634995f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1687.1001f, 220.54501f, 65.564995f, 69.57f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1676.9501f, 163.41501f, 71.095f, 108.634995f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1583.4f, 158.24501f, 75.685f, 74.095f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1516.6001f, 138.83f, 48.14f, 131.965f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1888.05f, 180.845f, 70.765f, 130.235f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1593.4f, 165.11002f, 81.25f, 67.104996f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1583.3f, 147.10501f, 74.034996f, 84.995f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1567.9001f, 177.055f, 42.684998f, 117.634995f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1644.7001f, 203.335f, 75.795f, 52.775f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1593.4f, 165.11f, 81.25f, 67.105f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1516.6001f, 138.83f, 48.14f, 131.965f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1603.3f, 138.26001f, 81.37999f, 89.305f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1656.3999f, 182.455f, 43.285f, 132.635f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1845.55f, 152.495f, 79.345f, 124.34f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 2000.6501f, 264.16f, 65.42f, 94.58499f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1573.15f, 89.975006f, 79.564995f, 124.06f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1593.4f, 165.11f, 81.25f, 67.105f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 1489.6f, 91.67f, 89.71999f, 82.53f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });
        }
    }
}
