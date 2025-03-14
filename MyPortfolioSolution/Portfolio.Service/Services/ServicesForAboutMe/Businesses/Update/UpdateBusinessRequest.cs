namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses.Update;
public record UpdateBusinessRequest(
    int Id,
    string CompanyName,
    string Position,
    DateTime StartDate,
    DateTime? EndDate);