using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for BookCategory.
/// </summary>
public interface IBookCategoryCommandRepository
{
    /// <summary>
    /// Inserts a BookCategory entity asynchronously.
    /// </summary>
    Task InsertAsync(BookCategoryEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a BookCategory entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, BookCategoryEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a BookCategory entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
