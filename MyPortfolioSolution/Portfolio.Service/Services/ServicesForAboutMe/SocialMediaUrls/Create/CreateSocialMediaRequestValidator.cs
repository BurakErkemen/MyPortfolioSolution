using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Create
{
    public class CreateSocialMediaRequestValidator : AbstractValidator<CreateSocialMediaRequest>
    {
        public CreateSocialMediaRequestValidator()
        {
            RuleFor(x => x.Platform)
                .NotEmpty().WithMessage("Platform name cannot be empty.")
                .MaximumLength(50).WithMessage("Platform name cannot exceed 50 characters.");

            RuleFor(x => x.URL)
                .NotEmpty().WithMessage("URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Invalid URL format.");

            RuleFor(x => x.AboutMeId)
                .GreaterThan(0).WithMessage("AboutMeId must be greater than 0.");
        }
    }
}