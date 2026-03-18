using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedSeedingDataForMealPlans : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"));

            migrationBuilder.InsertData(
                table: "MealPlanDays",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "DayNumber", "DayOfWeek", "Deleted", "DeletedAt", "Fat", "MealPlanId", "Protein", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, null, 0f, new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, false, null, 0f, new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, false, null, 0f, new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, false, null, 0f, new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MealPlans",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Description", "Fat", "Name", "Protein", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "A sustainable, well-balanced meal plan for overall health and wellness. No extreme dieting required.", 0f, "Emma's Balanced Nutrition Guide", 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "A complete week of nutritious plant-based meals. Perfect for yoga practitioners and clean eating enthusiasts.", 0f, "Sarah's Plant-Based Week", 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "High-protein, high-carb meal plan designed for endurance athletes and marathon training.", 0f, "Mike's Marathon Training Plan", 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Fat", "MealPlanDayId", "Protein", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-4111-8111-111111111111"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111112"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111113"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "MealPlanDays",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "DayNumber", "DayOfWeek", "Deleted", "DeletedAt", "Fat", "MealPlanId", "Protein", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, false, null, 0f, new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, null, 0f, new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, false, null, 0f, new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, false, null, 0f, new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, false, null, 0f, new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, false, null, 0f, new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, false, null, 0f, new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 4, false, null, 0f, new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, 5, false, null, 0f, new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, false, null, 0f, new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, false, null, 0f, new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, null, 0f, new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, false, null, 0f, new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, false, null, 0f, new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, false, null, 0f, new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Fat", "MealPlanDayId", "Protein", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-4111-8111-111111111121"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111122"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111123"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111131"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111132"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111133"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111141"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111142"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111143"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111151"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111152"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111153"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RecipeMeals",
                columns: new[] { "MealId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-4111-8111-111111111113"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111111"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111112"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Fat", "MealPlanDayId", "Protein", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("22222222-2222-4222-8222-222222222211"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222212"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222213"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222221"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222222"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222223"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222231"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222232"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222233"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222241"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222242"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222243"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222251"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222252"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222253"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333311"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333312"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333313"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333321"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333322"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333323"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333331"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333332"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333333"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333341"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333342"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333343"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333351"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333352"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333353"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444411"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444412"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444413"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444421"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444422"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444423"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444431"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444432"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444433"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444441"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444442"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444443"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444451"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444452"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444453"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"), 0f, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RecipeMeals",
                columns: new[] { "MealId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-4111-8111-111111111132"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111152"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111121"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111141"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111133"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111151"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111131"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111123"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111142"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111153"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111122"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("11111111-1111-4111-8111-111111111143"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333323"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333342"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444412"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444433"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444452"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222213"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222232"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222243"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222253"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444413"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444432"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444453"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222211"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222223"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222231"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222251"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333341"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444411"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444441"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222212"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222222"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222233"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222242"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222252"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444423"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444443"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333321"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444431"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222221"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("22222222-2222-4222-8222-222222222241"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333311"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333331"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333351"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444421"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444451"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333312"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333332"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333343"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333353"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444422"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333313"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333322"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333333"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("33333333-3333-4333-8333-333333333352"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("44444444-4444-4444-8444-444444444442"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111113"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111132"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111152"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333323"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333342"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444412"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444433"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444452"), new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222213"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222232"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222243"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222253"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444413"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444432"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444453"), new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111121"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111141"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222211"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222223"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222231"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222251"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333341"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444411"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444441"), new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222212"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222222"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222233"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222242"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222252"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444423"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444443"), new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111111"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111133"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111151"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333321"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444431"), new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111131"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222221"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("22222222-2222-4222-8222-222222222241"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333311"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333331"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333351"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444421"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444451"), new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111112"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111123"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111142"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111153"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333312"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333332"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333343"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333353"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444422"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111122"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("11111111-1111-4111-8111-111111111143"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333313"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333322"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333333"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("33333333-3333-4333-8333-333333333352"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("44444444-4444-4444-8444-444444444442"), new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d") });

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111121"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111122"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111123"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111131"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111132"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111133"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111141"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111142"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111143"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111151"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111152"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111153"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222212"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222213"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222221"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222223"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222231"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222232"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222233"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222241"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222242"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222243"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222251"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222252"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222253"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333311"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333312"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333313"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333321"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333322"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333323"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333331"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333332"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333333"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333341"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333342"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333343"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333351"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333352"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333353"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444411"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444412"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444413"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444421"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444422"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444423"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444431"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444432"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444433"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444441"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444442"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444443"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444451"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444452"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444453"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a3b4c5d6-7e8f-4a9b-0c1d-2e3f4a5b6c7d"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a9b0c1d2-3e4f-4a5b-6c7d-8e9f0a1b2c3d"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b0c1d2e3-4f5a-4b6c-7d8e-9f0a1b2c3d4e"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b4c5d6e7-8f9a-4b0c-1d2e-3f4a5b6c7d8e"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("b8c9d0e1-2f3a-4b4c-5d6e-7f8a9b0c1d2e"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c5d6e7f8-9a0b-4c1d-2e3f-4a5b6c7d8e9f"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("c9d0e1f2-3a4b-4c5d-6e7f-8a9b0c1d2e3f"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d0e1f2a3-4b5c-4d6e-7f8a-9b0c1d2e3f4a"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e1f2a3b4-5c6d-4e7f-8a9b-0c1d2e3f4a5b"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f2a3b4c5-6d7e-4f8a-9b0c-1d2e3f4a5b6c"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("f8a9b0c1-2d3e-4f4a-5b6c-7d8e9f0a1b2c"));

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"));

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"));

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("f5b3c4d5-6e7f-49c2-1d9e-2c3f4a5b6c7d"));

            migrationBuilder.InsertData(
                table: "Meals",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Fat", "MealPlanDayId", "Protein", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 0f, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 2, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "RecipeMeals",
                columns: new[] { "MealId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
