using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;
using FastCqrs;

namespace LibraryService.Api.Features.BookAuthor.GetBookAuthorsPaged;
public sealed class GetBookAuthorsPagedQueryHandler : IRequestHandler<GetBookAuthorsPagedQuery, Result<PagedResult<BookAuthorDto>>>
{
    private readonly IBookAuthorQueryRepository _query;
    public GetBookAuthorsPagedQueryHandler(IBookAuthorQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<BookAuthorDto>>> Handle(GetBookAuthorsPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<BookAuthorDto>>.Success(value, "BookAuthor retrieved successfully.");
    }
}