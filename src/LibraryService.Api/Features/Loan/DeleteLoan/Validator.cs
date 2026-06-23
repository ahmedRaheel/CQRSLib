using FluentValidation;

namespace LibraryService.Api.Features.Loan.DeleteLoan;
public sealed class DeleteLoanCommandValidator : AbstractValidator<DeleteLoanCommand>
{
    public DeleteLoanCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
    }
}