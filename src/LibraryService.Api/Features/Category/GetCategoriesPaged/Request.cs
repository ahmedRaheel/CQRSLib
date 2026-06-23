using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.GetCategoriesPaged;
/// <summary>
/// Represents the GetCategoriesPagedQuery request.
/// </summary>
public sealed record GetCategoriesPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<CategoryDto>>>;