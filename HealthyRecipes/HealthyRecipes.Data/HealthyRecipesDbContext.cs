using HealthyRecipes.Data.Configs;
using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

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

        public DbSet<SavedMealPlan> SavedMealPlans { get; init; } = null!;
        public DbSet<SavedRecipe> SavedRecipes { get; init; } = null!;

        public DbSet<Allergy> Allergies { get; init; } = null!;
        public DbSet<CommentRating> CommentRatings { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            
            builder.ApplyConfiguration(new ApplicationUserConfig());
            builder.ApplyConfiguration(new RecipeCategoryConfig());
            builder.ApplyConfiguration(new RecipeIngredientConfig());
            builder.ApplyConfiguration(new RecipeMealConfig());
            builder.ApplyConfiguration(new SavedRecipeConfig());
            builder.ApplyConfiguration(new SavedMealPlanConfig());
            builder.ApplyConfiguration(new AllergyConfig());
            builder.ApplyConfiguration(new CommentRatingConfig());
            builder.ApplyConfiguration(new MealPlanDayConfig());
            builder.ApplyConfiguration(new MealConfig());

            base.OnModelCreating(builder);

        }







    }
}
