using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.BlogImage
{
    public class BlogImageRepository(PortfolioDbContext context) : GenericRepository<BlogImageModel>(context), IBlogImageRepository
    {
        public async Task<IEnumerable<BlogImageModel>> GetImagesByBlogIdAsync(int blogId)
        {
            return await context.BlogImages
                .Where(bi => bi.BlogId == blogId)
                .OrderBy(bi => bi.OrderIndex) // Sıralama için
                .ToListAsync();
        }
    }
}