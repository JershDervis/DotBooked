using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;

namespace DotBooked.Domain.UnitTests.Orders;

public class OrderByIdSpecTests
{
    [Fact]
    public void OrderByIdSpec_WithId_ReturnsId()
    {
        // Arrange
        var intendedItem = Order.Create(new CustomerId(Guid.NewGuid()));

        var items = new List<Order>()
        {
            Order.Create(new CustomerId(Guid.NewGuid())),
            Order.Create(new CustomerId(Guid.NewGuid())),
            intendedItem,
            Order.Create(new CustomerId(Guid.NewGuid()))
        };
        
        // Act
        var spec = new OrderByIdSpec(intendedItem.Id);
        var output = spec.Evaluate(items).ToList();

        // Assert
        output.Should().NotBeNull();
        output.Should().HaveCount(1);

        output.First().Should().Be(intendedItem);
    }
}