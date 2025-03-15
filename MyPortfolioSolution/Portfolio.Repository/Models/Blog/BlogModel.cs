using Portfolio.Repositories.Models.Users;
using Portfolio.Repositories.Models.BlogImage;

namespace Portfolio.Repositories.Models.Blog
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Varsayılan değer UTC saatine göre atanır

        // Kullanıcıyla ilişkilendirme
        public int UserId { get; set; }  // Foreign Key
        public UserModel User { get; set; } = default!;  // Navigation Property

        // Blog görselleri ile ilişkilendirme
        public List<BlogImageModel> BlogImages { get; set; } = new();
    }
}