namespace Portfolio.Services.Services.Blogs.Update;
public record UpdateBlogRequest(
    string Id,  // Değiştirildi (int yerine string)
    string Name,
    string Description,
    List<string> BlogImages);
