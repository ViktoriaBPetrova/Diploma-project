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
    public class CommentRatingConfig : IEntityTypeConfiguration<CommentRating>
    {
        public void Configure(EntityTypeBuilder<CommentRating> builder)
        {
            
                builder.HasKey(cr => new { cr.RecipeId, cr.UserId });

                builder.HasOne(cr => cr.Recipe)
                      .WithMany(r => r.CommentRatings)
                      .HasForeignKey(cr => cr.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(cr => cr.User)
                      .WithMany(u => u.CommentRatings)
                      .HasForeignKey(cr => cr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);


            
        }
    }
}
