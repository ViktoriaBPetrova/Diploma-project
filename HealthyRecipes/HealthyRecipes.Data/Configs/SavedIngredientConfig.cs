using HealthyRecipes.Data.Entities.MappingEntities;
using HealthyRecipes.Data.Entities.MappingEntities.User_Info;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Configs
{
    public class SavedIngredientConfig : IEntityTypeConfiguration<SavedIngredient>
    {
        public void Configure(EntityTypeBuilder<SavedIngredient> builder)
        {
            
                builder.HasKey(si => new { si.IngredientId, si.UserId });

                builder.HasOne(si => si.Ingredient)
                      .WithMany(i => i.SavedIngredients)
                      .HasForeignKey(si => si.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(si => si.User)
                      .WithMany(u => u.SavedIngredients)
                      .HasForeignKey(si => si.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
