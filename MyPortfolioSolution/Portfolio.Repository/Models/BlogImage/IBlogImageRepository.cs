using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.BlogImage
{
    public interface IBlogImageRepository : IGenericRepository<BlogImageModel>
    {
        Task<IEnumerable<BlogImageModel>> GetImagesByBlogIdAsync(int blogId); // Blog'a ait resimleri getir
    }
}