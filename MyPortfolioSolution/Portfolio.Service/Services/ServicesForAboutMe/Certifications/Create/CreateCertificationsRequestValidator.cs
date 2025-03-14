using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications.Create
{
    public class CreateCertificationsRequestValidator:AbstractValidator<CreateCertificationsRequest>
    {
        public CreateCertificationsRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.IssuingOrganization)
                .NotEmpty().WithMessage("Issuing Organization cannot be empty.")
                .MaximumLength(100).WithMessage("Issuing Organization cannot exceed 100 characters.");

            RuleFor(x => x.IssuedDate)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Issued Date cannot be in the future.");

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(x => x.IssuedDate)
                .When(x => x.ExpirationDate.HasValue)
                .WithMessage("Expiration Date must be later than Issued Date.");
        }
    }
}
