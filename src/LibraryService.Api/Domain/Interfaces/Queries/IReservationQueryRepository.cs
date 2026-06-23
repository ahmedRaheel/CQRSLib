using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Reservation.
/// </summary>
public interface IReservationQueryRepository
{
    /// <summary>
    /// Gets a Reservation domain entity by id asynchronously.
    /// </summary>
    Task<ReservationEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Reservation by id asynchronously.
    /// </summary>
    Task<ReservationDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Reservation graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<ReservationDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Reservation records asynchronously.
    /// </summary>
    Task<PagedResult<ReservationDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
