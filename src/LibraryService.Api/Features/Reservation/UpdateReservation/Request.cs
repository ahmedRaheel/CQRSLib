using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.UpdateReservation;
/// <summary>
/// Represents the UpdateReservationCommand request.
/// </summary>
public sealed record UpdateReservationCommand(Guid Id, Guid BookId, Guid MemberId, DateTime ReservedAt) : IRequest<Result<Unit>>;