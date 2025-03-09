using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.ContactForms
{
    public class ContactFormConfiguration : IEntityTypeConfiguration<ContactFormModel>
    {
        public void Configure(EntityTypeBuilder<ContactFormModel> builder)
        {
            builder.HasKey(x => x.Id); // Primary Key

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100); // İsim en fazla 100 karakter olabilir

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(150); // Email en fazla 150 karakter olabilir

            builder.Property(x => x.Message)
                .IsRequired()
                .HasMaxLength(1000); // Mesaj en fazla 1000 karakter olabilir

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()"); // Varsayılan olarak UTC tarih atansın

            builder.Property(x => x.Company)
                .HasDefaultValue("Unknown")
                .HasMaxLength(100);

            builder.ToTable("ContactForms"); // Tablo adını belirleme (isteğe bağlı)
        }
    }
}
