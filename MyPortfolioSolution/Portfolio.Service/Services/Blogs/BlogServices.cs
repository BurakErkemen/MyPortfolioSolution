using Portfolio.Repositories.Models.Blog;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.Blogs.Create;
using Portfolio.Services.Services.Blogs.Update;

namespace Portfolio.Services.Services.Blogs
{
    public class BlogServices(IBlogRepository blogRepository, IUnitOfWorkRepository unitOfWork) : IBlogServices
    {
        public Task<ServiceResult<BlogResponse>> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<List<BlogResponse>>> GetAllBlogsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<CreateBlogResponse>> CreateAsync(CreateBlogRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(UpdateBlogRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }



        public Task<ServiceResult<List<BlogResponse>>> GetBlogsByUserIdAsync(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult<BlogResponse>> GetByIdWithImagesAsync(int blogId)
        {
            throw new NotImplementedException();
        }
    }
}
