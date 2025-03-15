using FluentValidation;

namespace Portfolio.Services.Services.Blogs.Update
{
    public class UpdateBlogRequestValidator : AbstractValidator<UpdateBlogRequest>
    {
        public UpdateBlogRequestValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0).WithMessage("Blog ID 0 veya negatif olamaz.");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Blog ismi boş olamaz.")
                .MaximumLength(100).WithMessage("Blog ismi en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MaximumLength(500).WithMessage("Açıklama en fazla 500 karakter olabilir.");

            RuleFor(x => x.ImagesUrl)
                .NotNull().WithMessage("Resim listesi boş olamaz.")
                .Must(images => images.Count <= 10).WithMessage("En fazla 10 resim eklenebilir.");

            RuleForEach(x => x.ImagesUrl)
                .NotEmpty().WithMessage("Resim URL'i boş olamaz.")
                .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _)).WithMessage("Geçerli bir URL giriniz.");
        }
    }
}
