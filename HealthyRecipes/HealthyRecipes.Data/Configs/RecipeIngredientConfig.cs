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
    public class RecipeIngredientConfig : IEntityTypeConfiguration<RecipeIngredient>
    {
        public void Configure(EntityTypeBuilder<RecipeIngredient> builder)
        {
            
                builder.HasKey(ri => new { ri.RecipeId, ri.IngredientId });

                builder.HasOne(ri => ri.Recipe)
                      .WithMany(r => r.RecipeIngredients)
                      .HasForeignKey(ri => ri.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(ri => ri.Ingredient)
                      .WithMany(i => i.RecipeIngredients)
                      .HasForeignKey(ri => ri.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
