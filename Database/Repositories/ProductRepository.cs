using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class ProductRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public ProductRepository(DbContext dbContext) => _dbContext = dbContext;

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var connection = await _dbContext.GetConnection();

        return await connection.QueryAsync<Product>("SELECT * FROM \"Product\";");
    }

    public void Dispose() => _dbContext.Dispose();

    public async Task<List<Product>> GetProducts(List<string> ids)
    {
        try
        {
            var connection = await _dbContext.GetConnection();

            var result = await connection.QueryAsync<Product>("SELECT * FROM \"Product\" WHERE \"Id\" IN (@ids);", new { ids = string.Join(",", ids) });
            return result.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}