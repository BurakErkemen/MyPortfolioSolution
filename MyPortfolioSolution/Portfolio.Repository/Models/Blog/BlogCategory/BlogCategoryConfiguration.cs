using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Portfolio.Repositories.Models.Blog.BlogCategory
{
    public class BlogCategoryConfiguration : IEntityTypeConfiguration<BlogCategoryModel>
    {
        public void Configure(EntityTypeBuilder<BlogCategoryModel> builder)
        {
            throw new NotImplementedException();
        }
    }
}
