using DotBooked.Domain.Customers;
using DotBooked.Application.Features.Orders.Commands.CreateOrder;
using DotBooked.Application.IntegrationTests.TestHelpers;
using DotBooked.Domain.Orders;
using Microsoft.EntityFrameworkCore;

namespace DotBooked.Application.IntegrationTests.Features.Orders;

public class CreateOrderCommandTests : IntegrationTestBase
{
    [Fact]
    public async Task CreateOrder_WithCustomerId_CreateNewOrder()
    {
        // Arrange
        var customer = await Context.Customers.FirstAsync();
        var customerId = customer.Id.Value;

        // Act
        var orderId = await Mediator.Send(new CreateOrderCommand(customerId));

        // Assert
        var order = await Context.Orders.FindAsync(new OrderId(orderId));

        order.Should().NotBeNull();
        order!.CustomerId.Should().Be(customer.Id);

    }

    public CreateOrderCommandTests(TestingDatabaseFixture fixture) : base(fixture)
    {
    }
}