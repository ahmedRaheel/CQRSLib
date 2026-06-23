using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Publisher.
/// </summary>
public interface IPublisherCommandRepository
{
    /// <summary>
    /// Inserts a Publisher entity asynchronously.
    /// </summary>
    Task InsertAsync(PublisherEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Publisher entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, PublisherEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Publisher entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes Publisher children first and then the parent asynchronously.
    /// </summary>
    Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default);
}
