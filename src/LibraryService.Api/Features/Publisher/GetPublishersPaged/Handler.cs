using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Publisher.GetPublishersPaged;
public sealed class GetPublishersPagedQueryHandler : IRequestHandler<GetPublishersPagedQuery, Result<PagedResult<PublisherDto>>>
{
    private readonly IPublisherQueryRepository _query;
    public GetPublishersPagedQueryHandler(IPublisherQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<PublisherDto>>> Handle(GetPublishersPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<PublisherDto>>.Success(value, "Publisher retrieved successfully.");
    }
}