using Portfolio.Repositories.Models.RepositoriesForAboutMe.AboutMe;

namespace Portfolio.Repositories.Models.RepositoriesForAboutMe.SocialMediaUrls
{
    public class SocialMediaModel
    {
        public int Id { get; set; }
        public string Platform { get; set; } = string.Empty; // Örn: LinkedIn, GitHub, HackerRank
        public string URL { get; set; } = string.Empty;

        // AboutMe ile ilişki
        public int AboutMeId { get; set; }
        public AboutMeModel? AboutMe { get; set; }
    }
}