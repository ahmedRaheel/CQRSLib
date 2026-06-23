using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Fine.UpdateFine;
public sealed class UpdateFineCommandHandler : IRequestHandler<UpdateFineCommand, Result<Unit>>
{
    private readonly IFineCommandRepository _commands;
    private readonly IFineQueryRepository _query;
    public UpdateFineCommandHandler(IFineCommandRepository commands, IFineQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateFineCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Fine with ID {request.Id} was not found.");
        entity.Update(request.LoanId, request.Amount);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Fine successfully updated.");
    }
}