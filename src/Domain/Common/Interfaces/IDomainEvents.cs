﻿using DotBooked.Domain.Common.Base;

namespace DotBooked.Domain.Common.Interfaces;

public interface IDomainEvents
{
    IReadOnlyList<DomainEvent> DomainEvents { get; }

    void AddDomainEvent(DomainEvent domainEvent);

    void RemoveDomainEvent(DomainEvent domainEvent);

    void ClearDomainEvents();
}
