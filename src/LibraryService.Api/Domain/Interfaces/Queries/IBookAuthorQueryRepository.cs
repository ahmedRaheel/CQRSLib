using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for BookAuthor.
/// </summary>
public interface IBookAuthorQueryRepository
{
    /// <summary>
    /// Gets a BookAuthor domain entity by id asynchronously.
    /// </summary>
    Task<BookAuthorEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat BookAuthor by id asynchronously.
    /// </summary>
    Task<BookAuthorDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed BookAuthor graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<BookAuthorDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged BookAuthor records asynchronously.
    /// </summary>
    Task<PagedResult<BookAuthorDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
