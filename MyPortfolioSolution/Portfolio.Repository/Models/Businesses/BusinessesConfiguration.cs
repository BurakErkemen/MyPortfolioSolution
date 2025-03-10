using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Businesses
{
    public class BusinessesConfiguration : IEntityTypeConfiguration<BusinessModel>
    {
        public void Configure(EntityTypeBuilder<BusinessModel> builder)
        {
            // Tablo adı belirleme
            builder.ToTable("Businesses");

            // Primary Key
            builder.HasKey(b => b.Id);

            // Zorunlu alanlar
            builder.Property(b => b.CompanyName)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.Position)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(b => b.StartDate)
                .IsRequired();

            builder.Property(b => b.EndDate)
                .IsRequired(false);

            // AboutMe ilişkisi (Many-to-One)
            builder.HasOne(b => b.AboutMe)
                .WithMany(a => a.Businesses)
                .HasForeignKey(b => b.AboutMeId)
                .OnDelete(DeleteBehavior.Cascade); // AboutMe silinirse, bağlı Business kayıtları da silinir
        }
    }
}
