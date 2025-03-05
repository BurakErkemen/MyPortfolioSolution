using Portfolio.Repositories.Models.Users;

namespace Portfolio.Services.Services.Users.Update;
public record UpdateUserRequest(
    int Id,
    string Name, 
    string Email,
    string Password, 
    string PhotoUrl, 
    AccountStatus AccountStatus,
    UserRoles Role);