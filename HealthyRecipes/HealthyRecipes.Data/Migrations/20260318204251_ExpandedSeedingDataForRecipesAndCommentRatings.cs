using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExpandedSeedingDataForRecipesAndCommentRatings : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "CreatedAt", "Deleted", "DeletedAt", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Not bad, but I prefer more vegetables in my bowls. A bit too heavy on the rice for me.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), "Good macro split for athletes. I double the chicken portion for extra protein.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Good balanced meal! I recommend my clients add more vegetables to boost the nutrient density.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Calories", "Carbs", "CreatedAt", "Deleted", "DeletedAt", "Difficulty", "Fat", "ImageUrl", "Info", "PrepTime", "Protein", "Servings", "Title", "UpdatedAt", "UserId", "VideoUrl" },
                values: new object[,]
                {
                    { new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2, 0f, null, "Perfectly grilled salmon served over fluffy quinoa with a fresh lemon dressing. Rich in omega-3 fatty acids and complete protein.", 25, 0f, null, "Grilled Salmon with Lemon Quinoa", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), null },
                    { new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, 0f, null, "Refreshing salad with cucumbers, tomatoes, bell peppers, parsley, and olive oil. Light, crisp, and full of Mediterranean flavors.", 10, 0f, null, "Mediterranean Cucumber Salad", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), null },
                    { new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, 0f, null, "Creamy Greek yogurt topped with fresh blueberries, almonds, and a drizzle of honey. A protein-packed breakfast that keeps you full all morning.", 5, 0f, null, "Greek Yogurt Breakfast Bowl", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), null },
                    { new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2, 0f, null, "A vibrant plant-based bowl loaded with roasted sweet potato, fresh spinach, avocado, and a tahini dressing. Nutrient-dense and satisfying.", 35, 0f, null, "Spinach & Sweet Potato Buddha Bowl", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), null },
                    { new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, 0f, null, "Fluffy eggs filled with bell peppers, tomatoes, spinach, and onions. A classic breakfast packed with protein and vitamins.", 15, 0f, null, "Garden Veggie Omelette", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), null },
                    { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, 0f, null, "Creamy oats soaked overnight with banana, peanut butter, and a touch of honey. Prep the night before for an effortless healthy breakfast.", 5, 0f, null, "Banana Peanut Butter Overnight Oats", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), null },
                    { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), 0f, 0f, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 2, 0f, null, "Quick and delicious chicken stir-fry with broccoli, garlic, and ginger in a light sauce. Serve over brown rice for a complete meal.", 20, 0f, null, "Garlic Chicken & Broccoli Stir-Fry", new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), null }
                });

            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "CreatedAt", "Deleted", "DeletedAt", "Rating", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Absolutely love this! The lemon quinoa is the perfect pairing. Made it three times this week.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "This salmon recipe is amazing! The lemon quinoa pairs perfectly. Already made it twice!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), "Light and refreshing after long runs. I add some grilled chicken for extra protein.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "Simple but effective breakfast. I add a scoop of protein powder to hit my macros.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Great plant-based option! I recommend adding chickpeas for extra protein. My clients love this recipe.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "Not usually into plant-based meals but this one actually filled me up. Surprisingly good!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), "Quick and protein-packed! Perfect post-run meal. I add extra veggies for more nutrients.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Perfect pre-yoga breakfast! The peanut butter gives sustained energy. Great for meal prep!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Convenient but a bit sweet for my taste. I'd reduce the honey next time.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 3, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "Perfect pre-workout meal! The peanut butter gives sustained energy. I prep 5 jars every Sunday.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Quick weeknight dinner! I swap the chicken for tofu to keep it plant-based.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Quick and nutritious! Done in 20 minutes, exactly as promised. Perfect for busy weeknights.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"));

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"));

            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "RecipeId", "UserId", "Comment", "CreatedAt", "Deleted", "DeletedAt", "Rating", "UpdatedAt" },
                values: new object[] { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), "Delicious and easy to prepare!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
