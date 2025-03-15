using FluentValidation;

namespace Portfolio.Services.Services.Blogs.Create
{
    public class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
    {
        public CreateBlogRequestValidator() {

            RuleFor(x => x.Name)
               .NotEmpty().WithMessage("Blog ismi boş olamaz.")
               .MaximumLength(100).WithMessage("Blog ismi en fazla 100 karakter olmalıdır.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Blog açıklaması boş olamaz.")
                .MaximumLength(500).WithMessage("Blog açıklaması en fazla 500 karakter olmalıdır.");

            RuleFor(x => x.CreatedAt)
                .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Oluşturulma tarihi gelecekte olamaz.");

            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage("Geçerli bir kullanıcı ID belirtilmelidir.");
        }
    }
}
