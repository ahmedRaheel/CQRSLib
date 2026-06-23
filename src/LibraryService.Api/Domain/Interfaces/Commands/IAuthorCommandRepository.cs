using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Author.
/// </summary>
public interface IAuthorCommandRepository
{
    /// <summary>
    /// Inserts a Author entity asynchronously.
    /// </summary>
    Task InsertAsync(AuthorEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Author entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, AuthorEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Author entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes Author children first and then the parent asynchronously.
    /// </summary>
    Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default);
}
