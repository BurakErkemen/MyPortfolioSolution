
using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Blog
{
    public class BlogRepository(PortfolioDbContext context) :GenericRepository<BlogModel>(context), IBlogRepository
    {
        public Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
