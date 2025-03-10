using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Skills
{
    public class SkillsConfiguration : IEntityTypeConfiguration<SkillModel>
    {
        public void Configure(EntityTypeBuilder<SkillModel> builder)
        {
            // Tablo adı
            builder.ToTable("Skills");

            // Primary Key
            builder.HasKey(s => s.Id);

            // Zorunlu alanlar
            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Level)
                .IsRequired()
                .HasMaxLength(50);

            // AboutMe ilişkisi (Many-to-One)
            builder.HasOne(s => s.AboutMe)
                .WithMany(a => a.Skills)
                .HasForeignKey(s => s.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade); // AboutMe silinirse, bağlı Skills kayıtları da silinir
        }
    }
}
