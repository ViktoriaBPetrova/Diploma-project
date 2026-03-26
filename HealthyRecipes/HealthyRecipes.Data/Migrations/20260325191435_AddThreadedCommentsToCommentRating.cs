using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddThreadedCommentsToCommentRating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentRatings",
                table: "CommentRatings");

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

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "CommentRatings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CommentRatings",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "IsPinned",
                table: "CommentRatings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ParentCommentId",
                table: "CommentRatings",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentRatings",
                table: "CommentRatings",
                column: "Id");

            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "Id", "Comment", "CreatedAt", "Deleted", "DeletedAt", "IsPinned", "ParentCommentId", "Rating", "RecipeId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("10000000-0000-0000-0000-000000000001"), "This salmon recipe is amazing! The lemon quinoa pairs perfectly. Already made it twice!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("10000000-0000-0000-0000-000000000002"), "Simple but effective breakfast. I add a scoop of protein powder to hit my macros.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("b4d8e5f6-9a1b-4c2d-3e4f-5a6b7c8d9e1f"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("10000000-0000-0000-0000-000000000003"), "Not usually into plant-based meals but this one actually filled me up. Surprisingly good!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("10000000-0000-0000-0000-000000000004"), "Perfect pre-workout meal! The peanut butter gives sustained energy. I prep 5 jars every Sunday.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("10000000-0000-0000-0000-000000000005"), "Good macro split for athletes. I double the chicken portion for extra protein.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("10000000-0000-0000-0000-000000000006"), "Quick and protein-packed! Perfect post-run meal. I add extra veggies for more nutrients.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("10000000-0000-0000-0000-000000000007"), "Light and refreshing after long runs. I add some grilled chicken for extra protein.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("10000000-0000-0000-0000-000000000008"), "Not bad, but I prefer more vegetables in my bowls. A bit too heavy on the rice for me.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 1, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("10000000-0000-0000-0000-000000000009"), "Absolutely love this! The lemon quinoa is the perfect pairing. Made it three times this week.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, true, null, 5, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("10000000-0000-0000-0000-000000000010"), "Perfect pre-yoga breakfast! The peanut butter gives sustained energy. Great for meal prep!", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("10000000-0000-0000-0000-000000000011"), "Quick weeknight dinner! I swap the chicken for tofu to keep it plant-based.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("10000000-0000-0000-0000-000000000012"), "Good balanced meal! I recommend my clients add more vegetables to boost the nutrient density.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, true, null, 4, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("10000000-0000-0000-0000-000000000013"), "Great plant-based option! I recommend adding chickpeas for extra protein. My clients love this recipe.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("10000000-0000-0000-0000-000000000014"), "Convenient but a bit sweet for my taste. I'd reduce the honey next time.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 3, new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("10000000-0000-0000-0000-000000000015"), "Quick and nutritious! Done in 20 minutes, exactly as promised. Perfect for busy weeknights.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("20000000-0000-0000-0000-000000000001"), "I totally agree! I add extra lemon zest to mine for even more flavor. Great recipe!", new DateTime(2025, 12, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("10000000-0000-0000-0000-000000000009"), null, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("20000000-0000-0000-0000-000000000002"), "Thanks Emma! Great idea about adding more vegetables. I'll update the recipe with some veggie variations.", new DateTime(2025, 12, 18, 4, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("10000000-0000-0000-0000-000000000012"), null, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 18, 4, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("20000000-0000-0000-0000-000000000004"), "Same here! I also prep mine on Sundays. Such a time-saver during the week.", new DateTime(2025, 12, 18, 3, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("10000000-0000-0000-0000-000000000004"), null, new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 18, 3, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("20000000-0000-0000-0000-000000000005"), "Love that tofu swap idea! I've tried it with tempeh too and it works great.", new DateTime(2025, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("10000000-0000-0000-0000-000000000011"), null, new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new DateTime(2025, 12, 18, 5, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("20000000-0000-0000-0000-000000000003"), "Ooh, lemon zest sounds amazing! I'll try that next time.", new DateTime(2025, 12, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("20000000-0000-0000-0000-000000000001"), null, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 18, 6, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentRatings_ParentCommentId",
                table: "CommentRatings",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentRatings_RecipeId",
                table: "CommentRatings",
                column: "RecipeId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentRatings_CommentRatings_ParentCommentId",
                table: "CommentRatings",
                column: "ParentCommentId",
                principalTable: "CommentRatings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentRatings_CommentRatings_ParentCommentId",
                table: "CommentRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommentRatings",
                table: "CommentRatings");

            migrationBuilder.DropIndex(
                name: "IX_CommentRatings_ParentCommentId",
                table: "CommentRatings");

            migrationBuilder.DropIndex(
                name: "IX_CommentRatings_RecipeId",
                table: "CommentRatings");

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000007"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000008"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000010"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000013"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000014"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("20000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("20000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("20000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("20000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000011"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000012"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("20000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyColumnType: "uniqueidentifier",
                keyValue: new Guid("10000000-0000-0000-0000-000000000009"));

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CommentRatings");

            migrationBuilder.DropColumn(
                name: "IsPinned",
                table: "CommentRatings");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "CommentRatings");

            migrationBuilder.AlterColumn<int>(
                name: "Rating",
                table: "CommentRatings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommentRatings",
                table: "CommentRatings",
                columns: new[] { "RecipeId", "UserId" });

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
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Not bad, but I prefer more vegetables in my bowls. A bit too heavy on the rice for me.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 1, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), "Good macro split for athletes. I double the chicken portion for extra protein.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Good balanced meal! I recommend my clients add more vegetables to boost the nutrient density.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), "Quick weeknight dinner! I swap the chicken for tofu to keep it plant-based.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 4, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("f8b3c9d1-4e5f-4a6b-7c8d-9e1f2a3b4c5d"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), "Quick and nutritious! Done in 20 minutes, exactly as promised. Perfect for busy weeknights.", new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, 5, new DateTime(2025, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
