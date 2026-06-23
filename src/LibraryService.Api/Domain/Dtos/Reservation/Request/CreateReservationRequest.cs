namespace LibraryService.Api.Domain.Dtos.Reservation.Request;
public sealed record CreateReservationRequest(Guid BookId, Guid MemberId, DateTime ReservedAt);