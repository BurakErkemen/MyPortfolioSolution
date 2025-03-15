namespace Portfolio.Services.Services.Blogs.Create;
public record CreateBlogRequest(
    string Name,
    string Description,
    DateTime CreatedAt,
    int UserId,
    List<string> ImageUrls);