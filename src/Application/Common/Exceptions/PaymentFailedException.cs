﻿namespace DotBooked.Application.Common.Exceptions;

public class PaymentFailedException : Exception
{
    public PaymentFailedException()
        : base()
    {
    }

    public PaymentFailedException(string message)
        : base(message)
    {
    }

    public PaymentFailedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}