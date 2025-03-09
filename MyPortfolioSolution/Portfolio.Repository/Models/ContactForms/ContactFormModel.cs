namespace Portfolio.Repositories.Models.ContactForms
{
    public class ContactFormModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Message { get; set; } = default!;
        public string? Company { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}