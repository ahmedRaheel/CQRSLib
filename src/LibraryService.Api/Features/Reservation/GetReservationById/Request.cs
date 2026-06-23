using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.GetReservationById;
/// <summary>
/// Represents the GetReservationByIdQuery request.
/// </summary>
public sealed record GetReservationByIdQuery(Guid Id) : IRequest<Result<ReservationDto?>>;