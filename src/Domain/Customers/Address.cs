﻿using DotBooked.Domain.Common.Base;

namespace DotBooked.Domain.Customers;

public class Address : IValueObject
{
    public string Line1 { get; set; } = null!;
    public string Line2 { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostCode { get; set; } = null!;
    public string Country { get; set; } = null!;
}
