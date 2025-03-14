namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Update;
public record UpdateSocialMediaRequest(
    int Id,
    string Platform,
    string URL);