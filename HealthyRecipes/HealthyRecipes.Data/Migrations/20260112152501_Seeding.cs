using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Bio", "Calories", "CarbsGoal", "ConcurrencyStamp", "CreatedAt", "Deleted", "DeletedAt", "Email", "EmailConfirmed", "FatGoal", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProteinGoal", "SecurityStamp", "TwoFactorEnabled", "UpdatedAt", "UserName", "Weight" },
                values: new object[,]
                {
                    { new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"), 0, "System administrator", 2000f, 250f, "e4a36463-b39d-4ac6-b748-4d81e8e7e8e9", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "admin@email.com", true, 70f, "Anna", 167f, "Stone", false, null, "ADMIN@EMAIL.COM", "ADMIN@EMAIL.COM", "AQAAAAIAAYagAAAAEDZoKDzNOFTI2VDaWN/Fs6od0Ie+BN4qIF2V4oopqWQRBgA56Rs8YTIG2uZISte5aw==", "0897123456", true, 100f, "d6c5b4a3-2f1e-0d9c-8b7a-6e5f4d3c2b1a", false, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@email.com", 60f },
                    { new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), 0, "Fitness enthusiast", 2500f, 300f, "67a287df-fd85-4a1c-8603-fb50a54ca624", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "user@email.com", true, 60f, "John", 180f, "Doe", false, null, "USER@EMAIL.COM", "USER@EMAIL.COM", "AQAAAAIAAYagAAAAENN8Osd/COD+BNhPiVwcSRWSVLp2nqpbYCazhXnuqSertPmq3ikXhCj0IhLt1DfEVg==", "0897123456", true, 150f, "a1b2c3d4-5e6f-7a8b-9c0d-1e2f3a4b5c6d", false, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@email.com", 80f }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "Deleted", "DeletedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("8f4c9a61-3f9c-4e4b-8a13-91aaf29e7c01"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Main Dish", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b61f58e9-2d69-4f4a-b1e0-4bfa1c6c3a02"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Healthy", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c7a5d8c2-87d6-4c18-9c62-1fd9f8c73a03"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "High Protein", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d49c3a10-bd9c-4fa7-8a77-3cb62f4d0a04"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Easy & Quick", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7b29d63-5eaa-4e8a-9a91-9c27f5c31a05"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Meal Prep", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Brand", "CaloriesPer100g", "CarbsPer100g", "CreatedAt", "CreatedByUserId", "Deleted", "DeletedAt", "FatPer100g", "Name", "ProteinPer100g", "Source", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"), null, 40f, 9.3f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.1f, "Onion", 1.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), null, 120f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 2.6f, "Chicken Breast", 22.5f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), null, 149f, 33.1f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.5f, "Garlic", 6.4f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), null, 365f, 80f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 0.7f, "White Rice", 7.1f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), null, 884f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, 100f, "Olive Oil", 0f, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Allergies",
                columns: new[] { "IngredientId", "UserId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MealPlans",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Description", "Fat", "Name", "Protein", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, "A meal plan focused on lean muscle gain.", 0f, "John's Lean Bulk Plan", 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Difficulty", "Fat", "Info", "PrepTime", "Protein", "UpdatedAt", "UserId" },
                values: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, 0f, "A healthy and high-protein chicken and rice bowl with sautéed onion and garlic. Perfect for meal prep and quick lunches.", 30, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "CreatedAt", "Deleted", "DeletedAt", "Rating", "UpdatedAt" },
                values: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "Delicious and easy to prepare!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "MealPlanDays",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "DayNumber", "DayOfWeek", "Deleted", "DeletedAt", "Fat", "MealPlanId", "Protein", "UpdatedAt" },
                values: new object[] { new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), 0f, 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, false, null, 0f, new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), 0f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RecipeCategories",
                columns: new[] { "CategoryId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("c7a5d8c2-87d6-4c18-9c62-1fd9f8c73a03"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RecipeIngredients",
                columns: new[] { "IngredientId", "RecipeId", "CreatedAt", "Deleted", "DeletedAt", "QuantityInGrams", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 200f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 150f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 10f, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SavedMealPlans",
                columns: new[] { "MealPlanId", "UserId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "SavedRecipes",
                columns: new[] { "RecipeId", "UserId", "CreatedAt", "Deleted", "DeletedAt", "UpdatedAt" },
                values: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Allergies",
                keyColumns: new[] { "IngredientId", "UserId" },
                keyValues: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b4f6d2c1-3a8e-4b9c-9d0f-5a6b7c8d9e02"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("8f4c9a61-3f9c-4e4b-8a13-91aaf29e7c01"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("b61f58e9-2d69-4f4a-b1e0-4bfa1c6c3a02"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("d49c3a10-bd9c-4fa7-8a77-3cb62f4d0a04"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e7b29d63-5eaa-4e8a-9a91-9c27f5c31a05"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("7a9cde14-1e39-4f2b-9d4c-6a3e6d01c0aa"));

            migrationBuilder.DeleteData(
                table: "RecipeCategories",
                keyColumns: new[] { "CategoryId", "RecipeId" },
                keyValues: new object[] { new Guid("c7a5d8c2-87d6-4c18-9c62-1fd9f8c73a03"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeIngredients",
                keyColumns: new[] { "IngredientId", "RecipeId" },
                keyValues: new object[] { new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "RecipeMeals",
                keyColumns: new[] { "MealId", "RecipeId" },
                keyValues: new object[] { new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"), new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101") });

            migrationBuilder.DeleteData(
                table: "SavedMealPlans",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "SavedRecipes",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c7a5d8c2-87d6-4c18-9c62-1fd9f8c73a03"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("a3b71c2a-5e3f-4d9c-9b5a-9b92d2d89e10"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("b8e5b40c-44b3-4a1a-9d2f-2bb0d0e07d55"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("c2e0b6b7-9a8a-4b92-bac3-9e77a32b9c01"));

            migrationBuilder.DeleteData(
                table: "Ingredients",
                keyColumn: "Id",
                keyValue: new Guid("f5c4b6e9-52c1-4a9e-9e15-1d7e6a2a91c2"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-e5f6-4a7b-8c9d-1a2b3c4d5e6f"));

            migrationBuilder.DeleteData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("f6e5d4c3-b2a1-0f9e-8d7c-6b5a4c3d2e1f"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"));

            migrationBuilder.DeleteData(
                table: "MealPlanDays",
                keyColumn: "Id",
                keyValue: new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"));

            migrationBuilder.DeleteData(
                table: "MealPlans",
                keyColumn: "Id",
                keyValue: new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"));
        }
    }
}
