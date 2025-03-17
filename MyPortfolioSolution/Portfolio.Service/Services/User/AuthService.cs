using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Portfolio.Repositories.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio.Services.Services.User
{
    public class AuthService(IUserRepository userRepository, IConfiguration configuration) : IAuthService
    {
        public async Task<string?> AuthenticateAsync(string username, string password)
        {
            var user = await userRepository.GetByUsernameAsync(username);
            if (user == null || !PasswordHasher.VerifyPassword(password, user.PasswordHash))
                return null; // Kullanıcı yok veya şifre yanlış

            return GenerateJwtToken(user);
        }

        private string GenerateJwtToken(UserModel user)
        {
            var key = Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!);
            var claims = new[]
            {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim("UserId", user.Id.ToString())
        };

            var token = new JwtSecurityToken(
                configuration["Jwt:Issuer"],
                configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task RegisterAsync(string username, string email, string password)
        {
            var hashedPassword = PasswordHasher.HashPassword(password);
            var newUser = new UserModel { Username = username, Email = email, PasswordHash = hashedPassword };
            await userRepository.AddAsync(newUser);
        }
    }
}
