using FluentValidation;

namespace Expense.Application.Outlays.CreateOutlay;

public class CreateOutlayCommandValidator : AbstractValidator<CreateOutlayCommand>
{
    public CreateOutlayCommandValidator()
    {
        RuleFor(x => x.OutlayDto).NotEmpty();
        RuleFor(x => x.OutlayDto.CategoryId).NotEmpty();
        RuleFor(x => x.OutlayDto.Date).NotEmpty();
        RuleFor(x => x.OutlayDto.Price).NotEmpty().GreaterThan(0);
    }
}