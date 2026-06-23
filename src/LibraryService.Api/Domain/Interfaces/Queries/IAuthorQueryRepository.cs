using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Author.
/// </summary>
public interface IAuthorQueryRepository
{
    /// <summary>
    /// Gets a Author domain entity by id asynchronously.
    /// </summary>
    Task<AuthorEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Author by id asynchronously.
    /// </summary>
    Task<AuthorDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Author graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<AuthorDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Author records asynchronously.
    /// </summary>
    Task<PagedResult<AuthorDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
