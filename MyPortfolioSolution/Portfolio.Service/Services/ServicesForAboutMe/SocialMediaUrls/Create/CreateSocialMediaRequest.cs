namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Create;
public record CreateSocialMediaRequest(
    string Platform,
    string URL,
    int AboutMeId);