using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("User Name can't be empty");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject can't be empty");
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("User Mail can't be empty");

            RuleFor(x => x.Subject).MinimumLength(5).WithMessage("Subject can be 5 characters at least");
            RuleFor(x => x.UserName).MinimumLength(5).WithMessage("User Name can be 5 characters at least");

            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Please don't enter more than 50 characters");
        }
    }
}
