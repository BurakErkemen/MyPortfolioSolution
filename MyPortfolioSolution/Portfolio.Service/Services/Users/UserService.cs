using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.UnitOfWorkRepositories;

namespace Portfolio.Services.Services.Users
{
    public class UserService(IUserRepository userRepository,IUnitOfWorkRepository unitOfWork) : IUserService 
    {

    }
}
