using Portfolio.Services.Services.BlogImages.Create;
using Portfolio.Services.Services.BlogImages.Update;

namespace Portfolio.Services.Services.BlogImages
{
    public interface IBlogImageServices
    {
        Task<ServiceResult<CreateBlogImageResponse>> CreateAsync(CreateBlogImageRequest request);
        Task<ServiceResult> UpdateAsync(UpdateBlogImagesRequest request);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ServiceResult<BlogImageResponse>> GetByIdAsync(int id);
        Task<ServiceResult<List<BlogImageResponse>>> GetAllBlogImagesAsync();

        Task<ServiceResult<List<BlogImageResponse>>> GetImagesByBlogIdAsync(int blogId);
    }
}