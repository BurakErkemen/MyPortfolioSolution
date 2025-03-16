using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Blog
{
    public interface IBlogRepository : IGenericRepository<BlogModel>
    {
        Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(string userId); // Kullanıcıya ait blogları getir
    }
}
