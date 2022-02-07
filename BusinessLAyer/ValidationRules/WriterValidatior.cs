using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public class WriterValidatior:AbstractValidator<Writer>
    {
        public WriterValidatior()
        { 
           
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Zorunlu alandır.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("Acıklama zorunlu");
            RuleFor(x => x.writerAbout).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(500).WithMessage("Lütfen maxsimun 500 karakter yazınız.");
            RuleFor(x => x.WriterMail).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(20).WithMessage("Lütfen maxsimun 20 karakter yazınız.");
            RuleFor(x => x.writerPassword).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(20).WithMessage("Lütfen maxsimun 20 karakter yazınız.");
            RuleFor(x => x.WriterTitle).MinimumLength(3).WithMessage("Lütfen en az 3 karakter yazın ").MaximumLength(20).WithMessage("Lütfen maxsimun 20 karakter yazınız.");
        }
    }
}
