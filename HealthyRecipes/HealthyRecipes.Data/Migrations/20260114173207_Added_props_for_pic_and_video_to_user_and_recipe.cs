using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_props_for_pic_and_video_to_user_and_recipe : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VideoUrl",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "5c35805f-f24e-4e07-aa66-21fd492a9776", null, "AQAAAAIAAYagAAAAEMml0QVdaSEEpJHh5gZE/iI9pmB5N0L7VdcBTiE5weYGgmhqQfGhxwMuMuj7qyBSfA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"),
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash" },
                values: new object[] { "82542edf-b545-49a4-bbc2-a47c5edf2e5e", null, "AQAAAAIAAYagAAAAENyYRxcUxN0lRZpiYL/S2VEAKA+C98egtSvAeyhJ3vpfcpOwEC1rvgV41vXmpuiWcw==" });

            migrationBuilder.UpdateData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"),
                columns: new[] { "ImageUrl", "VideoUrl" },
                values: new object[] { null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "VideoUrl",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "43b9fcd1-5bde-4848-aacb-59d8b3ca80d0", "AQAAAAIAAYagAAAAENpfAEZCOAiaN8Uyuugs2FFoWUANb9P3dGCgOD3bnfKxLfNPjfaqzo4zuaGRXmVc4g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "21629e20-4bd6-4212-94a4-2279d0068102", "AQAAAAIAAYagAAAAEFrIDCf7GJMWujVwG6dvRq5bmdjZ4L+6qvizLsO7xQ9HJ1i79QFs36SSBITWVV6kig==" });
        }
    }
}
