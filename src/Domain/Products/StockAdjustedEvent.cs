using DotBooked.Domain.Common.Base;

namespace DotBooked.Domain.Products;

public record StockAdjustedEvent(Product Product) : DomainEvent;