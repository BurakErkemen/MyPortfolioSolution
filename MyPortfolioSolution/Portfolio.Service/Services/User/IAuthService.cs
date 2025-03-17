namespace Portfolio.Services.Services.User
{
    public interface IAuthService
    {
        Task<string?> AuthenticateAsync(string username, string password);
        Task RegisterAsync(string email, string password);
    }
}
