using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.GetBookCategoriesPaged;
/// <summary>
/// Represents the GetBookCategoriesPagedQuery request.
/// </summary>
public sealed record GetBookCategoriesPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<BookCategoryDto>>>;