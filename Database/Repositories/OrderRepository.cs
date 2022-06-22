using Dapper;

namespace PetitAmourAPI.Database.Repositories;

public class OrderRepository : IDisposable
{
    private readonly DatabaseConnection _databaseConnection;

    public OrderRepository(DatabaseConnection database) => _databaseConnection = database;

    internal async Task Insert(Order order)
    {
        var connection = _databaseConnection.Get();

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

    internal async Task InsertOrderItems(List<OrderItem> orderItems)
    {
        var connection = _databaseConnection.Get();

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

    public void Dispose() => _databaseConnection.Dispose();
}