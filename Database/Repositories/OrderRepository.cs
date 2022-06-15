using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class OrderRepository : IDisposable
{
    private readonly Database _database;

    public OrderRepository(Database database) => _database = database;

    internal async Task CreateOrder(Order order)
    {
        var connection = await _database.GetConnection();

        var commandText = @"INSERT INTO ""order"" (id, customer_id, amount, created_at, delivery_date, payment_method, delivery_address) VALUES (@Id, @CustomerId, @Amount, @CreatedAt, @DeliveryDate, @PaymentMethod, @DeliveryAddress);";

        try
        {
            await connection.ExecuteAsync(commandText, order);
        }
        catch (Exception)
        {
            throw;
        }
    }

    internal async Task CreateOrderItems(List<OrderItem> orderItems)
    {
        var connection = await _database.GetConnection();

        var commandText = "INSERT INTO order_item (id, order_id, product_id, quantity, price) VALUES (@Id, @OrderId, @ProductId, @Quantity, @Price);";

        try
        {
            await connection.ExecuteAsync(commandText, orderItems);
        }
        catch (Exception)
        {
            throw;
        }
    }

    public void Dispose() => _database.Dispose();
}