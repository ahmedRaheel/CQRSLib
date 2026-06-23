using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;

namespace LibraryService.Api.Domain.Interfaces.Queries;

/// <summary>
/// Provides read operations for Member.
/// </summary>
public interface IMemberQueryRepository
{
    /// <summary>
    /// Gets a Member domain entity by id asynchronously.
    /// </summary>
    Task<MemberEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a flat Member by id asynchronously.
    /// </summary>
    Task<MemberDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets a detailed Member graph by id asynchronously when the caller explicitly needs children/parents.
    /// </summary>
    Task<MemberDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default);
    /// <summary>
    /// Gets paged Member records asynchronously.
    /// </summary>
    Task<PagedResult<MemberDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default);
}
