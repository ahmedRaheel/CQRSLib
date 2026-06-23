using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.GetBooksPaged;
/// <summary>
/// Represents the GetBooksPagedQuery request.
/// </summary>
public sealed record GetBooksPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<BookDto>>>;