using DotBooked.Domain.Customers;

namespace DotBooked.Application.Features.Customers.Queries.GetCustomers;

public class GetCustomersMapping : Profile
{
    public GetCustomersMapping()
    {
        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.Id.Value));

        CreateMap<Address, AddressDto>();
    }
}