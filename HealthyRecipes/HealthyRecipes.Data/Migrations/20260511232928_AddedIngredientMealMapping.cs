using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIngredientMealMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "IngredientMeals",
                columns: table => new
                {
                    IngredientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityInGrams = table.Column<float>(type: "real", nullable: false),
                    QuantityInTeaspoons = table.Column<float>(type: "real", nullable: true),
                    QuantityInTablespoons = table.Column<float>(type: "real", nullable: true),
                    QuantityInCups = table.Column<float>(type: "real", nullable: true),
                    QuantityInCoffeeCups = table.Column<float>(type: "real", nullable: true),
                    QuantityInMillilitres = table.Column<float>(type: "real", nullable: true),
                    OriginalUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientMeals", x => new { x.MealId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientMeals_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IngredientMeals_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "IngredientMeals",
                columns: new[] { "IngredientId", "MealId", "CreatedAt", "Deleted", "DeletedAt", "OriginalUnit", "QuantityInCoffeeCups", "QuantityInCups", "QuantityInGrams", "QuantityInMillilitres", "QuantityInTablespoons", "QuantityInTeaspoons", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a5c6d7e8-9f1a-4b2c-3d4e-5f6a7b8c9d1e"), new Guid("11111111-1111-4111-8111-111111111111"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "cup", null, 1f, 100f, null, null, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"), new Guid("33333333-3333-4333-8333-333333333311"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "grams", null, null, 150f, null, null, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"), new Guid("44444444-4444-4444-8444-444444444411"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "grams", null, null, 80f, null, null, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IngredientMeals_IngredientId",
                table: "IngredientMeals",
                column: "IngredientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientMeals");
        }
    }
}
