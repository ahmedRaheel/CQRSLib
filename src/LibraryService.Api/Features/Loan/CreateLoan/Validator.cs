using FluentValidation;

namespace LibraryService.Api.Features.Loan.CreateLoan;
public sealed class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
{
    public CreateLoanCommandValidator()
    {
        RuleFor(x => x.BookId).NotNull();
        RuleFor(x => x.MemberId).NotNull();
        RuleFor(x => x.LoanDate).NotNull();
        RuleFor(x => x.DueDate).NotNull();
    }
}