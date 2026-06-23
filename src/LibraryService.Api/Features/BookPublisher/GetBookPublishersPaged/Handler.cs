using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.BookPublisher.GetBookPublishersPaged;
public sealed class GetBookPublishersPagedQueryHandler : IRequestHandler<GetBookPublishersPagedQuery, Result<PagedResult<BookPublisherDto>>>
{
    private readonly IBookPublisherQueryRepository _query;
    public GetBookPublishersPagedQueryHandler(IBookPublisherQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<BookPublisherDto>>> Handle(GetBookPublishersPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<BookPublisherDto>>.Success(value, "BookPublisher retrieved successfully.");
    }
}