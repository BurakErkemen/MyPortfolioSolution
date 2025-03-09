using FluentValidation;

namespace Portfolio.Services.Services.ContactForms.Create
{
    public class CreateContactFormRequestValidation : AbstractValidator<CreateContactFormRequest>
    {
        public CreateContactFormRequestValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(100).WithMessage("Name must be at most 100 characters.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MaximumLength(150).WithMessage("Email must be at most 150 characters.");

            RuleFor(x => x.Phone)
                .MaximumLength(11).WithMessage("Phone number must be at most 11 characters.");

            RuleFor(x => x.Message)
                .NotEmpty().WithMessage("Message is required.")
                .MaximumLength(1000).WithMessage("Message must be at most 1000 characters.");

            RuleFor(x => x.Company)
                .MaximumLength(100).WithMessage("Company name must be at most 100 characters.");
        }
    }
}