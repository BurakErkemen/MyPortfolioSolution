using Portfolio.Repositories.Models.Blog.BlogPost;

namespace Portfolio.Repositories.Models.Blog.BlogCategory
{
    public class BlogCategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty; // Kategori adı (Örn: "Yazılım", "Kişisel", "Teknoloji")
        public string Slug { get; set; } = string.Empty; // URL için kategori adı (/blog/yazilim gibi)

        // İlişkilendirme
        public List<BlogPostModel>? BlogPosts { get; set; } = [];
    }

}
