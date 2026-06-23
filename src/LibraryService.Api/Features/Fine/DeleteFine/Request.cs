using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.DeleteFine;
/// <summary>
/// Represents the DeleteFineCommand request.
/// </summary>
public sealed record DeleteFineCommand(Guid Id) : IRequest<Result<Unit>>;