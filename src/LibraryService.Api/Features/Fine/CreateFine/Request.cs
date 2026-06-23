using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.CreateFine;
/// <summary>
/// Represents the CreateFineCommand request.
/// </summary>
public sealed record CreateFineCommand(Guid LoanId, decimal Amount) : IRequest<Result<FineDto>>;