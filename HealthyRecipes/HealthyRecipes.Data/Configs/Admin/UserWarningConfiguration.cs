using HealthyRecipes.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configurations.Admin
{
    public class UserWarningConfiguration : IEntityTypeConfiguration<UserWarning>
    {
        public void Configure(EntityTypeBuilder<UserWarning> builder)
        {

            builder.HasKey(w => w.Id);

            // Relationships
            builder.HasOne(w => w.User)
                .WithMany(u => u.WarningsReceived)
                .HasForeignKey(w => w.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.IssuedByAdmin)
                .WithMany(u => u.WarningsIssued)
                .HasForeignKey(w => w.IssuedByAdminId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(w => w.RelatedFlaggedContent)
                .WithMany(fc => fc.IssuedWarnings)
                .HasForeignKey(w => w.RelatedFlaggedContentId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
