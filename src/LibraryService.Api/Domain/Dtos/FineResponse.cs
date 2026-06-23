namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Fine data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record FineDto(Guid Id, Guid LoanId, decimal Amount);