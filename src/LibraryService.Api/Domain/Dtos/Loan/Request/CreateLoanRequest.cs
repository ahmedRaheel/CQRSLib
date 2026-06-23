namespace LibraryService.Api.Domain.Dtos.Loan.Request;
public sealed record CreateLoanRequest(Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate);