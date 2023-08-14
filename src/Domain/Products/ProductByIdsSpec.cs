using Ardalis.Specification;

namespace DotBooked.Domain.Products;

public sealed class ProductByIdsSpec : Specification<Product>
{
    public ProductByIdsSpec(IEnumerable<ProductId> productIds)
    {
        Query.Where(p => productIds.Contains(p.Id));
    }
}