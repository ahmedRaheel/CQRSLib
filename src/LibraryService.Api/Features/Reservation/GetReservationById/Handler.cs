using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.GetReservationById;
public sealed class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, Result<ReservationDto?>>
{
    private readonly IReservationQueryRepository _query;
    public GetReservationByIdQueryHandler(IReservationQueryRepository query) => _query = query;
    public async ValueTask<Result<ReservationDto?>> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetByIdAsync(request.Id, cancellationToken).ConfigureAwait(false);
        if (value is null)
            return Errors.NotFound<ReservationDto?>("Reservation with ID {request.Id} was not found.");
        return Result<ReservationDto?>.Success(value, "Reservation retrieved successfully.");
    }
}