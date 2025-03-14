using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.AboutMe.Create
{
    public class CreateAboutMeRequestValidation : AbstractValidator<CreateAboutMeRequest>
    {
        public CreateAboutMeRequestValidation()
        {
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage("Full name is required.")
                .MaximumLength(100).WithMessage("Full name must be at most 100 characters.");

            RuleFor(x => x.ContactNo)
                .NotEmpty().WithMessage("Contact number is required.")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid contact number format.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("UserId must be greater than 0.");

            RuleFor(x => x.Education)
                .NotNull().WithMessage("Education list cannot be null.");

            RuleFor(x => x.Business)
                .NotNull().WithMessage("Business list cannot be null.");

        }
    }
}