using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Writer Name Can't be Empty");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Writer Surname Can't be Empty");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Writer About Can't be Empty");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Writer Title Can't be Empty");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Writer Password Can't be Empty");
            RuleFor(x => x.WriterName).MinimumLength(3).WithMessage("Writer Can be 3 Characters at least");
            RuleFor(x => x.WriterSurName).MaximumLength(50).WithMessage("Please Don't Enter More Than 50 Characters");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("Please Don't Enter More Than 50 Characters");
            RuleFor(x => x.WriterPassword).MaximumLength(200).WithMessage("Please Don't Enter More Than 200 Characters");

        }
    }
}
