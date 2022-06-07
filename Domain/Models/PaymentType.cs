namespace PetitAmourAPI.Domain.Models;

public record PaymentType
{
    public ushort Id { get; }
    public string Name { get; }
    public ushort Discount { get; }
}