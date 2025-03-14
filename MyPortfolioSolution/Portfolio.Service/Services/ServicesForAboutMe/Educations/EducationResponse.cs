namespace Portfolio.Services.Services.ServicesForAboutMe.Educations;
public record EducationResponse(
    string SchoolName,
    string Degree,
    string FieldOfStudy,
    DateTime StartDate,
    DateTime? EndDate,
    int AboutMeId
    );