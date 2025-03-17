using Portfolio.Repositories.Models.Blog.BlogCategory;
using Portfolio.Repositories.Models.Blog.BlogTag;

namespace Portfolio.Repositories.Models.Blog.BlogPost
{
    public class BlogPostModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  // Blog başlığı
        public string Slug { get; set; } = string.Empty;   // URL dostu başlık (örneğin: /blog/my-first-post)
        public string Summary { get; set; } = string.Empty; // Kısa özet (Ana sayfada gösterilecek)
        public string Content { get; set; } = string.Empty; // Blog yazısının tamamı
        public string? CoverImageUrl { get; set; }  // Kapak görseli için URL

        // SEO Optimizasyonu
        public string? MetaTitle { get; set; }
        public string? MetaDescription { get; set; }

        // Tarihler
        public DateTime PublishedAt { get; set; } = DateTime.UtcNow; // Yayınlanma tarihi
        public DateTime? UpdatedAt { get; set; }  // Son güncelleme tarihi (opsiyonel)

        // Durum Bilgisi
        public bool IsPublished { get; set; } = false; // Yayınlandı mı?

        // Kategoriler ve Etiketler
        public int CategoryId { get; set; }  // Blog kategorisi
        public BlogCategoryModel Category { get; set; } = default!;
        public List<BlogTagModel>? Tags { get; set; } = [];

        // Admin Kullanıcı İlişkisi
        public int UserId { get; set; } // Blog sahibini belirlemek için
        public UserModel User { get; set; } = default!;
    }
}
