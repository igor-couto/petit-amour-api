using Npgsql;

namespace PetitAmourAPI.Database;

public class DatabaseConnection : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public DatabaseConnection(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("DefaultConnection");
        _connection = new NpgsqlConnection(connectionString);
    }

    public NpgsqlConnection Get() => _connection;

    public void Dispose() => _connection.Dispose();
}
