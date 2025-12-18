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
    public class MealPlanDayConfig : IEntityTypeConfiguration<MealPlanDay>
    {
        public void Configure(EntityTypeBuilder<MealPlanDay> builder)
        {
            
                builder.HasOne(d => d.MealPlan)
                      .WithMany(mp => mp.MealPlanDays)
                      .HasForeignKey(d => d.MealPlanId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
