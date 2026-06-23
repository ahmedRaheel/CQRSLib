using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Fine.
/// </summary>
public interface IFineCommandRepository
{
    /// <summary>
    /// Inserts a Fine entity asynchronously.
    /// </summary>
    Task InsertAsync(FineEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Fine entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, FineEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Fine entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
