using DotBooked.Domain.Common.Base;
using DotBooked.Domain.Customers;

namespace DotBooked.Domain.Orders;

public record OrderSubmittedEvent(Order Order, Customer Customer) : DomainEvent;
