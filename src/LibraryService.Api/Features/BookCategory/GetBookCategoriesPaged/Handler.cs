using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.GetBookCategoriesPaged;
public sealed class GetBookCategoriesPagedQueryHandler : IRequestHandler<GetBookCategoriesPagedQuery, Result<PagedResult<BookCategoryDto>>>
{
    private readonly IBookCategoryQueryRepository _query;
    public GetBookCategoriesPagedQueryHandler(IBookCategoryQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<BookCategoryDto>>> Handle(GetBookCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<BookCategoryDto>>.Success(value, "BookCategory retrieved successfully.");
    }
}