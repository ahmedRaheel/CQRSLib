using FluentValidation;

namespace LibraryService.Api.Features.Fine.CreateFine;
public sealed class CreateFineCommandValidator : AbstractValidator<CreateFineCommand>
{
    public CreateFineCommandValidator()
    {
        RuleFor(x => x.LoanId).NotNull();
        RuleFor(x => x.Amount).GreaterThanOrEqualTo(0);
    }
}