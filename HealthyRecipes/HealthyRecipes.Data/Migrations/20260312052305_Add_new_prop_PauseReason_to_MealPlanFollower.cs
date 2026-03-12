using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Add_new_prop_PauseReason_to_MealPlanFollower : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PauseReason",
                table: "MealPlanFollowers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                column: "PauseReason",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PauseReason",
                table: "MealPlanFollowers");
        }
    }
}
