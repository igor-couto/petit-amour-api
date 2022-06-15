using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class ProductRepository : IDisposable
{
    private readonly Database _database;

    public ProductRepository(Database database) => _database = database;

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        var connection = await _database.GetConnection();

        return await connection.QueryAsync<Product>("SELECT * FROM product;");
    }

    public void Dispose() => _database.Dispose();

    public async Task<List<Product>> GetProductsByIds(List<Guid> ids)
    {
        try
        {
            var connection = await _database.GetConnection();

            var query = $"SELECT * FROM product WHERE id IN ( {string.Join(", ", ids.Select(x => "'" + x + "'"))} );";

            var result = await connection.QueryAsync<Product>(query);
            return result.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }
}