namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications.Update;
public record UpdateCertificationRequest(
    int Id,
    string Title,
    string IssuingOrganization,
    DateTime IssuedDate,
    DateTime? ExpirationDate);