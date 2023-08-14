using Ardalis.Specification;

namespace DotBooked.Domain.Products;

public sealed class ProductByIdSpec : SingleResultSpecification<Product>
{
    public ProductByIdSpec(ProductId productId)
    {
        Query.Where(p => p.Id == productId);
    }
}
