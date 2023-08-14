using DotBooked.Domain.Orders;

namespace DotBooked.Application.Common.Interfaces;

public interface IEmailProvider
{
    public Task SendConfirmationEmail(string email, string customerFirstName, Order order);
}
