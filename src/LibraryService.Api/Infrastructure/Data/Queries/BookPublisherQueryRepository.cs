using Dapper;
using LibraryService.Api.Domain.Interfaces;
using LibraryService.Api.Domain.Dtos;
using LibraryService.Api.Domain.Entities;
using LibraryService.Api.Domain.Interfaces.Queries;

namespace LibraryService.Api.Infrastructure.Data.Queries;
public sealed class BookPublisherQueryRepository : IBookPublisherQueryRepository
{
    private readonly IApplicationDbConnectionFactory _connectionFactory;
    public BookPublisherQueryRepository(IApplicationDbConnectionFactory connectionFactory) => _connectionFactory = connectionFactory;
    public async Task<BookPublisherEntity?> GetEntityByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, PublisherId FROM BookPublishers WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<BookPublisherEntity>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<BookPublisherDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, PublisherId FROM BookPublishers WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        return await connection.QueryFirstOrDefaultAsync<BookPublisherDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<BookPublisherDetailDto?> GetDetailByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, PublisherId FROM BookPublishers WHERE Id = @Id";
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var flat = await connection.QueryFirstOrDefaultAsync<BookPublisherDto>(new CommandDefinition(sql, new { Id = id }, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return flat is null ? null : new BookPublisherDetailDto(flat.Id, flat.BookId, flat.PublisherId, null, null);
    }

    public async Task<PagedResult<BookPublisherDto>> GetPagedAsync(int pageNumber, int pageSize, string? search, CancellationToken cancellationToken = default)
    {
        const string sql = "SELECT Id, BookId, PublisherId FROM BookPublishers ORDER BY Id OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY";
        const string countSql = "SELECT COUNT(1) FROM BookPublishers";
        var parameters = new
        {
            Offset = (pageNumber - 1) * pageSize,
            PageSize = pageSize,
            Search = search
        };
        await using var connection = await _connectionFactory.CreateOpenConnectionAsync(cancellationToken);
        var items = (await connection.QueryAsync<BookPublisherDto>(new CommandDefinition(sql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false)).AsList();
        var total = await connection.ExecuteScalarAsync<int>(new CommandDefinition(countSql, parameters, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return new PagedResult<BookPublisherDto>(items, pageNumber, pageSize, total);
    }
}