using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            //empty
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Receiver can't be empty");
            //RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Sender mail can't be empty");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Subject can't be empty");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Message content can't be empty");
            //mail
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Please enter right mail address");
            //RuleFor(x => x.SenderMail).EmailAddress().WithMessage("Please enter right mail address");
            //maximum
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("Please don't enter more than 100 characters");
            //RuleFor(x => x.SenderMail).MaximumLength(50).WithMessage("Please don't enter more than 50 characters");
            RuleFor(x => x.ReceiverMail).MaximumLength(50).WithMessage("Please don't enter more than 50 characters");
            //minimum
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Please don't enter less than 3 characters");

        }
    }
}
