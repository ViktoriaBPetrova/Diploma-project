using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnderReviewFromSeedFlaggedContentStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000003"),
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000007"),
                column: "Status",
                value: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000003"),
                column: "Status",
                value: 2);

            migrationBuilder.UpdateData(
                table: "FlaggedContents",
                keyColumn: "Id",
                keyValue: new Guid("f0000000-0000-0000-0000-000000000007"),
                column: "Status",
                value: 2);
        }
    }
}
