namespace Portfolio.Services.Services.ServicesForAboutMe.Skills.Create;
public record CreateSkillsRequest(
    string Name,
    string Level,
    int AboutMeId);