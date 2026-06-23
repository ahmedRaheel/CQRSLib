using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.GetMemberById;
public sealed class GetMemberByIdQueryHandler : IRequestHandler<GetMemberByIdQuery, Result<MemberDto?>>
{
    private readonly IMemberQueryRepository _query;
    public GetMemberByIdQueryHandler(IMemberQueryRepository query) => _query = query;
    public async ValueTask<Result<MemberDto?>> Handle(GetMemberByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<MemberDto?>("Member with ID {request.Id} was not found.");
        return Result<MemberDto?>.Success(value, "Member retrieved successfully.");
    }
}