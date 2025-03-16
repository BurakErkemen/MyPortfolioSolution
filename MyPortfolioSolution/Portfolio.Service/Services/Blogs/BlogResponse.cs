namespace Portfolio.Services.Services.Blogs;
public record BlogResponse(
    string Name,
    string Description,
    DateTime CreatedAt,
    string UserId,
    List<string> BlogImages); // Buradaki isim BlogModel ile uyumlu olmalı
