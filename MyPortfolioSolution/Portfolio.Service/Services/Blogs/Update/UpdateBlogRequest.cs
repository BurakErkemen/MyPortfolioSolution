namespace Portfolio.Services.Services.Blogs.Update;
public record UpdateBlogRequest(
    int Id,
    string Name,
    string Description,
    List<string> ImagesUrl);