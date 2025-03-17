using Portfolio.Services.Services.UserJWT.Create;

namespace Portfolio.Services.Services.UserJWT
{
    public interface IUserService
    {
        Task<ServiceResult<CreateUserResponse?>> RegisterAsync(CreateUserRequest request);
        Task<ServiceResult<TokenResponse?>> LoginAsync(LoginUserRequest request);
        Task<ServiceResult<TokenResponse?>> RefreshTokenAsync(string refreshToken);
        Task<ServiceResult<List<UserResponse>>> GetAllAsync();
        Task<ServiceResult<UserResponse?>> GetByIdAsync(int id);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
