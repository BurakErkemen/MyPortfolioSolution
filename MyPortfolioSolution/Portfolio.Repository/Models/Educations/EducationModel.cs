using Portfolio.Repositories.Models.AboutMe;

namespace Portfolio.Repositories.Models.Educations
{
    public class EducationModel
    {
        public int Id { get; set; }
        public string SchoolName { get; set; } = default!;
        public string Degree { get; set; } = default!;
        public string FieldOfStudy { get; set; } = default!;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        // AboutMe ile ilişki
        public int AboutMeId { get; set; }
        public AboutMeModel? AboutMe { get; set; } 
    }
}
