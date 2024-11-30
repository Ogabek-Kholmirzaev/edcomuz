using FluentValidation;

namespace Expense.Application.Categories.UpdateCategory;

public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).NotEmpty();
        RuleFor(x => x.Category.Id).NotEmpty();
        RuleFor(x => x.Category.Name).NotEmpty();
    }
}