using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookCategory.GetBookCategoryById;
public sealed class GetBookCategoryByIdQueryHandler : IRequestHandler<GetBookCategoryByIdQuery, Result<BookCategoryDto?>>
{
    private readonly IBookCategoryQueryRepository _query;
    public GetBookCategoryByIdQueryHandler(IBookCategoryQueryRepository query) => _query = query;
    public async ValueTask<Result<BookCategoryDto?>> Handle(GetBookCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<BookCategoryDto?>("BookCategory with ID {request.Id} was not found.");
        return Result<BookCategoryDto?>.Success(value, "BookCategory retrieved successfully.");
    }
}