using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Reservation.
/// </summary>
public interface IReservationCommandRepository
{
    /// <summary>
    /// Inserts a Reservation entity asynchronously.
    /// </summary>
    Task InsertAsync(ReservationEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Reservation entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, ReservationEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Reservation entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
