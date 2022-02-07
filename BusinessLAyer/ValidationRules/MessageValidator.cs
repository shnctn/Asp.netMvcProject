using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
   public  class MessageValidator:AbstractValidator<Message>
   {
       public MessageValidator()
       {
           RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Boş geçemezsiniz");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli Mail Giriniz");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Boş geçemezsiniz");
         
           RuleFor(x => x.Subject).NotEmpty().WithMessage("Boş geçemezsiniz");

       }
    }
}
