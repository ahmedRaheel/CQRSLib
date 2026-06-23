using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.UpdateFine;
/// <summary>
/// Represents the UpdateFineCommand request.
/// </summary>
public sealed record UpdateFineCommand(Guid Id, Guid LoanId, decimal Amount) : IRequest<Result<Unit>>;