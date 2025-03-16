namespace Portfolio.Repositories.Models.Blog
{
    public class BlogModel
    {
        public int BlogId { get; set; }  // Blog'un benzersiz kimliği
        public string Title { get; set; }  // Başlık
        public string Slug { get; set; }  // URL dostu başlık
        public string Content { get; set; }  // Blog içeriği
        public string Summary { get; set; }  // Kısa özet
        public string CoverImageUrl { get; set; }  // Kapak görseli

        public DateTime CreatedAt { get; set; } = DateTime.Now;  // Oluşturulma tarihi
        public DateTime? UpdatedAt { get; set; }  // Güncellenme tarihi (opsiyonel)
        public bool IsPublished { get; set; }  // Yayınlanma durumu

        public int ViewCount { get; set; } = 0;  // Görüntülenme sayısı
        public List<string> Tags { get; set; } = new();  // Etiketler (örn: C#, .NET, Backend)

        public string MetaTitle { get; set; }  // SEO başlığı
        public string MetaDescription { get; set; }  // SEO açıklaması
    }
}