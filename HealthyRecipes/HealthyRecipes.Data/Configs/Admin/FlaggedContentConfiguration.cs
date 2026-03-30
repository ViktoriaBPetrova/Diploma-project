using HealthyRecipes.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configurations.Admin
{
    public class FlaggedContentConfiguration : IEntityTypeConfiguration<FlaggedContent>
    {
        public void Configure(EntityTypeBuilder<FlaggedContent> builder)
        {
            builder.HasKey(f => f.Id);

            // Relationships
            builder.HasOne(f => f.ContentAuthor)
                .WithMany(u => u.FlaggedContentAsAuthor)
                .HasForeignKey(f => f.ContentAuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.ReportedBy)
                .WithMany(u => u.FlaggedContentReported)
                .HasForeignKey(f => f.ReportedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.ReviewedByAdmin)
                .WithMany(u => u.FlaggedContentReviewed)
                .HasForeignKey(f => f.ReviewedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
