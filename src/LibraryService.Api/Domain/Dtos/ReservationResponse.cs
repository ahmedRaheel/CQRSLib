namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the flat Reservation data transfer object. It intentionally excludes parent/child navigation data.
/// </summary>
public sealed record ReservationDto(Guid Id, Guid BookId, Guid MemberId, DateTime ReservedAt);