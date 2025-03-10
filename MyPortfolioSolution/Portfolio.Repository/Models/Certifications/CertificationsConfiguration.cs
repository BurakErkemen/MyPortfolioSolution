using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Certifications
{
    public class CertificationConfiguration : IEntityTypeConfiguration<CertificationModel>
    {
        public void Configure(EntityTypeBuilder<CertificationModel> builder)
        {           
            // Tablo adı
            builder.ToTable("Certifications");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Zorunlu alanlar
            builder.Property(c => c.Title)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.IssuingOrganization)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(c => c.IssuedDate)
                .IsRequired();

            builder.Property(c => c.ExpirationDate)
                .IsRequired(false);

            // AboutMe ilişkisi (Many-to-One)
            builder.HasOne(c => c.AboutMe)
                .WithMany(a => a.Certifications)
                .HasForeignKey(c => c.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade); // AboutMe silinirse, bağlı sertifikalar da silinir
        }
    }
}
