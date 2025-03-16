using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Blog
{
    public class BlogConfiguration : IEntityTypeConfiguration<BlogModel>
    {
        public void Configure(EntityTypeBuilder<BlogModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
