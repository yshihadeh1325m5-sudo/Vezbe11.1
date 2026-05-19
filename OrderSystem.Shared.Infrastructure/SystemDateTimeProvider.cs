
using System;
using OrderSystem.Shared.Application;

namespace OrderSystem.Shared.Infrastructure
{
    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now() => DateTime.Now;
    }
}
