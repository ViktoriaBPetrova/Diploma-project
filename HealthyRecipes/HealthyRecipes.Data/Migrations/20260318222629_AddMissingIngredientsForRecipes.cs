using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMissingIngredientsForRecipes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Brand", "CaloriesPer100g", "CarbsPer100g", "CreatedAt", "CreatedByUserId", "Deleted", "DeletedAt", "FatPer100g", "Name", "ProteinPer100g", "Source", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"), null, 50f, 12f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.3f, "Mixed Berries", 1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"), null, 164f, 27.4f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 2.6f, "Chickpeas", 8.9f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"), null, 486f, 42.1f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 30.7f, "Chia Seeds", 16.5f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"), null, 53f, 4.9f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.1f, "Soy Sauce", 8.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"), null, 264f, 4.1f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 21.3f, "Feta Cheese", 14.2f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"), null, 17f, 0.6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 1.1f, "Almond Milk", 0.4f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                column: "QuantityInGrams",
                value: 100f);

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "QuantityInGrams", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 80f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 100f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 180f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 30f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 10f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 40f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 200f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 20f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 150f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 15f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 200f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 15f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 30f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 80f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 80f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 100f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 15f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 60f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 40f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 80f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 150f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 10f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 50f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 120f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 10f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 50f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 200f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 100f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 150f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 10f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 50f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 100f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 150f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 15f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 200f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 20f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"));

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                column: "QuantityInGrams",
                value: 150f);
        }
    }
}
