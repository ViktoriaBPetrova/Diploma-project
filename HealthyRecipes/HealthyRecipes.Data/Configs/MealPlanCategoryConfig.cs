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
    public class MealPlanCategoryConfig : IEntityTypeConfiguration<MealPlanCategory>
    {
        public void Configure(EntityTypeBuilder<MealPlanCategory> builder)
        {

            builder.HasKey(mc => new { mc.MealPlanId, mc.CategoryId });

            builder.HasOne(mc => mc.MealPlan)
                  .WithMany(m => m.MealPlanCategories)
                  .HasForeignKey(mc => mc.MealPlanId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mc => mc.Category)
                  .WithMany(c => c.MealPlanCategories)
                  .HasForeignKey(mc => mc.CategoryId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
