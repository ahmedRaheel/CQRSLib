using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.DeleteMember;
public sealed class DeleteMemberCommandHandler : IRequestHandler<DeleteMemberCommand, Result<Unit>>
{
    private readonly IMemberCommandRepository _commands;
    private readonly IMemberQueryRepository _query;
    public DeleteMemberCommandHandler(IMemberCommandRepository commands, IMemberQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteMemberCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Member with ID {request.Id} was not found.");
        await _commands.DeleteWithChildrenAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Member successfully deleted.");
    }
}