using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configs
{
    public class MealPlanFollowerConfig : IEntityTypeConfiguration<MealPlanFollower>
    {
        public void Configure(EntityTypeBuilder<MealPlanFollower> builder)
        {
            // Composite Primary Key
            builder.HasKey(mpf => new { mpf.UserId, mpf.MealPlanId });

            // User Relationship
            builder
                .HasOne(mpf => mpf.User)
                .WithMany(u => u.MealPlansFollowed)
                .HasForeignKey(mpf => mpf.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // MealPlan Relationship
            builder
                .HasOne(mpf => mpf.MealPlan)
                .WithMany(mp => mp.MealPlanFollowers)
                .HasForeignKey(mpf => mpf.MealPlanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
