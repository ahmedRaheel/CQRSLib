namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Loan DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record LoanDetailDto(Guid Id, Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate, FineDto? Fine, BookDto? Book, MemberDto? Member);