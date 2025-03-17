using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Blog.BlogPost
{
    public class BlogPostConfiguration : IEntityTypeConfiguration<BlogPostModel>
    {
        public void Configure(EntityTypeBuilder<BlogPostModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
