
using System;

namespace OrderSystem.Shared.Application
{
    public interface IIdGenerator
    {
        Guid NewId();
    }
}
