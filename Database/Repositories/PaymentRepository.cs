using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class PaymentRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public PaymentRepository(DbContext dbContext) => _dbContext = dbContext;

    internal async Task<IEnumerable<PaymentMethod>> GetAllPaymentMethods()
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryAsync<PaymentMethod>("SELECT * FROM \"PaymentMethod\";");
    }

    public void Dispose() => _dbContext.Dispose();

    internal async Task<PaymentMethod> GetPaymentMethod(short id)
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryFirstOrDefaultAsync<PaymentMethod>($"SELECT * FROM \"PaymentMethod\" WHERE \"Id\" = @id", new { id });
    }
}