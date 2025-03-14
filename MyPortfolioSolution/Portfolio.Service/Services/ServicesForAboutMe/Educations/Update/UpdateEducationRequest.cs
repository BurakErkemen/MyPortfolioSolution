namespace Portfolio.Services.Services.ServicesForAboutMe.Educations.Update;
public record UpdateEducationRequest(
    int Id,
    string SchoolName,
    string Degree,
    string FieldOfStudy,
    DateTime StartDate,
    DateTime? EndDate);