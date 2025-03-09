namespace Portfolio.Services.Services.ContactForms;
public record ContactFormResponse(
    string Name,
    string Email,
    string? Phone,
    string Message, 
    string? Company,
    DateTime CreatedAt);