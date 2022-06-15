using Npgsql;
using System.Data;

namespace PetitAmourAPI.Database;

public class Database : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public Database(string connectionString)
        => _connection = new NpgsqlConnection(connectionString);

    public Database(IConfiguration config)
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

    private bool ConnectionIsClosed()
        => _connection.State == ConnectionState.Closed;

    public void Dispose()
        => _connection.Dispose();
}
