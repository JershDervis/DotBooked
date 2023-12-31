﻿using DotBooked.Domain.Common.Interfaces;

namespace DotBooked.Domain.Common.Base;

public abstract class Entity<TId> : IAuditableEntity
{
    public required TId Id { get; init; }
    public DateTimeOffset CreatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
    public string? UpdatedBy { get; set; }
}
