namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Update;
public record UpdateAboutMeRequest(
    int Id,
    string FullName,
    string ContactNo,
    string Email
    );