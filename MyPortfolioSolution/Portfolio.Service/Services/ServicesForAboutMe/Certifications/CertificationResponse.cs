namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications;
public record CertificationResponse(
    string Title,
    string IssuingOrganization,
    DateTime IssuedDate,
    DateTime? ExpirationDate,
    int AboutMeId);