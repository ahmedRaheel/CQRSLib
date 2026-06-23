namespace LibraryService.Api.Domain.Dtos.Loan.Request;
public sealed record UpdateLoanRequest(Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate);