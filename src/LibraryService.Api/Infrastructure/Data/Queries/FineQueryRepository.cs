using Dapper;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Queries;

namespace LibraryService.Api.Infrastructure.Data.Queries;
public sealed class FineQueryRepository : IFineQueryRepository
{
    private readonly IApplicationDbConnectionFactory _connectionFactory;
    public FineQueryRepository(IApplicationDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<FineEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, LoanId, Amount FROM Fines WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<FineEntity>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<FineDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, LoanId, Amount FROM Fines WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<FineDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<FineDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, LoanId, Amount FROM Fines WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var flat = await connection.QueryFirstOrDefaultAsync<FineDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return flat is null ? null : new FineDetailDto(flat.Id, flat.LoanId, flat.Amount, null);
    }

    public async Task<PagedResult<FineDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, LoanId, Amount FROM Fines ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        const string countSql = "SELECT COUNT(1) FROM Fines";
        var parameters = new
        {
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize,
            Search = search
        };
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var items = (await connection.QueryAsync<FineDto>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false)).AsList();
        var total = await connection.ExecuteScalarAsync<int>(new CommandDefinition(countSql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return new PagedResult<FineDto>(items, pageNumber, pageSize, total);
    }
}