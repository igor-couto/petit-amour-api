using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class ProductRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public ProductRepository(DbContext dbContext) => _dbContext = dbContext;

    internal async Task<IEnumerable<Product>> GetAllProducts()
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryAsync<Product>("SELECT * FROM \"Product\";");
    }

    public void Dispose() => _dbContext.Dispose();
}