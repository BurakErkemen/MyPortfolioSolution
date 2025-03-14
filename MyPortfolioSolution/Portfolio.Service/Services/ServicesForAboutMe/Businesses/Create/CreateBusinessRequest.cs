namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses.Create;
public record CreateBusinessRequest(
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime? EndDate,
    int AboutMeId);