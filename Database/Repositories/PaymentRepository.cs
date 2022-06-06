using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class PaymentRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public PaymentRepository(DbContext dbContext) => _dbContext = dbContext;

    internal async Task<IEnumerable<PaymentType>> GetAllPaymentTypes()
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryAsync<PaymentType>("SELECT * FROM \"PaymentType\";");
    }

    public void Dispose() => _dbContext.Dispose();
}