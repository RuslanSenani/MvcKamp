using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Category Name Can't be Empty");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Category Description Can't be Empty");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Category Can be 3 Characters at least");
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Please Don't Enter More Than 20 Characters");
        }

    }
}
