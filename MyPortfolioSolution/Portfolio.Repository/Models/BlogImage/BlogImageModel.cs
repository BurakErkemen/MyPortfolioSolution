using Portfolio.Repositories.Models.Blog;

namespace Portfolio.Repositories.Models.BlogImage
{
    public class BlogImageModel
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string ImageUrl { get; set; } = default!;
        public int OrderIndex { get; set; } // Resim sırası

        public BlogModel Blog { get; set; } = default!;
    }
}