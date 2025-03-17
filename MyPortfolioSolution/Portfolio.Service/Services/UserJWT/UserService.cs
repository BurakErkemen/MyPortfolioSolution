using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Repositories.Models.User;
using Portfolio.Repositories.UnitOfWorkRepositories;
using Portfolio.Services.Services.UserJWT.Create;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Services.Services.UserJWT
{
    public class UserService(IUserRepository userRepository, IUnitOfWorkRepository unitOfWork,IConfiguration configuration) : IUserService
    {
        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var anyUser = await userRepository.GetByIdAsync(id);
            if (anyUser is null)
                return ServiceResult.Fail("User Not Found!",HttpStatusCode.BadRequest);

            userRepository.DeleteAsync(anyUser);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult.Success(HttpStatusCode.NoContent);
        }

        public async Task<ServiceResult<List<UserResponse>>> GetAllAsync()
        {
            var anyUser = await userRepository.GetAll().ToListAsync();
            if (anyUser is null)
                return ServiceResult<List<UserResponse>>.Fail("Users Not Found!", HttpStatusCode.NotFound);

            var userAsResponse = anyUser.Select(u => new UserResponse(
                u.Username,
                u.Email)).ToList();

            return ServiceResult<List<UserResponse>>.Success(userAsResponse);
        }

        public async Task<ServiceResult<UserResponse?>> GetByIdAsync(int id)
        {
            var anyUser = await userRepository.GetByIdAsync(id);

            if (anyUser is null)
                return ServiceResult<UserResponse?>.Fail("User Not Found!", HttpStatusCode.NotFound);

            var userAsResponse = new UserResponse(
                anyUser.Username,
                anyUser.Email);

            return ServiceResult<UserResponse?>.Success(userAsResponse);
        }



        public async Task<ServiceResult<TokenResponse?>> LoginAsync(LoginUserRequest request)
        {
            var user = await  userRepository.GetByEmailAsync(request.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return ServiceResult<TokenResponse?>.Fail("Invalid credentials.");
            }

            var token = GenerateJwtToken(user);
            var refreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            var userAsResponse = new TokenResponse(token, refreshToken, DateTime.UtcNow.AddMinutes(30));

            return ServiceResult<TokenResponse?>.Success(userAsResponse);
        }

        public async Task<ServiceResult<CreateUserResponse?>> RegisterAsync(CreateUserRequest request)
        {
            var existingUser = await userRepository.GetByEmailAsync(request.Email);
            if (existingUser != null)
            {
                return ServiceResult<CreateUserResponse?>.Fail("Email already in use.");
            }

            var user = new UserModel
            {
                Username = request.FullName,
                Email = request.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password)
            };

            await userRepository.AddAsync(user);
            await unitOfWork.SaveChangesAsync();

            return ServiceResult<CreateUserResponse?>.Success(new CreateUserResponse(user.Id),HttpStatusCode.Created);
        }


        public async Task<ServiceResult<TokenResponse?>> RefreshTokenAsync(string refreshToken)
        {
            var user = await userRepository.GetByRefreshTokenAsync(refreshToken);
            if (user == null || user.RefreshTokenExpiryTime < DateTime.UtcNow)
            {
                return ServiceResult<TokenResponse?>.Fail("Invalid or expired refresh token.");
            }

            var newToken = GenerateJwtToken(user);
            var newRefreshToken = Guid.NewGuid().ToString();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            userRepository.UpdateAsync(user);
            await unitOfWork.SaveChangesAsync();

            var userAsResponse = new TokenResponse(newToken, refreshToken, DateTime.UtcNow.AddMinutes(30));

            return ServiceResult<TokenResponse?>.Success(userAsResponse);
        }

        private string GenerateJwtToken(UserModel user)
        {
            var jwtKey = configuration["Jwt:Key"] ?? throw new ArgumentNullException("Jwt:Key is missing in configuration.");
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}