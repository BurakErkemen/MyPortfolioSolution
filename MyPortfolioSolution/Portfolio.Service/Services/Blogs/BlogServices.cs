using Portfolio.Repositories.Models.Blog;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.Blogs
{
    public class BlogServices(IBlogRepository blogRepository, IUnitOfWorkRepository unitOfWork) : IBlogServices
    {
       
    }
}