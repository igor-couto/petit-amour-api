namespace PetitAmourAPI.Domain.Models;

public record Order
{
    public Guid Id { get; init; }
    public Guid CustomerId { get; init; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; init; }
    public DateTime DeliveryDate { get; init; }
    public short PaymentMethod { get; init; }
    public string DeliveryAddress { get; init; }
}