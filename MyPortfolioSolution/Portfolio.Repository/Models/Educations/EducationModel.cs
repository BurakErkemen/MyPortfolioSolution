namespace Portfolio.Repositories.Models.Educations
{
    public class EducationModel
    {
        public int Id { get; set; }
        public string Institution { get; set; } = string.Empty;
        public string Degree { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; } // Devam eden eğitimler için nullable
    }
}
