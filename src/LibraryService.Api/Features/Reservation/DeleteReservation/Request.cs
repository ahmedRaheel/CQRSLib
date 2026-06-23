using FastCqrs;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Shared;

namespace LibraryService.Api.Features.Reservation.DeleteReservation;
/// <summary>
/// Represents the DeleteReservationCommand request.
/// </summary>
public sealed record DeleteReservationCommand(Guid Id) : IRequest<Result<Unit>>;