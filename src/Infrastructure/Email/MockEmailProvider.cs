using DotBooked.Application.Common.Interfaces;
using DotBooked.Domain.Orders;
using Microsoft.Extensions.Logging;

namespace DotBooked.Infrastructure.Email;

public class MockEmailProvider : IEmailProvider
{
    private readonly ILogger<MockEmailProvider> _logger;

    public MockEmailProvider(ILogger<MockEmailProvider> logger)
    {
        _logger = logger;
    }

    public Task SendConfirmationEmail(string email, string customerFirstName, Order order)
    {
        _logger.LogInformation("Sending confirmation email - email:{email}, name:{name}, orderId:{orderId}", email, customerFirstName, order.Id);
        return Task.CompletedTask;
    }
}
