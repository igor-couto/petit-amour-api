namespace PetitAmourAPI.Domain.Requests;

public class OrderRequest
{
    public string CustomerName { get; set; }
    public string CustomerPhoneNumber { get; set; }
    public short PaymentMethod { get; set; }
    public DateTime DeliveryDate { get; set; }
    public string DeliveryAddress { get; set; }
    public Product[] productRequest { get; set; }

    public class Product
    {
        public Guid Id { get; set; }
        public short Quantity { get; set; }
    }
}