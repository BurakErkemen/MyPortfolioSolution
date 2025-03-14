using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Educations
{
    public class EducationConfiguration : IEntityTypeConfiguration<EducationModel>
    {
        public void Configure(EntityTypeBuilder<EducationModel> builder)
        {
            // Tablo adı belirleme
            builder.ToTable("Educations");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Zorunlu alanlar
            builder.Property(e => e.SchoolName)
                .HasMaxLength(150)
                .IsRequired(); // Okul adı zorunlu

            builder.Property(e => e.Degree)
                .HasMaxLength(100)
                .IsRequired(); // Derece zorunlu

            builder.Property(e => e.FieldOfStudy)
                .HasMaxLength(100)
                .IsRequired(); // Alan zorunlu

            builder.Property(e => e.StartDate)
                .IsRequired(); // Başlangıç tarihi zorunlu

            builder.Property(e => e.EndDate)
                .IsRequired(false); // Mezuniyet tarihi opsiyonel

            // AboutMe ile ilişki (One-to-Many)
            builder.HasOne(e => e.AboutMe)
                .WithMany(a => a.Education)
                .HasForeignKey(e => e.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade); // AboutMe silinirse eğitimler de silinsin
        }
    }
}
