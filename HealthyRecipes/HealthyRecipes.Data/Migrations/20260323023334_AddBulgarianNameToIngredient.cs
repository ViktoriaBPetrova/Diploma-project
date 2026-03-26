using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddBulgarianNameToIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BulgarianName",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"),
                column: "BulgarianName",
                value: "лук");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"),
                column: "BulgarianName",
                value: "банан");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"),
                column: "BulgarianName",
                value: "пилешко филе");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a4b1c2d3-6e7f-4a8b-9c1d-2e3f4a5b6c7d"),
                column: "BulgarianName",
                value: "кафяв ориз");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a4e1f2b3-6c7d-4e8f-9a1b-2c3d4e5f6a7b"),
                column: "BulgarianName",
                value: "кокосово масло");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"),
                column: "BulgarianName",
                value: "горски плодове");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"),
                column: "BulgarianName",
                value: "киноа");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1e"),
                column: "BulgarianName",
                value: "джинджифил");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b2c8d9e1-4f5a-4b6c-7d8e-9f1a2b3c4d5e"),
                column: "BulgarianName",
                value: "фъстъчено масло");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"),
                column: "BulgarianName",
                value: "домат");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b8c5d6e7-1f2a-4b3c-4d5e-6f7a8b9c1d2e"),
                column: "BulgarianName",
                value: "сладък картоф");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"),
                column: "BulgarianName",
                value: "чесън");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b9d1e2f3-4a5b-4c6d-7e8f-9a1b2c3d4e5f"),
                column: "BulgarianName",
                value: "нахут");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c1e2f3a4-5b6c-4d7e-8f9a-1b2c3d4e5f6a"),
                column: "BulgarianName",
                value: "семена от чиа");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"),
                column: "BulgarianName",
                value: "бял ориз");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c3d9e1f2-5a6b-4c7d-8e9f-1a2b3c4d5e6f"),
                column: "BulgarianName",
                value: "боровинки");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"),
                column: "BulgarianName",
                value: "чушка");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"),
                column: "BulgarianName",
                value: "броколи");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"),
                column: "BulgarianName",
                value: "яйца");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d2f3a4b5-6c7d-4e8f-9a1b-2c3d4e5f6a7b"),
                column: "BulgarianName",
                value: "соев сос");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"),
                column: "BulgarianName",
                value: "филе от сьомга");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"),
                column: "BulgarianName",
                value: "лимон");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"),
                column: "BulgarianName",
                value: "авокадо");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e3a4b5c6-7d8e-4f9a-1b2c-3d4e5f6a7b8c"),
                column: "BulgarianName",
                value: "сирене");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"),
                column: "BulgarianName",
                value: "гръцко кисело мляко");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"),
                column: "BulgarianName",
                value: "краставица");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"),
                column: "BulgarianName",
                value: "мед");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"),
                column: "BulgarianName",
                value: "бадеми");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f4b5c6d7-8e9f-4a1b-2c3d-4e5f6a7b8c9d"),
                column: "BulgarianName",
                value: "бадемово мляко");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"),
                column: "BulgarianName",
                value: "зехтин");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"),
                column: "BulgarianName",
                value: "спанак");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9d"),
                column: "BulgarianName",
                value: "магданоз");

            migrationBuilder.UpdateData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"),
                column: "BulgarianName",
                value: "овесени ядки");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BulgarianName",
                table: "Ingredients");
        }
    }
}
