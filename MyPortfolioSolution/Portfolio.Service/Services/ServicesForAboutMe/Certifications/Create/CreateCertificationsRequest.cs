namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications.Create;
public record CreateCertificationsRequest(
    string Title,
    string IssuingOrganization,
    DateTime IssuedDate,
    DateTime? ExpirationDate,
    int AboutMeId);