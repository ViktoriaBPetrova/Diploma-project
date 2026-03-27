using HealthyRecipes.Data.Configs;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.MealPlanTracking;
using HealthyRecipes.Data.Seeding;
using HealthyRecipes.Data.Seeding.Identity;
using HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanFollowerSeeders;
using HealthyRecipes.Data.Seeding.MappingSeeders.MealPlanMappingSeeders;
using HealthyRecipes.Data.Seeding.MappingSeeders.RecipeMappingSeeders;
using HealthyRecipes.Data.Seeding.MappingSeeders.SavedSeeders;
using HealthyRecipes.Data.Seeding.MappingSeeders.UserInfoSeedes;
using HealthyRecipes.Data.Seeding.MealPlanSeeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Emit;

namespace HealthyRecipes.Data
{
    public class HealthyRecipesDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public HealthyRecipesDbContext(DbContextOptions<HealthyRecipesDbContext> options)
            : base(options)
        {
            
        }


        public DbSet<ApplicationUser> ApplicationUsers { get; init; } = null!;
        public DbSet<Recipe> Recipes { get; init; } = null!;
        public DbSet<Ingredient> Ingredients { get; init; } = null!;
        public DbSet<Category> Categories { get; init; } = null!;

        public DbSet<MealPlan> MealPlans { get; init; } = null!;
        public DbSet<MealPlanDay> MealPlanDays { get; init; } = null!;
        public DbSet<Meal> Meals { get; init; } = null!;

        //Mapping tables
        public DbSet<RecipeMeal> RecipeMeals { get; init; } = null!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; init; } = null!;
        public DbSet<RecipeCategory> RecipeCategories { get; init; } = null!;

        public DbSet<MealPlanCategory> MealPlanCategories { get; init; } = null!;
        public DbSet<MealPlanFollower> MealPlanFollowers { get; init; } = null!;
        public DbSet<MealEntry> MealEntries { get; init; } = null!;
        public DbSet<MealPlanDayEntry> MealPlanDayEntries { get; init; } = null!;

        public DbSet<SavedMealPlan> SavedMealPlans { get; init; } = null!;
        public DbSet<SavedRecipe> SavedRecipes { get; init; } = null!;

        public DbSet<Allergy> Allergies { get; init; } = null!;
        public DbSet<CommentRating> CommentRatings { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new ApplicationUserConfig());
            builder.ApplyConfiguration(new RecipeCategoryConfig());
            builder.ApplyConfiguration(new MealPlanCategoryConfig());
            builder.ApplyConfiguration(new RecipeIngredientConfig());
            builder.ApplyConfiguration(new RecipeMealConfig());
            builder.ApplyConfiguration(new SavedRecipeConfig());
            builder.ApplyConfiguration(new SavedMealPlanConfig());
            builder.ApplyConfiguration(new AllergyConfig());
            builder.ApplyConfiguration(new CommentRatingConfig());
            builder.ApplyConfiguration(new MealPlanDayConfig());
            builder.ApplyConfiguration(new MealConfig());
            builder.ApplyConfiguration(new MealPlanFollowerConfig());
            builder.ApplyConfiguration(new MealEntryConfig());
            builder.ApplyConfiguration(new MealPlanDayEntryConfig());

            // USER SEEDING
            var users = UserSeeder.GenerateUsers().ToArray();
            builder.Entity<ApplicationUser>().HasData(users);

            // INGREDIENT SEEDING
            var ingredients = IngredientSeeder.GenerateIngredients().ToArray();
            builder.Entity<Ingredient>().HasData(ingredients);

            // CATEGORY SEEDING
            var categories = CategorySeeder.GenerateCategories().ToArray();
            builder.Entity<Category>().HasData(categories);

            // RECIPES
            var recipes = RecipeSeeder.GenerateRecipes().ToArray();
            builder.Entity<Recipe>().HasData(recipes);

            // MEAL PLANS
            var mealPlans = MealPlanSeeder.GenerateMealPlans().ToArray();
            builder.Entity<MealPlan>().HasData(mealPlans);

            // MEAL PLAN DAYS
            var mealPlanDays = MealPlanDaySeeder.GenerateMealPlanDays().ToArray();
            builder.Entity<MealPlanDay>().HasData(mealPlanDays);

            // MEALS
            var meals = MealSeeder.GenerateMeals().ToArray();
            builder.Entity<Meal>().HasData(meals);

            // MAPPING ENTITIES
            builder.Entity<RecipeIngredient>().HasData(RecipeIngredientSeeder.GenerateRecipeIngredients().ToArray());
            builder.Entity<RecipeMeal>().HasData(RecipeMealSeeder.GenerateRecipeMeals().ToArray());
            builder.Entity<RecipeCategory>().HasData(RecipeCategorySeeder.GenerateRecipeCategory().ToArray());
            builder.Entity<MealPlanCategory>().HasData(MealPlanCategorySeeder.GenerateMealPlanCategory().ToArray());
            builder.Entity<SavedRecipe>().HasData(SavedRecipeSeeder.GenerateSavedRecipe().ToArray());
            builder.Entity<SavedMealPlan>().HasData(SavedMealPlanSeeder.GenerateSavedRecipe().ToArray());
            builder.Entity<Allergy>().HasData(AllergySeeder.GenerateAllergies().ToArray());
            builder.Entity<CommentRating>().HasData(CommentRatingSeeder.GenerateCommentRatings().ToArray());
            builder.Entity<MealPlanFollower>().HasData(MealPlanFollowerSeeder.GenerateMealPlanFollowers().ToArray());
            builder.Entity<MealEntry>().HasData(MealEntrySeeder.GenerateMealEntries().ToArray());
            builder.Entity<MealPlanDayEntry>().HasData(MealPlanDayEntrySeeder.GenerateMealPlanDayEntries().ToArray());

            //IDENTITY
            var roles = RoleSeeder.GenerateRoles().ToArray();
            builder.Entity<IdentityRole<Guid>>().HasData(roles);

            var userRoles = UserRoleSeeder.GenerateUserRoles().ToArray();
            builder.Entity<IdentityUserRole<Guid>>().HasData(userRoles);

            base.OnModelCreating(builder);

        }
    }
}
