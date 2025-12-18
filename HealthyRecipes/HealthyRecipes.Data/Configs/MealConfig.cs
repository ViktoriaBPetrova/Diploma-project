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
    public class MealConfig : IEntityTypeConfiguration<Meal>
    {
        public void Configure(EntityTypeBuilder<Meal> builder)
        {
            
                builder.HasOne(m => m.MealPlanDay)
                      .WithMany(d => d.Meals)
                      .HasForeignKey(m => m.MealPlanDayId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
