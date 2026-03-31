using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRecipeConversionProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OriginalUnit",
                table: "RecipeIngredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInCoffeeCups",
                table: "RecipeIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInCups",
                table: "RecipeIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInMillilitres",
                table: "RecipeIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInTablespoons",
                table: "RecipeIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "QuantityInTeaspoons",
                table: "RecipeIngredients",
                type: "real",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") },
                columns: new[] { "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons" },
                values: new object[] { null, null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginalUnit",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityInCoffeeCups",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityInCups",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityInMillilitres",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityInTablespoons",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "QuantityInTeaspoons",
                table: "RecipeIngredients");
        }
    }
}
