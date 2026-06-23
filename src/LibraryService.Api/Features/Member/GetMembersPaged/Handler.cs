using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.GetMembersPaged;
public sealed class GetMembersPagedQueryHandler : IRequestHandler<GetMembersPagedQuery, Result<PagedResult<MemberDto>>>
{
    private readonly IMemberQueryRepository _query;
    public GetMembersPagedQueryHandler(IMemberQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<MemberDto>>> Handle(GetMembersPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<MemberDto>>.Success(value, "Member retrieved successfully.");
    }
}