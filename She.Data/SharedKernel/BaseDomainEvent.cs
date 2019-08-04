using System;

namespace She.Data.SharedKernel
{
    public class BaseDomainEvent
    {
        public DateTime DateOccured { get; protected set; } = DateTime.UtcNow;
    }
}