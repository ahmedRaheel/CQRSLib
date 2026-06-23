using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.GetReservationsPaged;
/// <summary>
/// Represents the GetReservationsPagedQuery request.
/// </summary>
public sealed record GetReservationsPagedQuery(int PageNumber, int PageSize, string? Search) : IRequest<Result<PagedResult<ReservationDto>>>;