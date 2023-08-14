using DotBooked.Application.Common.Interfaces;
using DotBooked.Application.Features.Orders.EventHandlers;
using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using NSubstitute;

namespace DotBooked.Application.UnitTests.Features.Orders.EventHandlers;

public class OrderSubmittedEventHandlerTests
{
    [Fact]
    public async Task OrderSubmitted_WithCustomerAndOrder_ShouldSendConfirmationEmail()
    {
        // Arrange
        var customer = new Customer
        {
            Id = new CustomerId(Guid.NewGuid()),
            Email = "a@b.c", 
            FirstName = "John"
        };
        var order = Order.Create(customer.Id);
        var orderSubmittedEvent = new OrderSubmittedEvent(order, customer);

        var logger = Substitute.For<ILogger<OrderSubmittedEventHandler>>();
        var emailProvider = Substitute.For<IEmailProvider>();
        
        var handler = new OrderSubmittedEventHandler(logger, emailProvider);
        
        // Act
        await handler.Handle(orderSubmittedEvent, CancellationToken.None);

        // Assert
        await emailProvider.Received(1).SendConfirmationEmail(customer.Email, customer.FirstName, order);
    }
    
}