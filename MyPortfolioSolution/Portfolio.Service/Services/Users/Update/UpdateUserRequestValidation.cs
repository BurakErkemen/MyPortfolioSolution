using FluentValidation;

namespace Portfolio.Services.Services.Users.Update
{
    public class UpdateUserRequestValidation : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidation()
        {
            RuleFor(x => x.Id)
    .GreaterThan(0).WithMessage("Kullanıcı ID sıfırdan büyük olmalıdır.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("İsim alanı boş olamaz.")
                .MaximumLength(50).WithMessage("İsim en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("E-posta boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir e-posta adresi giriniz.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Şifre boş olamaz.")
                .MinimumLength(6).WithMessage("Şifre en az 6 karakter olmalıdır.")
                .Matches(@"[A-Z]").WithMessage("Şifre en az bir büyük harf içermelidir.")
                .Matches(@"\d").WithMessage("Şifre en az bir rakam içermelidir.")
                .Matches(@"[\W_]").WithMessage("Şifre en az bir özel karakter içermelidir.");

            RuleFor(x => x.PhotoUrl)
                .Must(url => string.IsNullOrEmpty(url) || Uri.TryCreate(url, UriKind.Absolute, out _))
                .WithMessage("Geçerli bir URL giriniz.");

            RuleFor(x => x.AccountStatus)
                .IsInEnum().WithMessage("Geçerli bir hesap durumu giriniz.");

            RuleFor(x => x.Role)
                .IsInEnum().WithMessage("Geçerli bir kullanıcı rolü giriniz.");
        }
    }
}