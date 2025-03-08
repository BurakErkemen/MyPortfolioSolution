namespace Portfolio.Repositories.Models.Users
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string PhotoURL { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public UserRoles Role { get; set; }
        public AccountStatus IsActivate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public enum UserRoles
    {
        User = 0,
        Moderator = 1,
        Admin = 2
    }
    public enum AccountStatus
    {
        Active = 0,
        Deactivated = 1
    }
}