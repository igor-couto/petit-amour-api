using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class CustomerRepository : IDisposable
{
    private readonly Database _database;

    public CustomerRepository(Database database) => _database = database;

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
            var connection = await _database.GetConnection();

            await connection.ExecuteAsync(commandText, customer);

            return customer;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Dispose() => _database.Dispose();
}