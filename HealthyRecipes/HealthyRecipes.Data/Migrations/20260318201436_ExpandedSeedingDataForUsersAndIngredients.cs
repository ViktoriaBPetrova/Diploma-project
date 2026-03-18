using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedSeedingDataForUsersAndIngredients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "Calories", "CarbsGoal", "ConcurrencyStamp", "CreatedAt", "Deleted", "DeletedAt", "Email", "EmailConfirmed", "FatGoal", "FirstName", "Height", "ImageUrl", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProteinGoal", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "Weight" },
                values: new object[,]
                {
                    { new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), 0, "Yoga instructor and clean eating advocate. Love experimenting with plant-based recipes!", 1800f, 220f, "a5b6c7d8-e9f1-4a2b-3c4d-5e6f7a8b9c0d", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "sarah.fitness@email.com", true, 55f, "Sarah", 165f, null, "Johnson", false, null, "SARAH.FITNESS@EMAIL.COM", "SARAH.FITNESS@EMAIL.COM", "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==", "0898234567", true, 90f, "f8e7d6c5-4b3a-2f1e-0d9c-8b7a6e5f4d3c", false, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "sarah.fitness@email.com", 58f },
                    { new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), 0, "Marathon runner tracking macros for peak performance. Always looking for high-protein meal ideas.", 2800f, 350f, "b6c7d8e9-f1a2-4b3c-4d5e-6f7a8b9c0d1e", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "mike.healthy@email.com", true, 65f, "Mike", 185f, null, "Williams", false, null, "MIKE.HEALTHY@EMAIL.COM", "MIKE.HEALTHY@EMAIL.COM", "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==", "0899345678", true, 180f, "a9b8c7d6-5e4f-3a2b-1c0d-9e8f7a6b5c4d", false, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "mike.healthy@email.com", 78f },
                    { new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), 0, "Nutritionist helping people find balance. Believer in sustainable healthy habits, not extreme diets.", 2100f, 260f, "c7d8e9f1-a2b3-4c4d-5e6f-7a8b9c0d1e2f", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "emma.wellness@email.com", true, 60f, "Emma", 170f, null, "Davis", false, null, "EMMA.WELLNESS@EMAIL.COM", "EMMA.WELLNESS@EMAIL.COM", "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==", "0897456789", true, 110f, "b1c2d3e4-6f7a-4b5c-2d3e-0f1a8b9c7d6e", false, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "emma.wellness@email.com", 63f }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Brand", "CaloriesPer100g", "CarbsPer100g", "CreatedAt", "CreatedByUserId", "Deleted", "DeletedAt", "FatPer100g", "Name", "ProteinPer100g", "Source", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"), null, 89f, 22.8f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.3f, "Banana", 1.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4b1c2d3-6e7f-4a8b-9c1d-2e3f4a5b6c7d"), null, 370f, 77.2f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 2.9f, "Brown Rice", 7.9f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a4e1f2b3-6c7d-4e8f-9a1b-2c3d4e5f6a7b"), null, 862f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 100f, "Coconut Oil", 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"), null, 368f, 64.2f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 6.1f, "Quinoa", 14.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1e"), null, 80f, 17.8f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.8f, "Ginger", 1.8f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b2c8d9e1-4f5a-4b6c-7d8e-9f1a2b3c4d5e"), null, 588f, 20f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 50f, "Peanut Butter", 25.8f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"), null, 18f, 3.9f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.2f, "Tomato", 0.9f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8c5d6e7-1f2a-4b3c-4d5e-6f7a8b9c1d2e"), null, 86f, 20.1f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.1f, "Sweet Potato", 1.6f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3d9e1f2-5a6b-4c7d-8e9f-1a2b3c4d5e6f"), null, 57f, 14.5f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.3f, "Blueberries", 0.7f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"), null, 31f, 6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.3f, "Bell Pepper", 1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"), null, 34f, 7f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.4f, "Broccoli", 2.8f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"), null, 143f, 0.7f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 9.5f, "Eggs", 12.6f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"), null, 208f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 13f, "Salmon Fillet", 20f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"), null, 29f, 9.3f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.3f, "Lemon", 1.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"), null, 160f, 8.5f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 14.7f, "Avocado", 2f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"), null, 59f, 3.6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.4f, "Greek Yogurt", 10f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"), null, 15f, 3.6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.1f, "Cucumber", 0.7f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"), null, 304f, 82.4f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0f, "Honey", 0.3f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"), null, 579f, 21.6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 49.9f, "Almonds", 21.2f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"), null, 23f, 3.6f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.4f, "Spinach", 2.9f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9d"), null, 36f, 6.3f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.8f, "Parsley", 3f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"), null, 389f, 66.3f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 6.9f, "Oats", 16.9f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("b2c3d4e5-f6a7-8901-bcde-f12345678901"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a1b7c8d9-3e4f-4a5b-6c7d-8e9f1a2b3c4d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a4b1c2d3-6e7f-4a8b-9c1d-2e3f4a5b6c7d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a4e1f2b3-6c7d-4e8f-9a1b-2c3d4e5f6a7b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a7b4c5d6-9e1f-4a2b-3c4d-5e6f7a8b9c1e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b2c8d9e1-4f5a-4b6c-7d8e-9f1a2b3c4d5e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b5c2d3e4-7f8a-4b9c-1d2e-3f4a5b6c7d8e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b8c5d6e7-1f2a-4b3c-4d5e-6f7a8b9c1d2e"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c3d9e1f2-5a6b-4c7d-8e9f-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c6d3e4f5-8a9b-4c1d-2e3f-4a5b6c7d8e9f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c9d6e7f8-2a3b-4c4d-5e6f-7a8b9c1d2e3f"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d1e7f8a9-3b4c-4d5e-6f7a-8b9c1d2e3f4a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d4e1f2a3-6b7c-4d8e-9f1a-2b3c4d5e6f7a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("d7e4f5a6-9b1c-4d2e-3f4a-5b6c7d8e9f1a"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e2f8a9b1-4c5d-4e6f-7a8b-9c1d2e3f4a5b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e5f2a3b4-7c8d-4e9f-1a2b-3c4d5e6f7a8c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("e8f5a6b7-1c2d-4e3f-4a5b-6c7d8e9f1a2b"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f3a9b1c2-5d6e-4f7a-8b9c-1d2e3f4a5b6c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9c"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f6a3b4c5-8d9e-4f1a-2b3c-4d5e6f7a8b9d"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f9a6b7c8-2d3e-4f4a-5b6c-7d8e9f1a2b3c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"));
        }
    }
}
