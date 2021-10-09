using System;
using MediatR;

namespace ChatApp.Domain.Common
{
    public class BaseDomainEvent : INotification
    {
        public DateTimeOffset DateOccurred { get; protected set; } = DateTimeOffset.UtcNow;
    }
}