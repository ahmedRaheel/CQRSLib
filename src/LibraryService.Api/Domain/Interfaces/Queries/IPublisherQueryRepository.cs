using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Publisher.
/// </summary>
public interface IPublisherQueryRepository
{
    /// <summary>
    /// Gets a Publisher domain entity by id asynchronously.
    /// </summary>
    Task<PublisherEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Publisher by id asynchronously.
    /// </summary>
    Task<PublisherDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Publisher graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<PublisherDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Publisher records asynchronously.
    /// </summary>
    Task<PagedResult<PublisherDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
