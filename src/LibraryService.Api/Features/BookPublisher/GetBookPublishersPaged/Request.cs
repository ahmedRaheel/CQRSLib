using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.GetBookPublishersPaged;
/// <summary>
/// Represents the GetBookPublishersPagedQuery request.
/// </summary>
public sealed record GetBookPublishersPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<BookPublisherDto>>>;