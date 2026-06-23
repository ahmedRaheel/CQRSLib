namespace LibraryService.Api.Domain.Dtos.Fine.Request;
public sealed record CreateFineRequest(Guid LoanId, decimal Amount);