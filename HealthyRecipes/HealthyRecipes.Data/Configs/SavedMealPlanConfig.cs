using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Configs
{
    public class SavedMealPlanConfig : IEntityTypeConfiguration<SavedMealPlan>
    {
        public void Configure(EntityTypeBuilder<SavedMealPlan> builder)
        {
            
                builder.HasKey(smp => new { smp.MealPlanId, smp.UserId });

                builder.HasOne(smp => smp.MealPlan)
                      .WithMany(mp => mp.SavedMealPlans)
                      .HasForeignKey(smp => smp.MealPlanId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(smp => smp.User)
                      .WithMany(u => u.SavedMealPlans)
                      .HasForeignKey(smp => smp.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
