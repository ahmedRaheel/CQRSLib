using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.GetFinesPaged;
/// <summary>
/// Represents the GetFinesPagedQuery request.
/// </summary>
public sealed record GetFinesPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<FineDto>>>;