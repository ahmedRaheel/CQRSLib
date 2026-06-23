using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.DeleteReservation;
public sealed class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Result<Unit>>
{
    private readonly IReservationCommandRepository _commands;
    private readonly IReservationQueryRepository _query;
    public DeleteReservationCommandHandler(IReservationCommandRepository commands, IReservationQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<Unit>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = await _query.GetEntityByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (entity is null)
            return Errors.NotFound<Unit>("Reservation with ID {request.Id} was not found.");
        await _commands.DeleteAsync(request.Id, cancellationToken).ConfigureAwait(false);
        return Result<Unit>.Success(Unit.Value, "Reservation successfully deleted.");
    }
}