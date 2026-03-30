using HealthyRecipes.Data.Entities.Admin;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HealthyRecipes.Data.Configurations.Admin
{
    public class BannedWordConfiguration : IEntityTypeConfiguration<BannedWord>
    {
        public void Configure(EntityTypeBuilder<BannedWord> builder)
        {

            builder.HasKey(b => b.Id);

            // Relationships
            builder.HasOne(b => b.CreatedBy)
                .WithMany(u => u.CreatedBannedWords)
                .HasForeignKey(b => b.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
