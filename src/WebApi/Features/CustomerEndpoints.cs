using DotBooked.WebApi.Extensions;
using DotBooked.Application.Features.Customers.Queries.GetCustomers;
using MediatR;

namespace DotBooked.WebApi.Features;

public static class CustomerEndpoints
{
    public static void MapCustomerEndpoints(this WebApplication app)
    {
        var group = app
            .MapGroup("/api/customers")
            .WithTags("Customers")
            .WithOpenApi();

        group
            .MapGet("/", (ISender sender, CancellationToken ct) => sender.Send(new GetCustomersQuery(), ct))
            .WithName("GetCustomers")
            .ProducesGet<CustomerDto[]>();
    }
}
