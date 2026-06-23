using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for BookCategory.
/// </summary>
public interface IBookCategoryQueryRepository
{
    /// <summary>
    /// Gets a BookCategory domain entity by id asynchronously.
    /// </summary>
    Task<BookCategoryEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat BookCategory by id asynchronously.
    /// </summary>
    Task<BookCategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed BookCategory graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<BookCategoryDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged BookCategory records asynchronously.
    /// </summary>
    Task<PagedResult<BookCategoryDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
