namespace Portfolio.Services.Services.Blogs.Create;
public record CreateBlogRequest(
    string Name,
    string Description,
    DateTime CreatedAt,
    string UserId,  // Değiştirildi (int yerine string)
    List<string> BlogImages);
