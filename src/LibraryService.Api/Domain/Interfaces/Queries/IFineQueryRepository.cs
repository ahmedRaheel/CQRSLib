using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Fine.
/// </summary>
public interface IFineQueryRepository
{
    /// <summary>
    /// Gets a Fine domain entity by id asynchronously.
    /// </summary>
    Task<FineEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Fine by id asynchronously.
    /// </summary>
    Task<FineDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Fine graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<FineDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Fine records asynchronously.
    /// </summary>
    Task<PagedResult<FineDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
