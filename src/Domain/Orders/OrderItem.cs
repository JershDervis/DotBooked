using DotBooked.Domain.Common.Base;
using DotBooked.Domain.Common.Exceptions;
using DotBooked.Domain.Common.ValueObjects;
using DotBooked.Domain.Products;

namespace DotBooked.Domain.Orders;

public record OrderItemId(Guid Value);

public class OrderItem : Entity<OrderItemId>
{
    public OrderId OrderId { get; private set; } = null!;
    public ProductId ProductId { get; private set; } = null!;
    public int Quantity { get; private set; }
    public Money Price { get; private set; } = null!;

    public Order? Order { get; private set; }
    public Product? Product { get; private set; }

    private OrderItem() { }

    internal static OrderItem Create(Product product, int quantity)
    {
        Guard.Against.Null(product.Price);
        Guard.Against.ZeroOrNegative(product.Price.Amount);

        return new OrderItem()
        {
            Id = new OrderItemId(Guid.NewGuid()),
            ProductId = product.Id,
            Price = new Money(product.Price.Currency, product.Price.Amount),
            Quantity = quantity
        };
    }

    public void AddQuantity(int quantity)
    {
        Guard.Against.ZeroOrNegative(quantity);
        Quantity += quantity;
    }

    public void RemoveQuantity(int quantity)
    {
        Guard.Against.ZeroOrNegative(quantity);
        Quantity -= quantity;
    }
}
