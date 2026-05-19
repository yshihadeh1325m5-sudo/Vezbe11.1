using OrderSystem.Shared.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderSystem.Shared.Infrastructure
{
    public class InMemoryEventBus : IEventBus
    {
        private readonly Dictionary<Type, List<object>> _handlers = new();
        public void Publish<T>(T @event)
        {
            var type = typeof(T);
            if (!_handlers.ContainsKey(type))
                return;

            foreach (var handler in _handlers[type])
            {
                ((Action<T>)handler)(@event);
            }
        }

        public void Subscribe<T>(Action<T> handler)
        {
            var type = typeof(T);
            if (!_handlers.ContainsKey(type))
                _handlers[type] = new List<object>();

            _handlers[type].Add(handler);
        }
    }
}
