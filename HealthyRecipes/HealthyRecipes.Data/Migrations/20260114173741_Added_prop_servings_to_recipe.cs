using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_prop_servings_to_recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Servings",
                table: "Recipes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e4a36463-b39d-4ac6-b748-4d81e8e7e8e9", "AQAAAAIAAYagAAAAEDZoKDzNOFTI2VDaWN/Fs6od0Ie+BN4qIF2V4oopqWQRBgA56Rs8YTIG2uZISte5aw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "67a287df-fd85-4a1c-8603-fb50a54ca624", "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"),
                column: "Servings",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Servings",
                table: "Recipes");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] {
            "e4a36463-b39d-4ac6-b748-4d81e8e7e8e9",  
            "AQAAAAIAAYagAAAAEDZoKDzNOFTI2VDaWN/Fs6od0Ie+BN4qIF2V4oopqWQRBgA56Rs8YTIG2uZISte5aw==" 
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] {
            "67a287df-fd85-4a1c-8603-fb50a54ca624",  
            "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==" 
                });
        }
    }
}
