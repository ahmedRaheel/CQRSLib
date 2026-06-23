namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Loan data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record LoanDto(Guid Id, Guid BookId, Guid MemberId, DateTime LoanDate, DateTime DueDate);