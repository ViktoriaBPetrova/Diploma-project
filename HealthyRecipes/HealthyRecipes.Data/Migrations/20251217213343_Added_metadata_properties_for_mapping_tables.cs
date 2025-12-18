using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HealthyRecipes.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_metadata_properties_for_mapping_tables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SavedRecipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SavedRecipes",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SavedRecipes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SavedRecipes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SavedMealPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "SavedMealPlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "SavedMealPlans",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "SavedMealPlans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecipeMeals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RecipeMeals",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RecipeMeals",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RecipeMeals",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RecipeIngredients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RecipeIngredients",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "RecipeCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "RecipeCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "RecipeCategories",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "RecipeCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Allergies",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Allergies",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SavedRecipes");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SavedRecipes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SavedRecipes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SavedRecipes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SavedMealPlans");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "SavedMealPlans");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "SavedMealPlans");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "SavedMealPlans");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecipeMeals");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RecipeMeals");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RecipeMeals");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RecipeMeals");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RecipeIngredients");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "RecipeCategories");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Allergies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Allergies");
        }
    }
}
