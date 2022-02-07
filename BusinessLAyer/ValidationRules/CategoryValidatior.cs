using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class CategoryValidatior:AbstractValidator<Category>
    {
        public CategoryValidatior()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Zorunlu alandır.");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Acıklama zorunlu");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(20).WithMessage("Lütfen maxsimun 20 karakter yazınız.");
        }
    }
}
