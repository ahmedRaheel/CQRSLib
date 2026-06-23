using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.CreateReservation;
/// <summary>
/// Represents the CreateReservationCommand request.
/// </summary>
public sealed record CreateReservationCommand(Guid BookId, Guid MemberId, DateTime ReservedAt) : IRequest<Result<ReservationDto>>;