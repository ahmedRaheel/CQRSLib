using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Category.
/// </summary>
public interface ICategoryCommandRepository
{
    /// <summary>
    /// Inserts a Category entity asynchronously.
    /// </summary>
    Task InsertAsync(CategoryEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Category entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, CategoryEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Category entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes Category children first and then the parent asynchronously.
    /// </summary>
    Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default);
}
