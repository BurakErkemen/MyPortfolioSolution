using Portfolio.Repositories.Models.Blog.BlogPost;

namespace Portfolio.Repositories.Models.Blog.BlogTag
{
    public class BlogTagModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Etiket adı (Örn: "C#", "ASP.NET", "Backend")

        // Many-to-Many ilişki
        public List<BlogPostModel>? BlogPosts { get; set; } = new();
    }
}