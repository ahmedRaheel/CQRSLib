using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Book.
/// </summary>
public interface IBookQueryRepository
{
    /// <summary>
    /// Gets a Book domain entity by id asynchronously.
    /// </summary>
    Task<BookEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Book by id asynchronously.
    /// </summary>
    Task<BookDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Book graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<BookDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Book records asynchronously.
    /// </summary>
    Task<PagedResult<BookDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
