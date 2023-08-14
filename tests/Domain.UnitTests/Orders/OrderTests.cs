using DotBooked.Domain.Common.Exceptions;
using DotBooked.Domain.Common.ValueObjects;
using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;
using DotBooked.Domain.Products;

namespace DotBooked.Domain.UnitTests.Orders;

public class OrderTests
{
    [Fact]
    public void CreateOrder_WithNullCustomerId_ThrowsException()
    {
        // Arrange
        CustomerId customerId = null!;

        // Act
        var act = () => Order.Create(customerId);

        // Assert
        act.Should().Throw<NullDomainException>();
    }

    [Fact]
    public void AddItem_WithValidProduct_AddsItemToOrder()
    {
        // Arrange
        var order = Order.Create(new CustomerId(Guid.NewGuid()));
        var product = Product.Create("SKU123", "Product 1", new Money("USD", 10.00m), 5);
        var quantity = 1;
        
        // Act
        var orderItem = order.AddItem(product, quantity);

        // Assert
        orderItem.Should().NotBeNull();
        orderItem.ProductId.Should().Be(product.Id);
        orderItem.Quantity.Should().Be(quantity);
        orderItem.Price.Should().Be(product.Price);
        
        order.Items.Should().HaveCount(1);
    }

    [Fact]
    public void AddPayment_WithValidAmount_RaisesOrderSubmittedEvent()
    {
        // Arrange
        var order = Order.Create(new CustomerId(Guid.NewGuid()));

        var currency = "USD";
        var productAmountCurrentUnit = 10;
        var productAmount = new Money(currency, productAmountCurrentUnit);
        
        var product = Product.Create("SKU123", "Product 1", productAmount, 5);

        // Act
        var quantity = 2;
        order.AddItem(product, quantity);
        
        var payment = new Money(currency, productAmountCurrentUnit * quantity);
        order.AddPayment(payment);

        // Assert
        order.PaidTotal.Should().Be(payment);
        
        var orderSubmittedEvent = order.DomainEvents.LastOrDefault();
            
        orderSubmittedEvent.Should().NotBeNull("the order is paid in full");
        orderSubmittedEvent.Should()
            .BeOfType<OrderSubmittedEvent>("the order is paid in full");
    }
}