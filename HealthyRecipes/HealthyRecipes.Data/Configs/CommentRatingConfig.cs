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

            // Composite key for top-level comments (recipe + user)
            // For replies, we'll use the Id property
            builder.HasKey(cr => cr.Id);

                builder.HasOne(cr => cr.Recipe)
                      .WithMany(r => r.CommentRatings)
                      .HasForeignKey(cr => cr.RecipeId)
                      .OnDelete(DeleteBehavior.Restrict);

                builder.HasOne(cr => cr.User)
                      .WithMany(u => u.CommentRatings)
                      .HasForeignKey(cr => cr.UserId)
                      .OnDelete(DeleteBehavior.Restrict);

            // Self-referencing relationship for replies
            builder.HasOne(cr => cr.ParentComment)      // This comment HAS ONE parent
            .WithMany(cr => cr.Replies)             // That parent has MANY replies
            .HasForeignKey(cr => cr.ParentCommentId)
            .OnDelete(DeleteBehavior.Restrict);
            //A comment has one parent comment, and that parent has many replies
        }
    }
}
