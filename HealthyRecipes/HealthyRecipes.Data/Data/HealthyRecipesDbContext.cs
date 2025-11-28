using HealthyRecipes.Data.Data.Entities;
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

        public DbSet<RecipeMeal> RecipeMeals { get; init; } = null!;
        public DbSet<RecipeIngredient> RecipeIngredients { get; init; } = null!;
        public DbSet<RecipeCategory> RecipeCategories { get; init; } = null!;

        public DbSet<SavedMealPlan> SavedMealPlans { get; init; } = null!;
        public DbSet<SavedRecipe> SavedRecipes { get; init; } = null!;

        public DbSet<Allergy> Allergies { get; init; } = null!;
        public DbSet<CommentRating> CommentRatings { get; init; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // -----------------------------
            // ApplicationUser relationships
            // -----------------------------
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasMany(u => u.CreatedCategories)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.CreatedRecipes)
                      .WithOne(r => r.User)
                      .HasForeignKey(r => r.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.CreatedIngredients)
                      .WithOne(i => i.User)
                      .HasForeignKey(i => i.CreatedByUserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.CreatedMealPlans)
                      .WithOne(mp => mp.User)
                      .HasForeignKey(mp => mp.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.CommentRatings)
                      .WithOne(cr => cr.User)
                      .HasForeignKey(cr => cr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.SavedRecipes)
                      .WithOne(sr => sr.User)
                      .HasForeignKey(sr => sr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.SavedMealPlans)
                      .WithOne(smp => smp.User)
                      .HasForeignKey(smp => smp.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(u => u.Allergies)
                      .WithOne(a => a.User)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // Category ↔ Recipe (many-to-many)
            // -----------------------------
            builder.Entity<RecipeCategory>(entity =>
            {
                entity.HasKey(rc => new { rc.RecipeId, rc.CategoryId });

                entity.HasOne(rc => rc.Recipe)
                      .WithMany(r => r.RecipeCategories)
                      .HasForeignKey(rc => rc.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(rc => rc.Category)
                      .WithMany(c => c.RecipeCategories)
                      .HasForeignKey(rc => rc.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // Ingredient ↔ Recipe (many-to-many with extra field)
            // -----------------------------
            builder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

                entity.HasOne(ri => ri.Recipe)
                      .WithMany(r => r.RecipeIngredients)
                      .HasForeignKey(ri => ri.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(ri => ri.Ingredient)
                      .WithMany(i => i.RecipeIngredients)
                      .HasForeignKey(ri => ri.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);

                
            });

            // -----------------------------
            // Recipe ↔ Meal (many-to-many)
            // -----------------------------
            builder.Entity<RecipeMeal>(entity =>
            {
                entity.HasKey(rm => new { rm.RecipeId, rm.MealId });

                entity.HasOne(rm => rm.Recipe)
                      .WithMany(r => r.RecipeMeals)
                      .HasForeignKey(rm => rm.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(rm => rm.Meal)
                      .WithMany(m => m.RecipeMeals)
                      .HasForeignKey(rm => rm.MealId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // SavedRecipe
            // -----------------------------
            builder.Entity<SavedRecipe>(entity =>
            {
                entity.HasKey(sr => new { sr.RecipeId, sr.UserId });

                entity.HasOne(sr => sr.Recipe)
                      .WithMany(r => r.SavedRecipes)
                      .HasForeignKey(sr => sr.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(sr => sr.User)
                      .WithMany(u => u.SavedRecipes)
                      .HasForeignKey(sr => sr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // SavedMealPlan
            // -----------------------------
            builder.Entity<SavedMealPlan>(entity =>
            {
                entity.HasKey(smp => new { smp.MealPlanId, smp.UserId });

                entity.HasOne(smp => smp.MealPlan)
                      .WithMany(mp => mp.SavedMealPlans)
                      .HasForeignKey(smp => smp.MealPlanId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(smp => smp.User)
                      .WithMany(u => u.SavedMealPlans)
                      .HasForeignKey(smp => smp.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // Allergy
            // -----------------------------
            builder.Entity<Allergy>(entity =>
            {
                entity.HasKey(a => new { a.IngredientId, a.UserId });

                entity.HasOne(a => a.Ingredient)
                      .WithMany(i => i.Allergies)
                      .HasForeignKey(a => a.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(a => a.User)
                      .WithMany(u => u.Allergies)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            // -----------------------------
            // CommentRating
            // -----------------------------
            builder.Entity<CommentRating>(entity =>
            {
                entity.HasKey(cr => new { cr.RecipeId, cr.UserId });

                entity.HasOne(cr => cr.Recipe)
                      .WithMany(r => r.CommentRatings)
                      .HasForeignKey(cr => cr.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(cr => cr.User)
                      .WithMany(u => u.CommentRatings)
                      .HasForeignKey(cr => cr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

               
            });

            // -----------------------------
            // MealPlan ↔ MealPlanDay ↔ Meal
            // -----------------------------
            builder.Entity<MealPlanDay>(entity =>
            {
                entity.HasOne(d => d.MealPlan)
                      .WithMany(mp => mp.MealPlanDays)
                      .HasForeignKey(d => d.MealPlanId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            builder.Entity<Meal>(entity =>
            {
                entity.HasOne(m => m.MealPlanDay)
                      .WithMany(d => d.Meals)
                      .HasForeignKey(m => m.MealPlanDayId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }







    }
}
