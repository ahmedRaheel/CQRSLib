using FastCqrs;
using LibraryService.Api.Domain.Interfaces.Queries;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.GetReservationsPaged;
public sealed class GetReservationsPagedQueryHandler : IRequestHandler<GetReservationsPagedQuery, Result<PagedResult<ReservationDto>>>
{
    private readonly IReservationQueryRepository _query;
    public GetReservationsPagedQueryHandler(IReservationQueryRepository query) => _query = query;
    public async ValueTask<Result<PagedResult<ReservationDto>>> Handle(GetReservationsPagedQuery request, CancellationToken cancellationToken)
    {
        var value = await _query.GetPagedAsync(request.PageNumber, request.PageSize, request.Search, cancellationToken).ConfigureAwait(false);
        return Result<PagedResult<ReservationDto>>.Success(value, "Reservation retrieved successfully.");
    }
}