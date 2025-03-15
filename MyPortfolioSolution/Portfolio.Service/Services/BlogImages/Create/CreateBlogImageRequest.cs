namespace Portfolio.Services.Services.BlogImages.Create;
public record CreateBlogImageRequest(
    int BlogId,
    string ImageUrl,
    int OrderIndex);
