using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.ArticleValidation
{
    public class UpdateArticleValidator : AbstractValidator<Article>
    {
        public UpdateArticleValidator()
        {
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Lütfen makale için bir kategori girin.");
            RuleFor(x => x.Title).NotEmpty().WithMessage("Lütfen makale için bir başlık girin.");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Lütfen makale için bir açıklama girin.");
            RuleFor(x => x.Description).MinimumLength(184).WithMessage("Lütfen makale için girilen açıklama en az \"184\" karakter içermelidir.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Makale başlığı için en az 5 karakter girişi yapın");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Makale başlığı için en fazla 100 karakter girişi yapın");
        }
    }
}
