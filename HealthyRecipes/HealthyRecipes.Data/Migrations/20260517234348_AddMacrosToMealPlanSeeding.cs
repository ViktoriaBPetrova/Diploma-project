using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMacrosToMealPlanSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 8353.9f, 815.75f, 383.3f, 449.15f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 8357.601f, 741.755f, 329.305f, 597.90497f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 8112f, 919.21f, 385.11f, 323.66f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 8253.4f, 807.38495f, 278.985f, 622.2f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });
        }
    }
}
