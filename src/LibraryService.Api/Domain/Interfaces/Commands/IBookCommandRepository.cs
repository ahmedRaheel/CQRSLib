using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Book.
/// </summary>
public interface IBookCommandRepository
{
    /// <summary>
    /// Inserts a Book entity asynchronously.
    /// </summary>
    Task InsertAsync(BookEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Book entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, BookEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Book entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes Book children first and then the parent asynchronously.
    /// </summary>
    Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default);
}
