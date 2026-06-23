using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.GetFinesPaged;
public sealed class GetFinesPagedQueryHandler : IRequestHandler<GetFinesPagedQuery, Result<PagedResult<FineDto>>>
{
    private readonly IFineQueryRepository _query;
    public GetFinesPagedQueryHandler(IFineQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<FineDto>>> Handle(GetFinesPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<FineDto>>.Success(value, "Fine retrieved successfully.");
    }
}