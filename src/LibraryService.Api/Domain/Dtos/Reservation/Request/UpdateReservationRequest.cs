namespace LibraryService.Api.Domain.Dtos.Reservation.Request;
public sealed record UpdateReservationRequest(Guid BookId, Guid MemberId, DateTime ReservedAt);