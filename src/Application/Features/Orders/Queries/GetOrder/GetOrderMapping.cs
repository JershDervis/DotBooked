﻿using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;
using DotBooked.Domain.Products;

namespace DotBooked.Application.Features.Orders.Queries.GetOrder;

public class GetOrderMapping : Profile
{
    public GetOrderMapping()
    {
        CreateMap<Order, OrderDto>()
            .ForMember(d => d.OrderId, opt => opt.MapFrom(s => s.Id.Value));

        CreateMap<Customer, CustomerDto>()
            .ForMember(d => d.CustomerId, opt => opt.MapFrom(s => s.Id.Value));

        CreateMap<OrderItem, OrderItemDto>()
            .ForMember(d => d.OrderItemId, opt => opt.MapFrom(s => s.Id.Value))
            .ForMember(d => d.Price, opt => opt.MapFrom(s => s.Price.Amount))
            .ForMember(d => d.Currency, opt => opt.MapFrom(s => s.Price.Currency));

        CreateMap<Product, ProductDto>()
            .ForMember(d => d.ProductId, opt => opt.MapFrom(s => s.Id.Value));
    }
}
