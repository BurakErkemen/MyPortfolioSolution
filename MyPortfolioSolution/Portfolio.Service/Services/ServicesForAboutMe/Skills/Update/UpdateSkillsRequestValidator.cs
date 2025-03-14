using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.Skills.Update
{
    public class UpdateSkillsRequestValidator :AbstractValidator<UpdateSkillsRequest>
    {
        public UpdateSkillsRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Skill name cannot be empty.")
                .MaximumLength(100).WithMessage("Skill name cannot exceed 100 characters.");

            RuleFor(x => x.Level)
                .NotEmpty().WithMessage("Skill level cannot be empty.")
                .Must(level => new[] { "Beginner", "Intermediate", "Advanced", "Expert" }.Contains(level))
                .WithMessage("Skill level must be one of the following: Beginner, Intermediate, Advanced, Expert.");
        }
    }
}
