using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for BookPublisher.
/// </summary>
public interface IBookPublisherQueryRepository
{
    /// <summary>
    /// Gets a BookPublisher domain entity by id asynchronously.
    /// </summary>
    Task<BookPublisherEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat BookPublisher by id asynchronously.
    /// </summary>
    Task<BookPublisherDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed BookPublisher graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<BookPublisherDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged BookPublisher records asynchronously.
    /// </summary>
    Task<PagedResult<BookPublisherDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
