using Portfolio.Repositories.Models.AboutMe;

namespace Portfolio.Repositories.Models.Certifications
{
    public class CertificationModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string IssuingOrganization { get; set; } = string.Empty;
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpirationDate { get; set; } // Süresiz sertifikalar için nullable


        // AboutMe ile ilişki
        public int AboutMeId { get; set; }
        public AboutMeModel? AboutMe { get; set; }
    }
}
