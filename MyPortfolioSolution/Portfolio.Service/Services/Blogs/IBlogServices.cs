using Portfolio.Services.Services.Blogs.Create;
using Portfolio.Services.Services.Blogs.Update;

namespace Portfolio.Services.Services.Blogs
{
    public interface IBlogServices
    {
        Task<ServiceResult<CreateBlogResponse>> CreateAsync(CreateBlogRequest model);
        Task<ServiceResult> UpdateAsync(UpdateBlogRequest model);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<BlogResponse>> GetByIdAsync(int id);
        Task<ServiceResult<List<BlogResponse>>> GetAllBlogsAsync();


        Task<ServiceResult<BlogResponse>> GetByIdWithImagesAsync(int blogId);
        Task<ServiceResult<List<BlogResponse>>> GetBlogsByUserIdAsync(int userId);
    }
}