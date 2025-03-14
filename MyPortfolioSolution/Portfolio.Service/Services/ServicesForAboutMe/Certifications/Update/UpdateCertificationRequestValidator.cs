using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.Certifications.Update
{
    public class UpdateCertificationRequestValidator : AbstractValidator<UpdateCertificationRequest>
    {
        public UpdateCertificationRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty.")
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");

            RuleFor(x => x.IssuingOrganization)
                .NotEmpty().WithMessage("Issuing organization cannot be empty.")
                .MaximumLength(100).WithMessage("Issuing organization cannot exceed 100 characters.");

            RuleFor(x => x.IssuedDate)
                .NotEmpty().WithMessage("Issued date is required.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Issued date cannot be in the future.");

            RuleFor(x => x.ExpirationDate)
                .GreaterThan(x => x.IssuedDate)
                .When(x => x.ExpirationDate.HasValue)
                .WithMessage("Expiration date must be after the issued date.");
        }
    }
}
