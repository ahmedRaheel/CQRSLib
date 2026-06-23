using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Category.
/// </summary>
public interface ICategoryQueryRepository
{
    /// <summary>
    /// Gets a Category domain entity by id asynchronously.
    /// </summary>
    Task<CategoryEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Category by id asynchronously.
    /// </summary>
    Task<CategoryDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Category graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<CategoryDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Category records asynchronously.
    /// </summary>
    Task<PagedResult<CategoryDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
