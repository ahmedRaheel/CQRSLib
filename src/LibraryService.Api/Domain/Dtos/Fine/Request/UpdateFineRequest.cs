namespace LibraryService.Api.Domain.Dtos.Fine.Request;
public sealed record UpdateFineRequest(Guid LoanId, decimal Amount);