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
    public class SavedRecipeConfig : IEntityTypeConfiguration<SavedRecipe>
    {
        public void Configure(EntityTypeBuilder<SavedRecipe> builder)
        {
            
                builder.HasKey(sr => new { sr.RecipeId, sr.UserId });

                builder.HasOne(sr => sr.Recipe)
                      .WithMany(r => r.SavedRecipes)
                      .HasForeignKey(sr => sr.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(sr => sr.User)
                      .WithMany(u => u.SavedRecipes)
                      .HasForeignKey(sr => sr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
