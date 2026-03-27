using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configs
{
    public class MealEntryConfig : IEntityTypeConfiguration<MealEntry>
    {
        public void Configure(EntityTypeBuilder<MealEntry> builder)
        {
            // Primary Key
            builder.HasKey(me => me.Id);

            // Meal Relationship
            builder
                .HasOne(me => me.Meal)
                .WithMany(me => me.MealEntries) 
                .HasForeignKey(me => me.MealId)
                .OnDelete(DeleteBehavior.Restrict);

            // User Relationship
            builder
                .HasOne(me => me.User)
                .WithMany(me => me.MealEntries) 
                .HasForeignKey(me => me.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            

            
        }
    }
}
