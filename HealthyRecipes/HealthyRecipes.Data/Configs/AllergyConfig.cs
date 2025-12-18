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
    public class AllergyConfig : IEntityTypeConfiguration<Allergy>
    {
        public void Configure(EntityTypeBuilder<Allergy> builder)
        {
           
                builder.HasKey(a => new { a.IngredientId, a.UserId });

                builder.HasOne(a => a.Ingredient)
                      .WithMany(i => i.Allergies)
                      .HasForeignKey(a => a.IngredientId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(a => a.User)
                      .WithMany(u => u.Allergies)
                      .HasForeignKey(a => a.UserId)
                      .OnDelete(DeleteBehavior.Restrict);
            
        }
    }
}
