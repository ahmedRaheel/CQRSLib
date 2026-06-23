using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Member.
/// </summary>
public interface IMemberCommandRepository
{
    /// <summary>
    /// Inserts a Member entity asynchronously.
    /// </summary>
    Task InsertAsync(MemberEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Member entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, MemberEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Member entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes Member children first and then the parent asynchronously.
    /// </summary>
    Task DeleteWithChildrenAsync(Guid id, CancellationToken cancellationToken = default);
}
