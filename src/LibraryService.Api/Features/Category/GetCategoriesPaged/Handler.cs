using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.GetCategoriesPaged;
public sealed class GetCategoriesPagedQueryHandler : IRequestHandler<GetCategoriesPagedQuery, Result<PagedResult<CategoryDto>>>
{
    private readonly ICategoryQueryRepository _query;
    public GetCategoriesPagedQueryHandler(ICategoryQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<CategoryDto>>> Handle(GetCategoriesPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<CategoryDto>>.Success(value, "Category retrieved successfully.");
    }
}