using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for BookPublisher.
/// </summary>
public interface IBookPublisherCommandRepository
{
    /// <summary>
    /// Inserts a BookPublisher entity asynchronously.
    /// </summary>
    Task InsertAsync(BookPublisherEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a BookPublisher entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, BookPublisherEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a BookPublisher entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
