namespace Portfolio.Services.Services.Blogs;
public record BlogResponse(
    string Name,
    string Description,
    DateTime CreatedAt,
    int UserId,
    List<string> ImagesUrl);