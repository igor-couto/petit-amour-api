using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class ProductRepository : IDisposable
{
    private readonly DatabaseConnection _databaseConnection;

    public ProductRepository(DatabaseConnection database) => _databaseConnection = database;

    public async Task<IEnumerable<Product>> AllProducts()
    {
        var connection = _databaseConnection.Get();

        return await connection.QueryAsync<Product>("SELECT * FROM product;");
    }


    public async Task<List<Product>> ProductsByIds(List<Guid> ids)
    {
        try
        {
            var connection = _databaseConnection.Get();

            var query = $"SELECT * FROM product WHERE id IN ( {string.Join(", ", ids.Select(x => "'" + x + "'"))} );";

            var result = await connection.QueryAsync<Product>(query);
            return result.ToList();
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Dispose() => _databaseConnection.Dispose();
}