using DotBooked.Application.Common.Interfaces;
using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;

namespace DotBooked.Application.Features.Orders.Commands.CreateOrder;

public record CreateOrderCommand(Guid CustomerId) : IRequest<Guid>;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IApplicationDbContext _applicationDbContext;

    public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext)
    {
        _applicationDbContext = applicationDbContext;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var order = Order.Create(new CustomerId(request.CustomerId));

        _applicationDbContext.Orders.Add(order);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return order.Id.Value;
    }
}

