using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddJournalEnttities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.AddColumn<DateTime>(
                name: "ConsentGivenAt",
                table: "MealPlanFollowers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ShareJournalPublicly",
                table: "MealPlanFollowers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "ShowOnProfileAsCompleted",
                table: "MealPlanFollowers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "MealEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeelingComment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConsumedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealEntries_Meals_MealId",
                        column: x => x.MealId,
                        principalTable: "Meals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MealPlanDayEntries",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MealPlanDayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OverallFeeling = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPublic = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MealPlanDayEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MealPlanDayEntries_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MealPlanDayEntries_MealPlanDays_MealPlanDayId",
                        column: x => x.MealPlanDayId,
                        principalTable: "MealPlanDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MealEntries",
                columns: new[] { "Id", "ConsumedAt", "CreatedAt", "Deleted", "DeletedAt", "FeelingComment", "IsPublic", "MealId", "PhotoUrl", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("e1444444-1444-4e14-8e14-144444444411"), new DateTime(2025, 4, 18, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified), false, null, "Trying Emma's balanced approach for a change. Let's see how this sustainable eating works!", false, new Guid("44444444-4444-4444-8444-444444444411"), "/uploads/meal-entries/sample/john-emma-breakfast-1.jpg", new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("e1444444-1444-4e14-8e14-144444444412"), new DateTime(2025, 4, 18, 12, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 12, 45, 0, 0, DateTimeKind.Unspecified), false, null, "More balanced than my usual high-protein approach. Feeling good!", false, new Guid("44444444-4444-4444-8444-444444444412"), "/uploads/meal-entries/sample/john-emma-lunch-1.jpg", new DateTime(2025, 4, 18, 12, 45, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("e1444444-1444-4e14-8e14-144444444421"), new DateTime(2025, 4, 19, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null, "This sustainable approach is actually really enjoyable. No restrictive vibes!", false, new Guid("44444444-4444-4444-8444-444444444421"), null, new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111111"), new DateTime(2025, 4, 11, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Starting John's lean bulk plan! Excited to see how this protein-focused approach works for me.", true, new Guid("11111111-1111-4111-8111-111111111111"), "/uploads/meal-entries/sample/sarah-john-breakfast-1.jpg", new DateTime(2025, 4, 11, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111112"), new DateTime(2025, 4, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 13, 30, 0, 0, DateTimeKind.Unspecified), false, null, "More protein than I'm used to, but feeling surprisingly energized!", true, new Guid("11111111-1111-4111-8111-111111111112"), "/uploads/meal-entries/sample/sarah-john-lunch-1.jpg", new DateTime(2025, 4, 11, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111113"), new DateTime(2025, 4, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 19, 30, 0, 0, DateTimeKind.Unspecified), false, null, "Day 1 complete! Adapting to this higher protein intake.", true, new Guid("11111111-1111-4111-8111-111111111113"), null, new DateTime(2025, 4, 11, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111121"), new DateTime(2025, 4, 12, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 7, 45, 0, 0, DateTimeKind.Unspecified), false, null, "Feeling stronger already! This plan is working great.", true, new Guid("11111111-1111-4111-8111-111111111121"), "/uploads/meal-entries/sample/sarah-john-breakfast-2.jpg", new DateTime(2025, 4, 12, 7, 45, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111122"), new DateTime(2025, 4, 12, 12, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), false, null, "Post-workout meal hits different with this protein level!", true, new Guid("11111111-1111-4111-8111-111111111122"), null, new DateTime(2025, 4, 12, 13, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111131"), new DateTime(2025, 4, 13, 7, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 8, 15, 0, 0, DateTimeKind.Unspecified), false, null, "Halfway through the plan! Feeling strong and energized.", true, new Guid("11111111-1111-4111-8111-111111111131"), "/uploads/meal-entries/sample/sarah-john-breakfast-3.jpg", new DateTime(2025, 4, 13, 8, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111133"), new DateTime(2025, 4, 13, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), false, null, "Day 3 complete. This is becoming a habit!", true, new Guid("11111111-1111-4111-8111-111111111133"), null, new DateTime(2025, 4, 13, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111141"), new DateTime(2025, 4, 14, 7, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Day 4 - feeling great! My yoga practice has never been this strong.", true, new Guid("11111111-1111-4111-8111-111111111141"), null, new DateTime(2025, 4, 14, 8, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111142"), new DateTime(2025, 4, 14, 13, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), false, null, "Meal prep is getting easier. Love this plan!", true, new Guid("11111111-1111-4111-8111-111111111142"), "/uploads/meal-entries/sample/sarah-john-lunch-4.jpg", new DateTime(2025, 4, 14, 13, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111151"), new DateTime(2025, 4, 15, 7, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 7, 45, 0, 0, DateTimeKind.Unspecified), false, null, "Final day! Can't believe how much I've learned about protein intake.", true, new Guid("11111111-1111-4111-8111-111111111151"), "/uploads/meal-entries/sample/sarah-john-breakfast-5.jpg", new DateTime(2025, 4, 15, 7, 45, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111152"), new DateTime(2025, 4, 15, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Last meal of the plan. I'm definitely going to keep some of these habits!", true, new Guid("11111111-1111-4111-8111-111111111152"), null, new DateTime(2025, 4, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e2111111-2111-4e21-8e21-211111111153"), new DateTime(2025, 4, 15, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), false, null, "Plan complete! This was an amazing journey. Thank you John for this incredible plan!", true, new Guid("11111111-1111-4111-8111-111111111153"), "/uploads/meal-entries/sample/sarah-john-dinner-5.jpg", new DateTime(2025, 4, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("e3222222-3222-4e32-8e32-322222222211"), new DateTime(2025, 4, 13, 6, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Trying Sarah's plant-based approach. Let's see how this affects my marathon training.", false, new Guid("22222222-2222-4222-8222-222222222211"), "/uploads/meal-entries/sample/mike-sarah-breakfast-1.jpg", new DateTime(2025, 4, 13, 7, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("e3222222-3222-4e32-8e32-322222222212"), new DateTime(2025, 4, 13, 11, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Lighter meal than usual. Not sure if this will fuel my long runs.", false, new Guid("22222222-2222-4222-8222-222222222212"), null, new DateTime(2025, 4, 13, 12, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("e3222222-3222-4e32-8e32-322222222221"), new DateTime(2025, 4, 14, 6, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 6, 45, 0, 0, DateTimeKind.Unspecified), false, null, "Felt low on energy during my morning run. Need more protein for training.", false, new Guid("22222222-2222-4222-8222-222222222221"), "/uploads/meal-entries/sample/mike-sarah-breakfast-2.jpg", new DateTime(2025, 4, 14, 6, 45, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("e4111111-4111-4e41-8e41-411111111111"), new DateTime(2025, 4, 18, 8, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 8, 45, 0, 0, DateTimeKind.Unspecified), false, null, "Love John's structured approach to lean bulking. This is exactly what my clients need!", false, new Guid("11111111-1111-4111-8111-111111111111"), "/uploads/meal-entries/sample/emma-john-breakfast-1.jpg", new DateTime(2025, 4, 18, 8, 45, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("e4111111-4111-4e41-8e41-411111111112"), new DateTime(2025, 4, 18, 12, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Perfect macro balance for sustainable muscle building.", false, new Guid("11111111-1111-4111-8111-111111111112"), null, new DateTime(2025, 4, 18, 13, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("e4111111-4111-4e41-8e41-411111111121"), new DateTime(2025, 4, 19, 8, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), false, null, "Day 2 and loving the consistency. Great for building habits!", false, new Guid("11111111-1111-4111-8111-111111111121"), "/uploads/meal-entries/sample/emma-john-breakfast-2.jpg", new DateTime(2025, 4, 19, 8, 30, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") }
                });

            migrationBuilder.InsertData(
                table: "MealPlanDayEntries",
                columns: new[] { "Id", "CompletedAt", "CreatedAt", "Deleted", "DeletedAt", "IsPublic", "MealPlanDayId", "OverallFeeling", "UpdatedAt", "UserId" },
                values: new object[,]
                {
                    { new Guid("d1444444-1444-4d14-8d14-144444444411"), new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("d6e7f8a9-0b1c-4d2e-3f4a-5b6c7d8e9f0a"), "First day on Emma's balanced nutrition plan. It's a nice change from my usual high-protein focus. The meals feel more sustainable and less restrictive. Still hit my workout hard - maybe you don't need extreme macros to make progress!", new DateTime(2025, 4, 18, 21, 0, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("d1444444-1444-4d14-8d14-144444444412"), new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("e7f8a9b0-1c2d-4e3f-4a5b-6c7d8e9f0a1b"), "Day 2 and I'm really enjoying this approach. Emma's focus on sustainability is eye-opening - this feels like something I could maintain long-term, not just a temporary bulk phase. Great balance of macros without being dogmatic.", new DateTime(2025, 4, 19, 21, 15, 0, 0, DateTimeKind.Unspecified), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") },
                    { new Guid("d2111111-2111-4d21-8d21-211111111111"), new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), false, null, true, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), "First day on John's lean bulk plan complete! The protein intake is higher than I'm used to, but I felt energized throughout the day. My yoga practice was strong and I didn't feel heavy or sluggish. Excited to see how this week goes!", new DateTime(2025, 4, 11, 20, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("d2111111-2111-4d21-8d21-211111111112"), new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified), false, null, true, new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), "Day 2 went even better! I'm adapting to the higher protein and actually enjoying it. Post-workout recovery feels faster. This plan is challenging my preconceptions about protein intake in a good way.", new DateTime(2025, 4, 12, 20, 15, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("d2111111-2111-4d21-8d21-211111111113"), new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified), false, null, true, new Guid("c3d4e5f6-7a8b-4c9d-0e1f-2a3b4c5d6e7f"), "Halfway through and I'm seeing the benefits! Muscle definition is improving and I feel stronger in my practice. John really knows his stuff - this plan is scientifically sound and sustainable.", new DateTime(2025, 4, 13, 19, 45, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("d2111111-2111-4d21-8d21-211111111114"), new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), false, null, true, new Guid("d4e5f6a7-8b9c-4d0e-1f2a-3b4c5d6e7f8a"), "Day 4 complete! I'm noticing real changes - better recovery, more energy, and my strength has improved noticeably. This plan is a game-changer for my yoga practice and overall fitness.", new DateTime(2025, 4, 14, 20, 0, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("d2111111-2111-4d21-8d21-211111111115"), new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), false, null, true, new Guid("e5f6a7b8-9c0d-4e1f-2a3b-4c5d6e7f8a9b"), "Final day complete! This 5-day journey completely changed my perspective on protein and nutrition. I feel stronger, more energized, and my body composition has visibly improved. I'm so grateful for John's expertise - this plan is sustainable and effective. Definitely sharing this publicly to inspire others!", new DateTime(2025, 4, 15, 20, 30, 0, 0, DateTimeKind.Unspecified), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") },
                    { new Guid("d3222222-3222-4d32-8d32-322222222211"), new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("f6a7b8c9-0d1e-4f2a-3b4c-5d6e7f8a9b0c"), "First day trying Sarah's plant-based approach. The meals were lighter than I'm used to. My 10K this morning felt okay but I noticed less energy in the final kilometers. Not sure if this protein level will support my marathon training.", new DateTime(2025, 4, 13, 21, 30, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("d3222222-3222-4d32-8d32-322222222212"), new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("a7b8c9d0-1e2f-4a3b-4c5d-6e7f8a9b0c1d"), "Struggled on today's run. Energy dropped significantly around the 8km mark. Recovery feels slower too. I appreciate the clean eating approach but I don't think plant-based aligns with my endurance training needs right now.", new DateTime(2025, 4, 14, 21, 0, 0, 0, DateTimeKind.Unspecified), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") },
                    { new Guid("d4111111-4111-4d41-8d41-411111111111"), new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("a1b2c3d4-5e6f-4a7b-8c9d-0e1f2a3b4c5d"), "As a nutritionist, I'm impressed with John's macro balance! Day 1 was fantastic - the protein distribution throughout the day maintains steady energy. This is exactly the kind of sustainable approach I recommend to my clients. Perfect for muscle building without extreme restrictions.", new DateTime(2025, 4, 18, 20, 30, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") },
                    { new Guid("d4111111-4111-4d41-8d41-411111111112"), new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified), false, null, false, new Guid("b2c3d4e5-6f7a-4b8c-9d0e-1f2a3b4c5d6e"), "Day 2 reinforces what I love about this plan - it's repeatable and practical. No cravings, steady energy, and the meals are genuinely enjoyable. I'm definitely going to analyze this structure for my client programs!", new DateTime(2025, 4, 19, 20, 45, 0, 0, DateTimeKind.Unspecified), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") }
                });

            migrationBuilder.InsertData(
                table: "MealPlanFollowers",
                columns: new[] { "MealPlanId", "UserId", "CompletedAt", "ConsentGivenAt", "Deleted", "DeletedAt", "DropoutReason", "ExpectedCompletionDate", "HasSeenCompletionPrompt", "IsActive", "PauseReason", "ShareJournalPublicly", "ShowOnProfileAsCompleted", "StartedAt", "Status", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12"), new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 4, 15, 2, 0, 0, 0, DateTimeKind.Unspecified), false, null, null, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, true, true, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2025, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23"), null, new DateTime(2025, 4, 14, 1, 0, 0, 0, DateTimeKind.Unspecified), false, null, "Plant-based diet wasn't compatible with my marathon training needs. Low energy on runs.", new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), true, false, null, false, false, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34"), null, null, false, null, null, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, null, false, false, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), null, null, false, null, null, new DateTime(2025, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), false, true, null, false, false, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MealEntries_MealId",
                table: "MealEntries",
                column: "MealId");

            migrationBuilder.CreateIndex(
                name: "IX_MealEntries_UserId",
                table: "MealEntries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDayEntries_MealPlanDayId",
                table: "MealPlanDayEntries",
                column: "MealPlanDayId");

            migrationBuilder.CreateIndex(
                name: "IX_MealPlanDayEntries_UserId",
                table: "MealPlanDayEntries",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MealEntries");

            migrationBuilder.DropTable(
                name: "MealPlanDayEntries");

            migrationBuilder.DeleteData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("c5e8a3b4-2f6d-4a7c-9b3e-8c4d6f9a0b12") });

            migrationBuilder.DeleteData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("e4a2b3c4-5d6e-48b1-9c8d-1b2e3f4a5b6c"), new Guid("d6f9b4c5-3a7e-4b8d-9c4f-9d5e7a1b2c23") });

            migrationBuilder.DeleteData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e7a1c5d6-4b8f-4c9e-9d5a-0e6f8b2c3d34") });

            migrationBuilder.DeleteData(
                table: "MealPlanFollowers",
                keyColumns: new[] { "MealPlanId", "UserId" },
                keyValues: new object[] { new Guid("a6c4d5e6-7f8a-41d3-2e1f-3d4a5b6c7d8e"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01") });

            migrationBuilder.DropColumn(
                name: "ConsentGivenAt",
                table: "MealPlanFollowers");

            migrationBuilder.DropColumn(
                name: "ShareJournalPublicly",
                table: "MealPlanFollowers");

            migrationBuilder.DropColumn(
                name: "ShowOnProfileAsCompleted",
                table: "MealPlanFollowers");

            migrationBuilder.InsertData(
                table: "MealPlanFollowers",
                columns: new[] { "MealPlanId", "UserId", "CompletedAt", "Deleted", "DeletedAt", "DropoutReason", "ExpectedCompletionDate", "HasSeenCompletionPrompt", "IsActive", "PauseReason", "StartedAt", "Status", "UpdatedAt" },
                values: new object[] { new Guid("d3f9a1b2-4c5e-47a9-8b7c-0a1d2e3f4b5c"), new Guid("e8a7c3b4-1f5d-4a6c-9b2e-7c3d5f8a9b01"), null, false, null, null, null, false, true, null, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, new DateTime(2025, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
