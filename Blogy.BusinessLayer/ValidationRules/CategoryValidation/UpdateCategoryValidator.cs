using Blogy.EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogy.BusinessLayer.ValidationRules.CategoryValidation
{
    public class UpdateCategoryValidator : AbstractValidator<Category>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Kategori adını boş geçemezsiniz.");
            RuleFor(x => x.Name).MinimumLength(3).WithMessage("Kategori adını en az 3 karakter olarak giriniz");
            RuleFor(x => x.Name).MaximumLength(30).WithMessage("Kategori adını en fazla 30 karakter olarak giriniz").Equal("a").WithMessage("Katagori adı a harfi içermelidir");
        }
    }
}
