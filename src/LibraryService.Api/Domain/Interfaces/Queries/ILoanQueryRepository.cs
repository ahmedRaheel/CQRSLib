using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Loan.
/// </summary>
public interface ILoanQueryRepository
{
    /// <summary>
    /// Gets a Loan domain entity by id asynchronously.
    /// </summary>
    Task<LoanEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Loan by id asynchronously.
    /// </summary>
    Task<LoanDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Loan graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<LoanDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Loan records asynchronously.
    /// </summary>
    Task<PagedResult<LoanDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
