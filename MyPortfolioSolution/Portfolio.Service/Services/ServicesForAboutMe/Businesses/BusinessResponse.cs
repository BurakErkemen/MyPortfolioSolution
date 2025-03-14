namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses;
public record BusinessResponse(
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime? EndDate,
    int AboutMeId);