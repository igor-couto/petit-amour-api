namespace PetitAmourAPI.Domain.Models;

public record PaymentType
{
    public string Id { get; }
    public string Name { get; }
    public ushort Discount { get; }
}