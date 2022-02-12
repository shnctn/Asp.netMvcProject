using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
     public class ContentValidatior:AbstractValidator<Content>
    {
        public ContentValidatior()
        {
            RuleFor(x => x.Writer).NotEmpty().WithMessage("Zorunlu alandır.");
            RuleFor(x => x.ContentValue).NotEmpty().WithMessage("Acıklama zorunlu");
            RuleFor(x => x.ContentValue).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(20).WithMessage("Lütfen maxsimun 20 karakter yazınız.");

        }
    }
}
