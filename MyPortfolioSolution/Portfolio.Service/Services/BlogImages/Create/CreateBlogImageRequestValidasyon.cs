using FluentValidation;

namespace Portfolio.Services.Services.BlogImages.Create
{
    public class CreateBlogImageRequestValidator : AbstractValidator<CreateBlogImageRequest>
    {
        public CreateBlogImageRequestValidator()
        {
            RuleFor(x => x.BlogId)
                .GreaterThan(0).WithMessage("BlogId geçerli bir değer olmalıdır.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim URL'i boş olamaz.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Geçerli bir URL giriniz.");

            RuleFor(x => x.OrderIndex)
                .GreaterThanOrEqualTo(0).WithMessage("Resim sırası negatif olamaz.");
        }
    }
}
