namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe;
public record AboutMeResponse(
    string FullName,
    string ContactNo,
    string Email,
    DateTime CreatedAt,
    int UserId);
