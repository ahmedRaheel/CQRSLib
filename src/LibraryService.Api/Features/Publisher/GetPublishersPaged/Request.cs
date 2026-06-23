using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.GetPublishersPaged;
/// <summary>
/// Represents the GetPublishersPagedQuery request.
/// </summary>
public sealed record GetPublishersPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<PublisherDto>>>;