using Npgsql;
using System.Data;

namespace PetitAmourAPI.Database;

public class DbContext : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public DbContext(string connectionString)
        => _connection = new NpgsqlConnection(connectionString);

    public DbContext(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        _connection = new NpgsqlConnection(connectionString);
    }

    public async Task<NpgsqlConnection> GetConnection()
    {
        if (ConnectionIsClosed())
            await _connection.OpenAsync();

        return _connection;
    }

    public void Dispose()
        => _connection.Dispose();

    private bool ConnectionIsClosed()
        => _connection.State == ConnectionState.Closed;
}
