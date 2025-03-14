using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.SocialMediaUrls.Update
{
    public class UpdateSocialMediaRequestValidator :AbstractValidator<UpdateSocialMediaRequest>
    {
        public UpdateSocialMediaRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");

            RuleFor(x => x.Platform)
                .NotEmpty().WithMessage("Platform name cannot be empty.")
                .MaximumLength(50).WithMessage("Platform name cannot exceed 50 characters.");

            RuleFor(x => x.URL)
                .NotEmpty().WithMessage("URL cannot be empty.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Invalid URL format.");
        }
    }
}
