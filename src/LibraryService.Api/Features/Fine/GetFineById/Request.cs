using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.GetFineById;
/// <summary>
/// Represents the GetFineByIdQuery request.
/// </summary>
public sealed record GetFineByIdQuery(Guid Id) : IRequest<Result<FineDto?>>;