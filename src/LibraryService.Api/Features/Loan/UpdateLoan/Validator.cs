using FluentValidation;

namespace LibraryService.Api.Features.Loan.UpdateLoan;
public sealed class UpdateLoanCommandValidator : AbstractValidator<UpdateLoanCommand>
{
    public UpdateLoanCommandValidator()
    {
        RuleFor(x => x.Id).NotNull();
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.MemberId).NotNull();
        RuleFor(x => x.LoanDate).NotNull();
        RuleFor(x => x.DueDate).NotNull();
    }
}