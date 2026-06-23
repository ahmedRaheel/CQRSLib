using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.CreateMember;
public sealed class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Result<MemberDto>>
{
    private readonly IMemberCommandRepository _commands;
    private readonly IMemberQueryRepository _query;
    public CreateMemberCommandHandler(IMemberCommandRepository commands, IMemberQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<MemberDto>> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
    {
        var entity = MemberEntity.Create(request.Name, request.Email);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new MemberDto(entity.Id, entity.Name, entity.Email);
        return Result<MemberDto>.Success(response, "Member successfully created.");
    }
}