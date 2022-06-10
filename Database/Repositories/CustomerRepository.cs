using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class CustomerRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public CustomerRepository(DbContext dbContext) => _dbContext = dbContext;

    internal async Task<Customer> Insert(string name, string phoneNumber)
    {
        var commandText = "INSERT INTO \"Customer\" (\"Id\", \"Name\", \"PhoneNumber\", \"CreatedAt\") VALUES (@Id, @Name, @PhoneNumber, @CreatedAt);";

        var customer = new Customer
        {
            Id = Guid.NewGuid().ToString(),
            Name = name,
            PhoneNumber = phoneNumber,
            CreatedAt = DateTime.Now
        };

        try
        {
            var queryArguments = new
            {
                customer.Id,
                customer.Name,
                customer.PhoneNumber,
                customer.CreatedAt
            };

            var connection = await _dbContext.GetConnection();

            await connection.ExecuteAsync(commandText, queryArguments);

            return customer;
        }
        catch (Exception ex)
        {
            //"Ocorreu um erro persistir o cliente no sistema."
            throw ex;
        }
    }

    public void Dispose() => _dbContext.Dispose();
}