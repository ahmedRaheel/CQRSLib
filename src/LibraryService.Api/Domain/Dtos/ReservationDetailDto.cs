namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Reservation DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record ReservationDetailDto(Guid Id, Guid BookId, Guid MemberId, DateTime ReservedAt, BookDto? Book, MemberDto? Member);