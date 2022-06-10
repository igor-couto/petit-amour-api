using Dapper;
using PetitAmourAPI.Domain.Models;

namespace PetitAmourAPI.Database.Repositories;

public class OrderRepository : IDisposable
{
    private readonly DbContext _dbContext;

    public OrderRepository(DbContext dbContext) => _dbContext = dbContext;

    internal async Task CreateOrder(Order order)
    {
        var connection = await _dbContext.GetConnection();

        var commandText = "INSERT INTO \"Order\" (\"Id\", \"CustomerId\", \"Amount\", \"CreatedAt\",  \"DeliveryDate\",  \"PaymentMethod\", \"DeliveryAddress\") VALUES (@Id, @CustomerId, @Amount, @CreatedAt, @DeliveryDate, @PaymentMethod, @DeliveryAddress);";

        try
        {
            var queryArguments = new
            {
                order.Id,
                order.CustomerId,
                order.Amount,
                order.CreatedAt,
                order.DeliveryDate,
                order.PaymentMethod,
                order.DeliveryAddress
            };

            await connection.ExecuteAsync(commandText, queryArguments);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    internal async Task CreateOrderItems(List<OrderItem> orderItems)
    {
        var connection = await _dbContext.GetConnection();

        var commandText = "INSERT INTO \"OrderItem\" (\"Id\", \"OrderId\", \"ProductId\", \"Quantity\", \"Price\") VALUES (@Id, @OrderId, @ProductId, @Quantity, @Price);";

        try
        {
            await connection.ExecuteAsync(commandText, orderItems);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public void Dispose() => _dbContext.Dispose();
}