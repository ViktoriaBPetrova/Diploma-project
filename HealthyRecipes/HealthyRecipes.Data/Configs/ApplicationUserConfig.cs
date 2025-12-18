using HealthyRecipes.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Configs
{
    internal class ApplicationUserConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasMany(u => u.CreatedCategories)
                      .WithOne(c => c.User)
                      .HasForeignKey(c => c.CreatedBy)
                      .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedRecipes)
                  .WithOne(r => r.User)
                  .HasForeignKey(r => r.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedIngredients)
                  .WithOne(i => i.User)
                  .HasForeignKey(i => i.CreatedByUserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CreatedMealPlans)
                  .WithOne(mp => mp.User)
                  .HasForeignKey(mp => mp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.CommentRatings)
                  .WithOne(cr => cr.User)
                  .HasForeignKey(cr => cr.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.SavedRecipes)
                  .WithOne(sr => sr.User)
                  .HasForeignKey(sr => sr.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.SavedMealPlans)
                  .WithOne(smp => smp.User)
                  .HasForeignKey(smp => smp.UserId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(u => u.Allergies)
                  .WithOne(a => a.User)
                  .HasForeignKey(a => a.UserId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
