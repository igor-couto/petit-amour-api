using System.Text;

namespace PetitAmourAPI.Domain.Services;

public class OrderService
{
    private readonly ClosedDateRepository _closedDateRepository;
    private readonly CustomerRepository _customerRepository;
    private readonly OrderRepository _orderRepository;
    private readonly PaymentRepository _paymentRepository;
    private readonly ProductRepository _productRepository;

    public OrderService(
        ClosedDateRepository closedDateRepository,
        CustomerRepository customerRepository,
        OrderRepository orderRepository,
        PaymentRepository paymentRepository,
        ProductRepository productRepository)
    {
        _closedDateRepository = closedDateRepository;
        _customerRepository = customerRepository;
        _orderRepository = orderRepository;
        _paymentRepository = paymentRepository;
        _productRepository = productRepository;
    }

    public async Task<string> CreateOrder(OrderRequest orderRequest)
    {
        var stringBuilder = new StringBuilder().AppendLine("*Pedido:*");

        var paymentMethod = await _paymentRepository.GetPaymentMethod(orderRequest.PaymentMethod);

        var customer = await _customerRepository.Insert(orderRequest.CustomerName, orderRequest.CustomerPhoneNumber);

        var closedDate = await _closedDateRepository.GetDate(orderRequest.DeliveryDate);

        if (closedDate) return "";

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = customer.Id,
            CreatedAt = DateTime.UtcNow,
            DeliveryDate = orderRequest.DeliveryDate,
            PaymentMethod = paymentMethod.Id,
            DeliveryAddress = orderRequest.DeliveryAddress
        };

        var products = await _productRepository.GetProductsByIds(orderRequest.productRequest.Select(x => x.Id).ToList());
        var orderItems = new List<OrderItem>();
        var totalAmount = 0m;

        orderRequest.productRequest.OrderBy(x => x.Id);
        products.OrderBy(x => x.Id);

        for (var index = 0; index < products.Count; index++)
        {
            var quantity = orderRequest.productRequest[index].Quantity;
            var cost = products[index].Price * quantity;

            orderItems.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                OrderId = order.Id,
                ProductId = products[index].Id,
                Price = cost,
                Quantity = quantity,
            });

            stringBuilder.AppendLine($"{quantity}x {products[index].Name} R${cost}");
            totalAmount += cost;
        }

        stringBuilder
            .Append("*Total:* R$")
            .AppendLine(totalAmount.ToString());

        order.Amount = totalAmount;

        await _orderRepository.CreateOrder(order);

        await _orderRepository.CreateOrderItems(orderItems);

        stringBuilder
            .AppendLine("\n--------------------------------------\n")
            .Append("*Entrega Desejada:* ")
            .AppendLine(orderRequest.DeliveryDate.ToString())
            .AppendLine(orderRequest.CustomerName)
            .AppendLine(orderRequest.CustomerPhoneNumber)
            .AppendLine(orderRequest.DeliveryAddress)
            .Append("*Pagamento:*")
            .Append(paymentMethod.Name);

        return stringBuilder.ToString();
    }
}
