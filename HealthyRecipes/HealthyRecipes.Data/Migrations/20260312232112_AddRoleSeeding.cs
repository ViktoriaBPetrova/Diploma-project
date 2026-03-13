using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), "admin-role-stamp", "Admin", "ADMIN" },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), "user-role-stamp", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"), new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-7890-abcd-ef1234567890"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"));
        }
    }
}
