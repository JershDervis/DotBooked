using DotBooked.Domain.Customers;
using DotBooked.Domain.Orders;
using DotBooked.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace DotBooked.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Customer> Customers { get; }

    public DbSet<Order> Orders { get; }

    public DbSet<Product> Products { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
