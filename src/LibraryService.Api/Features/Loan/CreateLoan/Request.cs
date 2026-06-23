using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Loan.CreateLoan;
/// <summary>
/// Represents the CreateLoanCommand request.
/// </summary>
public sealed record CreateLoanCommand(Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate) : IRequest<Result<LoanDto>>;