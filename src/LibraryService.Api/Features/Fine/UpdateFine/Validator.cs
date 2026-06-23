using FluentValidation;

namespace LibraryService.Api.Features.Fine.UpdateFine;
public sealed class UpdateFineCommandValidator : AbstractValidator<UpdateFineCommand>
{
    public UpdateFineCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.LoanId).NotNull();
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
    }
}