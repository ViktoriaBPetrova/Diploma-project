using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreSeedingForComments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CommentRatings",
                columns: new[] { "Id", "Comment", "CreatedAt", "Deleted", "DeletedAt", "IsPinned", "ParentCommentId", "Rating", "RecipeId", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("30000000-0000-0000-0000-000000000001"), "This recipe is spam! Total scam, don't try it! Visit my website for real recipes!", new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 1, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("30000000-0000-0000-0000-000000000002"), "Check out my website for weight loss pills! www.spam-site.com - Get 50% off today!", new DateTime(2025, 12, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, null, new Guid("c5e9f6a7-1b2c-4d3e-4f5a-6b7c8d9e1f2a"), new DateTime(2025, 12, 19, 2, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("30000000-0000-0000-0000-000000000003"), "You're such an idiot for not liking this recipe. Stupid people like you shouldn't be commenting on food.", new DateTime(2025, 12, 19, 4, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("10000000-0000-0000-0000-000000000008"), null, new Guid("f2d6e3b9-9d5a-4b28-9c6f-8e0f3a7b6101"), new DateTime(2025, 12, 19, 4, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("30000000-0000-0000-0000-000000000004"), "This salmon recipe will cure your diabetes! No need for insulin anymore! I threw away my medication after eating this!", new DateTime(2025, 12, 19, 6, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 5, new Guid("a3c7d4e5-8f9a-4b1c-2d3e-4f5a6b7c8d9e"), new DateTime(2025, 12, 19, 6, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("30000000-0000-0000-0000-000000000005"), "This recipe is lame and totally sucks. What a waste of time. Not worth trying at all.", new DateTime(2025, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 1, new Guid("e7a2b8c9-3d4e-4f5a-6b7c-8d9e1f2a3b4c"), new DateTime(2025, 12, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("30000000-0000-0000-0000-000000000006"), "Fake news! This is clickbait garbage. Pure spam. I hate it! Don't believe these lies!", new DateTime(2025, 12, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 1, new Guid("a9c4d1e2-5f6a-4b7c-8d9e-1f2a3b4c5d6e"), new DateTime(2025, 12, 19, 10, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("30000000-0000-0000-0000-000000000007"), "Good recipe but mine is better! Follow my Instagram @fitnessguru for REAL healthy recipes. Link in bio!", new DateTime(2025, 12, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, null, 4, new Guid("d6f1a7b8-2c3d-4e4f-5a6b-7c8d9e1f2a3b"), new DateTime(2025, 12, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000006"));

            migrationBuilder.DeleteData(
                table: "CommentRatings",
                keyColumn: "Id",
                keyValue: new Guid("30000000-0000-0000-0000-000000000007"));
        }
    }
}
