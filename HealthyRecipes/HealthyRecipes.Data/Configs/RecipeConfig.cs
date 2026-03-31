using HealthyRecipes.Data.Entities;
using HealthyRecipes.Data.Entities.MappingEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HealthyRecipes.Data.Configs
{
    public class RecipeConfig : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {

            builder.Property(r => r.ImageUrls)
           .HasConversion(
               v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
               v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null) ?? new List<string>())
           .HasColumnType("nvarchar(max)")
           .Metadata.SetValueComparer(
               new ValueComparer<List<string>>(
                   (c1, c2) => c1.SequenceEqual(c2), // How to compare two lists
                   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // How to generate hash
                   c => c.ToList())); // How to snapshot (clone) the list

        }
    }
}
