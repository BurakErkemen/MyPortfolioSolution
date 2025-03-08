using Portfolio.Repositories.Models.Users;

namespace Portfolio.Services.Services.Users;
public record UserResponse(
    string Name, 
    string PhotoURL, 
    string Email, 
    UserRoles Role,
    AccountStatus AccountStatus,
    DateTime CreatedAt);

