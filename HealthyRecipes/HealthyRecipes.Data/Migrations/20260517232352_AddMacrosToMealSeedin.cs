using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMacrosToMealSeedin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 394.8f, 21.689999f, 24.949999f, 21.81f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111121"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111122"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111123"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111131"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111132"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111133"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.8f, 9.69f, 24.65f, 21.51f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111141"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111142"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111143"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111151"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.8f, 9.69f, 24.65f, 21.51f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111152"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111153"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222212"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222213"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222221"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222222"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222223"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222231"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222232"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222233"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222241"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222242"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222243"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222251"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222252"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222253"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333311"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 527.1f, 81.665f, 11.215f, 28.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333312"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333313"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333321"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.8f, 9.69f, 24.65f, 21.51f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333322"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333323"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333331"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333332"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333333"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333341"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333342"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333343"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333351"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333352"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333353"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444411"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 458.5f, 56.28f, 16.31f, 28.285f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444412"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444413"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444421"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444422"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 700.85004f, 81.655f, 15.924999f, 52.42f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444423"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444431"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.8f, 9.69f, 24.65f, 21.51f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444432"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444433"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444441"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 387.3f, 38.04f, 16.07f, 27.405f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444442"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 428.45f, 19.135f, 16.145f, 52.14f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444443"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 861.2001f, 106.240005f, 38.879997f, 29.09f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444451"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 438.6f, 76.265f, 10.615f, 13.075f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444452"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 799.9f, 61.15f, 38.769997f, 50.41f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444453"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 344.9f, 20.830002f, 26.3f, 10.61f });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111111"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111112"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111113"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111121"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111122"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111123"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111131"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111132"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111133"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111141"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111142"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111143"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111151"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111152"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-4111-8111-111111111153"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222211"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222212"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222213"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222221"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222222"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222223"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222231"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222232"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222233"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222241"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222242"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222243"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222251"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222252"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-4222-8222-222222222253"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333311"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333312"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333313"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333321"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333322"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333323"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333331"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333332"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333333"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333341"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333342"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333343"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333351"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333352"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-4333-8333-333333333353"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444411"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444412"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444413"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444421"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444422"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444423"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444431"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444432"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444433"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444441"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444442"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444443"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444451"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444452"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });

            migrationBuilder.UpdateData(
                table: "Meals",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-8444-444444444453"),
                columns: new[] { "Calories", "Carbs", "Fat", "Protein" },
                values: new object[] { 0f, 0f, 0f, 0f });
        }
    }
}
