using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Portfolio.Repositories.Models.BlogImage;

namespace Portfolio.Repositories.Configurations
{
    public class BlogImageConfiguration : IEntityTypeConfiguration<BlogImageModel>
    {
        public void Configure(EntityTypeBuilder<BlogImageModel> builder)
        {
            // Primary Key
            builder.HasKey(bi => bi.Id);

            // Foreign Key - Blog ile ilişki
            builder.HasOne(bi => bi.Blog)
                   .WithMany()
                   .HasForeignKey(bi => bi.BlogId)
                   .OnDelete(DeleteBehavior.Cascade); // Blog silindiğinde resimler de silinsin

            // ImageUrl Zorunlu
            builder.Property(bi => bi.ImageUrl)
                   .IsRequired()
                   .HasMaxLength(500);

            // OrderIndex Varsayılan 0
            builder.Property(bi => bi.OrderIndex)
                   .IsRequired()
                   .HasDefaultValue(0);
        }
    }
}