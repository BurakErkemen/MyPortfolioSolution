using Portfolio.Repositories.GenericRepositories;

namespace Portfolio.Repositories.Models.Blog
{
    public interface IBlogRepository: IGenericRepository<BlogModel>
    {
        Task<BlogModel?> GetByIdWithImagesAsync(int blogId); // Blog ve resimleri getir
        Task<IEnumerable<BlogModel>> GetBlogsByUserIdAsync(int userId); // Kullanıcıya ait blogları getir
    }
}
