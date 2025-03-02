using Portfolio.Repositories.Models.Users;

namespace Portfolio.Services.Services.Users
{
    public class UserService(IUserRepository userRepository) : IUserService 
    {
    }
}
