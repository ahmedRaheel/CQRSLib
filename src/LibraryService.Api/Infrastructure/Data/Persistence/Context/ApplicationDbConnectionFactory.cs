using System.Data.Common;
using Microsoft.Data.SqlClient;
using LibraryService.Api.Domain.Interfaces;

namespace LibraryService.Api.Infrastructure.Data.Persistence.Context;
public sealed class ApplicationDbConnectionFactory : IApplicationDbConnectionFactory
{
    private readonly string _connectionString;
    public ApplicationDbConnectionFactory(string connectionString) => _connectionString = connectionString;
    public DbConnection CreateConnection() => new SqlConnection(_connectionString);
    public async Task<DbConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SqlConnection(_connectionString);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        return connection;
    }
}