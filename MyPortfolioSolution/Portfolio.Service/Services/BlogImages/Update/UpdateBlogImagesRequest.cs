namespace Portfolio.Services.Services.BlogImages.Update;

public record UpdateBlogImagesRequest(
    int Id,
    int BlogId,
    string ImageUrl,
    int OrderIndex);