using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class CustomerRepository : IDisposable
{
    private readonly DatabaseConnection _databaseConnection;

    public CustomerRepository(DatabaseConnection database) => _databaseConnection = database;

    internal async Task<Customer> Insert(string name, string phoneNumber)
    {
        var commandText = "INSERT INTO customer (id, name, phone_number, created_at) VALUES (@Id, @Name, @PhoneNumber, @CreatedAt);";

        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            Name = name,
            PhoneNumber = phoneNumber,
            CreatedAt = DateTime.Now
        };

        try
        {
            var connection = _databaseConnection.Get();

            await connection.ExecuteAsync(commandText, customer);

            return customer;
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Dispose() => _databaseConnection.Dispose();
}