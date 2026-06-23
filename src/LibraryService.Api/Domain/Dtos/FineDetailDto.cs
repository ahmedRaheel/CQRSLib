namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Fine DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record FineDetailDto(Guid Id, Guid LoanId, decimal Amount, LoanDto? Loan);