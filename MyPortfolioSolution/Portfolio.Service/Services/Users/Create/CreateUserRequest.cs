namespace Portfolio.Services.Services.Users.Create;
public record CreateUserRequest(
    string Name, 
    string Email, 
    string Password);
