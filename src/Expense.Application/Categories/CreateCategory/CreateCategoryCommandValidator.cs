using FluentValidation;

namespace Expense.Application.Categories.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(x => x.Category).NotEmpty();
        RuleFor(x => x.Category.Name).NotEmpty();
    }
}