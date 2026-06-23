using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.GetBookAuthorsPaged;
/// <summary>
/// Represents the GetBookAuthorsPagedQuery request.
/// </summary>
public sealed record GetBookAuthorsPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<BookAuthorDto>>>;