using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Commands;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.CreateReservation;
public sealed class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, Result<ReservationDto>>
{
    private readonly IReservationCommandRepository _commands;
    private readonly IReservationQueryRepository _query;
    public CreateReservationCommandHandler(IReservationCommandRepository commands, IReservationQueryRepository query)
    {
        _commands = commands;
        _query = query;
    }

    public async ValueTask<Result<ReservationDto>> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var entity = ReservationEntity.Create(request.BookId, request.MemberId, request.ReservedAt);
        await _commands.InsertAsync(entity, cancellationToken).ConfigureAwait(false);
        var response = new ReservationDto(entity.Id, entity.BookId, entity.MemberId, entity.ReservedAt);
        return Result<ReservationDto>.Success(response, "Reservation successfully created.");
    }
}