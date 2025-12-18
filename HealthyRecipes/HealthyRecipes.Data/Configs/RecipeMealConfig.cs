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
    public class RecipeMealConfig: IEntityTypeConfiguration<RecipeMeal>
    {
        public void Configure(EntityTypeBuilder<RecipeMeal> builder)
        {   
                builder.HasKey(rm => new {
                    rm.RecipeId,
                    rm.MealId
                });

                builder.HasOne(rm => rm.Recipe)
                      .WithMany(r => r.RecipeMeals)
                      .HasForeignKey(rm => rm.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(rm => rm.Meal)
                       .WithMany(m => m.RecipeMeals)
                       .HasForeignKey(rm => rm.MealId)
                       .OnDelete(DeleteBehavior.Restrict);            
        }       
    }
}
