using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.Blogs
{
    public class BlogServices(IBlogPostRepository blogRepository, IUnitOfWorkRepository unitOfWork) : IBlogServices
    {
       
    }
}