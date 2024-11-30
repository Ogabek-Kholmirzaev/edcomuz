using FluentValidation;

namespace Expense.Application.Outlays.UpdateOutlay;

public class UpdateOutlayCommandValidator : AbstractValidator<UpdateOutlayCommand>
{
    public UpdateOutlayCommandValidator()
    {
        RuleFor(x => x.OutlayDto).NotEmpty();
        RuleFor(x => x.OutlayDto.Id).NotEmpty();
        RuleFor(x => x.OutlayDto.CategoryId).NotEmpty();
        RuleFor(x => x.OutlayDto.Date).NotEmpty();
        RuleFor(x => x.OutlayDto.Price).NotEmpty().GreaterThan(0);
    }
}