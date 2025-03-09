namespace Portfolio.Services.Services.ContactForms.Create;
public record CreateContactFormRequest(
    string Name,
    string Email,
    string Phone,
    string Message,
    string Company);
