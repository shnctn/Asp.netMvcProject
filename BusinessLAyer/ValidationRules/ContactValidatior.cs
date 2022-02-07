using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidatior:AbstractValidator<Contact>
    {
        public ContactValidatior()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresini boş gecemezsiniz.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage(" Başlığı boş gecemezsiniz.");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı adi boş gecemezsiniz.");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Message boş gecemezsiniz.");
            

        }
    }
}
