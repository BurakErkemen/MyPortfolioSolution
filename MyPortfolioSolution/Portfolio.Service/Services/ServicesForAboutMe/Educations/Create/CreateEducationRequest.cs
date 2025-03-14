namespace Portfolio.Services.Services.ServicesForAboutMe.Educations.Create;
public record CreateEducationRequest(
    string SchoolName,
    string Degree,
    string FieldOfStudy,
    DateTime StardDate,
    DateTime? EndDate,
    int AboutMeId);