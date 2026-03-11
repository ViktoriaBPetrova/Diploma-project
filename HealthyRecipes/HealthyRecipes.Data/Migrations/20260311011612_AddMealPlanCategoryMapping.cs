using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMealPlanCategoryMapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MealPlanCategories",
                columns: table => new
                {
                    MealPlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanCategories", x => new { x.MealPlanId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_MealPlanCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanCategories_MealPlans_MealPlanId",
                        column: x => x.MealPlanId,
                        principalTable: "MealPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MealPlanCategories",
                columns: new[] { "CategoryId", "MealPlanId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("c7a5d8c2-87d6-4c18-9c62-1fd9f8c73a03"), new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanCategories_CategoryId",
                table: "MealPlanCategories",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealPlanCategories");
        }
    }
}
