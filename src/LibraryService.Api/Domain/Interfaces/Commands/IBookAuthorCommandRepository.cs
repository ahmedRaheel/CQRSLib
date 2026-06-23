using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for BookAuthor.
/// </summary>
public interface IBookAuthorCommandRepository
{
    /// <summary>
    /// Inserts a BookAuthor entity asynchronously.
    /// </summary>
    Task InsertAsync(BookAuthorEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a BookAuthor entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, BookAuthorEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a BookAuthor entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
