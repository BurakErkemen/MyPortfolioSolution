using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.Skills
{
    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced

        // AboutMe ile ilişki
        public int AboutMeId { get; set; }
        public AboutMeModel? AboutMe { get; set; }
    }
}