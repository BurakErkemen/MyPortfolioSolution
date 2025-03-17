using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Blog.BlogTag
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTagModel>
    {
        public void Configure(EntityTypeBuilder<BlogTagModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
