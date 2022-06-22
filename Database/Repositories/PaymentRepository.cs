using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class PaymentRepository : IDisposable
{
    private readonly DatabaseConnection _databaseConnection;

    public PaymentRepository(DatabaseConnection database) => _databaseConnection = database;

    internal async Task<IEnumerable<PaymentMethod>> AllPaymentMethods()
    {
        var connection = _databaseConnection.Get();

        return await connection.QueryAsync<PaymentMethod>("SELECT * FROM payment_method;");
    }

    internal async Task<PaymentMethod> PaymentMethod(short id)
    {
        var connection = _databaseConnection.Get();

        return await connection.QueryFirstOrDefaultAsync<PaymentMethod>("SELECT * FROM payment_method WHERE id = @id;", new { id });
    }

    public void Dispose() => _databaseConnection.Dispose();
}