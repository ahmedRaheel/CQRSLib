using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Commands;

/// <summary>
/// Provides write operations for Loan.
/// </summary>
public interface ILoanCommandRepository
{
    /// <summary>
    /// Inserts a Loan entity asynchronously.
    /// </summary>
    Task InsertAsync(LoanEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Updates a Loan entity asynchronously.
    /// </summary>
    Task UpdateAsync(Guid id, LoanEntity entity, CancellationToken cancellationToken = default);
    /// <summary>
    /// Deletes a Loan entity asynchronously.
    /// </summary>
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
