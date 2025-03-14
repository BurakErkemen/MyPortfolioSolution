using FluentValidation;

namespace Portfolio.Services.Services.ServicesForAboutMe.Businesses.Create
{
    public class CreateBusinessRequestValidator :AbstractValidator<CreateBusinessRequest>
    {
        public CreateBusinessRequestValidator()
        {
            RuleFor(x => x.CompanyName)
                .NotEmpty().WithMessage("Şirket adı boş olamaz.")
                .MaximumLength(100).WithMessage("Şirket adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.Position)
                .NotEmpty().WithMessage("Pozisyon adı boş olamaz.")
                .MaximumLength(100).WithMessage("Pozisyon adı 100 karakterden uzun olamaz.");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Başlangıç tarihi zorunludur.")
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Başlangıç tarihi bugünden ileri bir tarih olamaz.");

            RuleFor(x => x.EndDate)
                .GreaterThan(x => x.StartDate)
                .When(x => x.EndDate.HasValue)
                .WithMessage("Bitiş tarihi başlangıç tarihinden önce olamaz.");

            RuleFor(x => x.AboutMeId)
                .GreaterThan(0).WithMessage("Geçerli bir Hakkımda bulunamadı.");
        }
    }
}