
using System;
using OrderSystem.Shared.Application;

namespace OrderSystem.Shared.Infrastructure
{
    public class GuidGenerator : IIdGenerator
    {
        public Guid NewId() => Guid.NewGuid();
    }
}
