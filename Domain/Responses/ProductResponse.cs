namespace PetitAmourAPI.Domain.Models;

public class ProductResponse
{
    public List<ProducViewList> ProducList { get; init; }

    public ProductResponse(IEnumerable<Product> products, IEnumerable<ProductCategory> categories)
    {
        ProducList = new List<ProducViewList>();

        var productsByCategoryId = new Dictionary<Guid, List<ProductView>>();

        foreach (var product in products)
        {
            var productView = new ProductView
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            var productViewList = productsByCategoryId.GetValueOrDefault(product.Category_Id);

            if (productViewList is null)
            {
                productViewList = new List<ProductView>();
                productsByCategoryId.Add(product.Category_Id, productViewList);
            }

            productViewList.Add(productView);
        }

        foreach (var category in categories)
        {
            var productViewList = productsByCategoryId.GetValueOrDefault(category.Id);

            if (productViewList is null)
                continue;

            ProducList.Add(new ProducViewList()
            {
                Category = category.Name,
                Products = productViewList
            });
        }
    }
}

public class ProducViewList
{
    public string Category { get; init; }
    public List<ProductView> Products { get; init; }
}

public class ProductView
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Description { get; init; }
    public decimal Price { get; init; }
}