namespace Portfolio.Repositories.Models.Skills
{
    public class SkillModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Level { get; set; } = "Beginner"; // Beginner, Intermediate, Advanced
    }
}
