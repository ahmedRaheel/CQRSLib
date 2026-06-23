using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.UpdateReservation;
public sealed class UpdateReservationCommandHandler : IRequestHandler<UpdateReservationCommand, Result<Unit>>
{
    private readonly IReservationCommandRepository _commands;
    private readonly IReservationQueryRepository _query;
    public UpdateReservationCommandHandler(IReservationCommandRepository commands, IReservationQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(UpdateReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Reservation with ID {request.Id} was not found.");
        entity.Update(request.BookId, request.MemberId, request.ReservedAt);
        await _commands.UpdateAsync(request.Id, entity, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Reservation successfully updated.");
    }
}