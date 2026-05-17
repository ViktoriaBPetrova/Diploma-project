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
    public class IngredientMealConfig : IEntityTypeConfiguration<IngredientMeal>
    {
        public void Configure(EntityTypeBuilder<IngredientMeal> builder)
        {

            builder.HasKey(im => new { im.MealId, im.IngredientId });

            builder.HasOne(im => im.Meal)
                  .WithMany(m => m.IngredientMeals)
                  .HasForeignKey(im => im.MealId)
                  .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(im => im.Ingredient)
                  .WithMany(i => i.IngredientMeals)
                  .HasForeignKey(im => im.IngredientId)
                  .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
