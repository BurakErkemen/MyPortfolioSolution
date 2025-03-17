namespace Portfolio.Services.Services.UserJWT.Update;
public record UpdateUserRequest(
    int Id,
    string Name,
    string Email,
    string Password
    );