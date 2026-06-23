using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.UpdateLoan;
/// <summary>
/// Represents the UpdateLoanCommand request.
/// </summary>
public sealed record UpdateLoanCommand(Guid Id, Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate) : IRequest<Result<Unit>>;