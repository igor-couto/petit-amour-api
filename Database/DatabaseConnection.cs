using Npgsql;
using System.Data;

namespace PetitAmourAPI.Database;

public class DatabaseConnection : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public DatabaseConnection(string connectionString)
        => _connection = new NpgsqlConnection(connectionString);

    public DatabaseConnection(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        _connection = new NpgsqlConnection(connectionString);
    }

    public async Task<NpgsqlConnection> Get()
    {
        if (ConnectionIsClosed())
            await _connection.OpenAsync();

        return _connection;
    }

    private bool ConnectionIsClosed() => _connection.State == ConnectionState.Closed;

    public void Dispose() => _connection.Dispose();
}
