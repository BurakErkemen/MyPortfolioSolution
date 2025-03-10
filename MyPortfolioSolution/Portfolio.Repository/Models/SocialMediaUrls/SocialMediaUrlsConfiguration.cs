using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.SocialMediaUrls
{
    public class SocialMediaUrlsConfiguration : IEntityTypeConfiguration<SocialMediaModel>
    {
        public void Configure(EntityTypeBuilder<SocialMediaModel> builder)
        {
            // Tablo adı
            builder.ToTable("SocialMediaLinks");

            // Primary Key
            builder.HasKey(sm => sm.Id);

            // Zorunlu alanlar
            builder.Property(sm => sm.Platform)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(sm => sm.URL)
                .IsRequired()
                .HasMaxLength(500);

            // AboutMe ilişkisi (Many-to-One)
            builder.HasOne(sm => sm.AboutMe)
                .WithMany(a => a.SocialMediaLinks)
                .HasForeignKey(sm => sm.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
