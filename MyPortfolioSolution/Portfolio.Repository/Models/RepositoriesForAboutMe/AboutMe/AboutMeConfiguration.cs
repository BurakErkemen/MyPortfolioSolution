using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe
{
    public class AboutMeConfiguration : IEntityTypeConfiguration<AboutMeModel>
    {
        public void Configure(EntityTypeBuilder<AboutMeModel> builder)
        {
            // Tablo adı
            builder.ToTable("AboutMe");

            // Primary Key
            builder.HasKey(a => a.Id);

            // Zorunlu alanlar
            builder.Property(a => a.FullName)
                .HasMaxLength(100)
                .IsRequired(false); // Opsiyonel

            builder.Property(a => a.ContactNo)
                .HasMaxLength(20)
                .IsRequired(false); // Opsiyonel

            builder.Property(a => a.Email)
                .HasMaxLength(150)
                .IsRequired(false); // Opsiyonel

            // Kullanıcı ile ilişki (UserId Foreign Key)
            builder.HasOne(a => a.User)
                .WithOne(u => u.AboutMe)
                .HasForeignKey<AboutMeModel>(a => a.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Kullanıcı silindiğinde AboutMe de silinir

            // Eğitim ile ilişki (One-to-Many)
            builder.HasMany(a => a.Education)
                .WithOne(e => e.AboutMe)
                .HasForeignKey(e => e.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);

            // İş deneyimi ile ilişki (One-to-Many)
            builder.HasMany(a => a.Business)
                .WithOne(b => b.AboutMe)
                .HasForeignKey(b => b.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Yetenekler ile ilişki (One-to-Many)
            builder.HasMany(a => a.Skills)
                .WithOne(s => s.AboutMe)
                .HasForeignKey(s => s.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Sertifikalar ile ilişki (One-to-Many)
            builder.HasMany(a => a.Certifications)
                .WithOne(c => c.AboutMe)
                .HasForeignKey(c => c.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Sosyal medya linkleri ile ilişki (One-to-Many)
            builder.HasMany(a => a.SocialMediaLinks)
                .WithOne(s => s.AboutMe)
                .HasForeignKey(s => s.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}