namespace Portfolio.Repositories.Models.User
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Role { get; set; } = "Admin"; // Şu an sadece "Admin" olacak
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? RefreshToken { get; set; }  // Eksik olabilir
        public DateTime? RefreshTokenExpiryTime { get; set; } // Eksik olabilir
    }
}