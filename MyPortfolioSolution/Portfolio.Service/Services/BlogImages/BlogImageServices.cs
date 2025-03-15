using Microsoft.EntityFrameworkCore;
using Portfolio.Repositories.Models.BlogImage;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.BlogImages.Create;
using Portfolio.Services.Services.BlogImages.Update;
using System.Net;

namespace Portfolio.Services.Services.BlogImages
{
    public class BlogImageServices(IBlogImageRepository blogImageRepository, IUnitOfWorkRepository unitOfWork) : IBlogImageServices
    {
        public async Task<ServiceResult<List<BlogImageResponse>>> GetAllBlogImagesAsync()
        {
            var blogImages = await blogImageRepository.GetAll().ToListAsync();

            var response = blogImages.Select(img => new BlogImageResponse(img.BlogId, img.ImageUrl, img.OrderIndex)).ToList();

            return ServiceResult<List<BlogImageResponse>>.Success(response);
        }

        public async Task<ServiceResult<BlogImageResponse>> GetByIdAsync(int id)
        {
            var blogImage = await blogImageRepository.GetByIdAsync(id);
            if (blogImage is null)
                return ServiceResult<BlogImageResponse>.Fail("Blog Images Not Found.",HttpStatusCode.NotFound);

            var response = new BlogImageResponse
                (
                // blogImage.Id, 
                blogImage.BlogId, 
                blogImage.ImageUrl, 
                blogImage.OrderIndex
                );
            
            return ServiceResult<BlogImageResponse>.Success(response);
        }

        public async Task<ServiceResult<CreateBlogImageResponse>> CreateAsync(CreateBlogImageRequest request)
        {
            var blogImage = new BlogImageModel
            {
                BlogId = request.BlogId,
                ImageUrl = request.ImageUrl,
                OrderIndex = request.OrderIndex
            };

            await blogImageRepository.AddAsync(blogImage);
            await unitOfWork.SaveChangesAsync();

            var response = new CreateBlogImageResponse(blogImage.Id);

            return ServiceResult<CreateBlogImageResponse>.Success(response);
        }

        public async Task<ServiceResult> UpdateAsync(UpdateBlogImagesRequest request)
        {
            var blogImage = await blogImageRepository.GetByIdAsync(request.Id);
            if (blogImage is null)
                return ServiceResult.Fail("Blog Images Not Found.",HttpStatusCode.NotFound);

            blogImage.ImageUrl = request.ImageUrl;
            blogImage.OrderIndex = request.OrderIndex;

            blogImageRepository.UpdateAsync(blogImage);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success();
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var anyBlog = await blogImageRepository.GetByIdAsync(id);
            if (anyBlog is null)
                return ServiceResult.Fail("Blog Images Not Found!", HttpStatusCode.NotFound);

            blogImageRepository.DeleteAsync(anyBlog);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<BlogImageResponse>>> GetImagesByBlogIdAsync(int blogId)
        {
            var getBlog = await blogImageRepository.GetImagesByBlogIdAsync(blogId);
            if (getBlog is null)
                return ServiceResult<List<BlogImageResponse>>.Fail("Blog Not Found!", HttpStatusCode.NotFound);

            var getBlogAsResponse = getBlog.Select(b => new BlogImageResponse(
                b.BlogId,
                b.ImageUrl,
                b.OrderIndex)).ToList();

            return ServiceResult<List<BlogImageResponse>>.Success(getBlogAsResponse);
        }
    }
}