using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configs
{
    public class MealPlanDayEntryConfig : IEntityTypeConfiguration<MealPlanDayEntry>
    {
        public void Configure(EntityTypeBuilder<MealPlanDayEntry> builder)
        {
            // Primary Key
            builder.HasKey(mpde => mpde.Id);

            // MealPlanDay Relationship
            builder
                .HasOne(mpde => mpde.MealPlanDay)
                .WithMany(mpde => mpde.MealPlanDayEntries) 
                .HasForeignKey(mpde => mpde.MealPlanDayId)
                .OnDelete(DeleteBehavior.Restrict);

            // User Relationship
            builder
                .HasOne(mpde => mpde.User)
                .WithMany(mpde => mpde.MealPlanDayEntries) 
                .HasForeignKey(mpde => mpde.UserId)
                .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
