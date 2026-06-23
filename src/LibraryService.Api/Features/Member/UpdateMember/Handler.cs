using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Member.UpdateMember;
public sealed class UpdateMemberCommandHandler : IRequestHandler<UpdateMemberCommand, Result<Unit>>
{
    private readonly IMemberCommandRepository _commands;
    private readonly IMemberQueryRepository _query;
    public UpdateMemberCommandHandler(IMemberCommandRepository commands, IMemberQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Member with ID {request.Id} was not found.");
        entity.Update(request.Name, request.Email);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Member successfully updated.");
    }
}