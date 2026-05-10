using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRecipeNutritionalValuesSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.8f, 9.69f, 24.65f, 21.51f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });
        }
    }
}
