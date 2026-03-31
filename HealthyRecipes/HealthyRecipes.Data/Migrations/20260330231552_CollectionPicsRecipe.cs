using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class CollectionPicsRecipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Recipes",
                newName: "PrimaryImageUrl");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrls",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"),
                column: "ImageUrls",
                value: "[]");

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"),
                column: "ImageUrls",
                value: "[]");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrls",
                table: "Recipes");

            migrationBuilder.RenameColumn(
                name: "PrimaryImageUrl",
                table: "Recipes",
                newName: "ImageUrl");
        }
    }
}
