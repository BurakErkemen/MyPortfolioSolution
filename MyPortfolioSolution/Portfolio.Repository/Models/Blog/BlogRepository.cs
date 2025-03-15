using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Blog
{
    public class BlogRepository(PortfolioDbContext context) : GenericRepository<BlogModel>(context), IBlogRepository
    {
        public async Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(int userId)
        {
            return await Context.Blogs
                .Where(b => b.UserId == userId)
                .ToListAsync();
        }

        public async Task<BlogModel?> GetByIdWithImagesAsync(int blogId)
        {
            return await Context.Blogs
                .Include(b => b.BlogImages) // Resimleri de dahil et
                .FirstOrDefaultAsync(b => b.Id == blogId);
        }
    }
}
