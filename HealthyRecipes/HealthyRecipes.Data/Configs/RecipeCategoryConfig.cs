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
    public class RecipeCategoryConfig : IEntityTypeConfiguration<RecipeCategory>
    {
        public void Configure(EntityTypeBuilder<RecipeCategory> builder)
        {
            
                builder.HasKey(rc => new { rc.RecipeId, rc.CategoryId });

                builder.HasOne(rc => rc.Recipe)
                      .WithMany(r => r.RecipeCategories)
                      .HasForeignKey(rc => rc.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(rc => rc.Category)
                      .WithMany(c => c.RecipeCategories)
                      .HasForeignKey(rc => rc.CategoryId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
