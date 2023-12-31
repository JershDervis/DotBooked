﻿using DotBooked.Domain.Common.Base;

namespace DotBooked.Domain.Common.ValueObjects;

public record Money(string Currency, decimal Amount) : IValueObject
{
    public static Money Default => new("AUD", 0);

    public bool IsZero => Amount == 0;

    public static Money operator +(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return new Money(left.Currency, left.Amount + right.Amount);
    }

    public static Money operator -(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return new Money(left.Currency, left.Amount - right.Amount);
    }

    public static bool operator <(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return left.Amount < right.Amount;
    }

    public static bool operator <=(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return left.Amount <= right.Amount;
    }

    public static bool operator >(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return left.Amount > right.Amount;
    }

    public static bool operator >=(Money left, Money right)
    {
        ValidateCurrencies(left, right);
        return left.Amount >= right.Amount;
    }

    private static void ValidateCurrencies(Money left, Money right)
    {
        if (!left.Currency.Equals(right.Currency, StringComparison.OrdinalIgnoreCase))
            throw new InvalidOperationException("Different currencies");
    }
}
