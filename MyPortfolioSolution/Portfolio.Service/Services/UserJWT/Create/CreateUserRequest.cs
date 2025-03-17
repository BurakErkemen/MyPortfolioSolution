namespace Portfolio.Services.Services.UserJWT.Create;
public record CreateUserRequest(
    string FullName,
    string Email,
    string Password);