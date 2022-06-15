using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class PaymentRepository : IDisposable
{
    private readonly Database _database;

    public PaymentRepository(Database database) => _database = database;

    internal async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
    {
        var connection = await _database.GetConnection();

        return await connection.QueryAsync<PaymentMethod>("SELECT * FROM payment_method;");
    }

    public void Dispose() => _database.Dispose();

    internal async Task<PaymentMethod> GetPaymentMethod(short id)
    {
        var connection = await _database.GetConnection();

        return await connection.QueryFirstOrDefaultAsync<PaymentMethod>("SELECT * FROM payment_method WHERE id = @id;", new { id });
    }
}