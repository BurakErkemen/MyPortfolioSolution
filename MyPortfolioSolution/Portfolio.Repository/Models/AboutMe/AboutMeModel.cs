using Portfolio.Repositories.Models.Businesses;
using Portfolio.Repositories.Models.Certifications;
using Portfolio.Repositories.Models.Educations;
using Portfolio.Repositories.Models.Skills;
using Portfolio.Repositories.Models.SocialMediaUrls;
using Portfolio.Repositories.Models.Users;

namespace Portfolio.Repositories.Models.AboutMe
{
    public class AboutMeModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public List<EducationModel> Education { get; set; } = [];
        public List<BusinessModel> Business { get; set; } = [];
        public List<SkillModel> Skills { get; set; } = [];
        public List<CertificationModel> Certifications { get; set; } = [];
        public List<SocialMediaModel> SocialMediaLinks { get; set; } = [];
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Kullanıcıyla ilişkilendirme
        public int UserId { get; set; }  // Foreign Key
        public UserModel User { get; set; } = default!;  // Navigation Property
    }
}