using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.Book.GetBooksPaged;
public sealed class GetBooksPagedQueryHandler : IRequestHandler<GetBooksPagedQuery, Result<PagedResult<BookDto>>>
{
    private readonly IBookQueryRepository _query;
    public GetBooksPagedQueryHandler(IBookQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<BookDto>>> Handle(GetBooksPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<BookDto>>.Success(value, "Book retrieved successfully.");
    }
}