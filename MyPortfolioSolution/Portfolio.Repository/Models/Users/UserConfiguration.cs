using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Users
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            // Tablo adı
            builder.ToTable("Users");

            // Birincil anahtar
            builder.HasKey(u => u.Id);

            // Id için otomatik artırma
            builder.Property(u => u.Id)
                   .ValueGeneratedOnAdd();

            // İsim için zorunlu ve maksimum uzunluk kısıtlaması
            builder.Property(u => u.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Email için zorunlu ve benzersizlik
            builder.Property(u => u.Email)
                   .IsRequired()
                   .HasMaxLength(150);

            builder.HasIndex(u => u.Email)
                   .IsUnique();

            // Şifre için zorunlu
            builder.Property(u => u.Password)
                   .IsRequired();

            // Fotoğraf URL'si için varsayılan değer
            builder.Property(u => u.PhotoURL)
                   .HasDefaultValue(string.Empty);

            // Rol için varsayılan değer
            builder.Property(u => u.Role)
                   .HasDefaultValue(UserRoles.User);

            // Actıvate 
            builder.Property(u => u.IsActivate)
                .HasDefaultValue(AccountStatus.Active);
        }
    }
}
