namespace LibraryService.Api.Domain.Dtos;
/// <summary>
/// Represents the detailed Member DTO used only when children/parents are explicitly requested.
/// </summary>
public sealed record MemberDetailDto(Guid Id, string Name, string Email, IReadOnlyList<LoanDto> Loans, IReadOnlyList<ReservationDto> Reservations);