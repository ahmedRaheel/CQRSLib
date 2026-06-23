using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Category.GetCategoryById;
public sealed class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Result<CategoryDto?>>
{
    private readonly ICategoryQueryRepository _query;
    public GetCategoryByIdQueryHandler(ICategoryQueryRepository query) => _query = query;
    public async ValueTask<Result<CategoryDto?>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<CategoryDto?>("Category with ID {request.Id} was not found.");
        return Result<CategoryDto?>.Success(value, "Category retrieved successfully.");
    }
}